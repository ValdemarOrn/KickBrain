using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using AudioLib;

namespace KickBrain
{
	public partial class ConfigureDialog : Form
	{
		public SerialInput SerialInput;
		public MidiOutput MidiOutput;
		public bool Connected;

		public ConfigureDialog()
		{
			InitializeComponent();
			var ports = SerialPort.GetPortNames();
			foreach (var port in ports)
				comboBox1.Items.Add(port);

			for (int i = 0; i < AudioLib.PortMidi.Pm_CountDevices(); i++)
			{
				var info = AudioLib.PortMidi.Pm_GetDeviceInfo(i);
				if (info.output > 0)
					comboBox2.Items.Add(info.name);
			}

			comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
			comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Connected = true;
			this.Close();
		}

		public string COMPort
		{
			get { return comboBox1.SelectedItem.ToString(); }
		}

		public int MidiDeviceID
		{
			get
			{
				// find the device ID
				int deviceId = -1;
				for (int i = 0; i < PortMidi.Pm_CountDevices(); i++)
				{
					var info = PortMidi.Pm_GetDeviceInfo(i);
					if (info.name == comboBox2.SelectedItem.ToString() && info.output > 0)
					{
						deviceId = i;
						break;
					}
				}
				return deviceId;
			}
		}

		public int NumberOfChannels
		{
			get { return Convert.ToInt32(textBox1.Text); }
		}

		public int BaudRate
		{
			get { return Convert.ToInt32(textBox2.Text); }
		}

		public static ConfigureDialog Show()
		{
			var dialog = new ConfigureDialog();
			dialog.ShowDialog();
			return dialog;
		}
	}
}
