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
		public NAudioMidiOutput MidiOutput;
		public bool Connected;

		public ConfigureDialog()
		{
			InitializeComponent();
			var ports = SerialPort.GetPortNames();
			foreach (var port in ports)
				comboBox1.Items.Add(port);

			var midiDevices = NAudioMidiOutput.GetMIDIOutDevices();

			foreach (var device in midiDevices)
			{
				comboBox2.Items.Add(device.Item1);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Connected = true;
			this.Close();
		}

		public string COMPort
		{
			get { return (comboBox1.SelectedItem != null) ? comboBox1.SelectedItem.ToString() : ""; }
		}

		public int MidiDeviceID
		{
			get
			{
				var midiDevices = NAudioMidiOutput.GetMIDIOutDevices();
				var item = midiDevices.First(x => x.Item1 == comboBox2.SelectedItem.ToString());
				return item.Item2;
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

		public static ConfigureDialog Show(int channelCount, int baudrate, string COMname = null, int midiDeviceID = -1)
		{
			var dialog = new ConfigureDialog();

			dialog.textBox1.Text = channelCount.ToString();
			dialog.textBox2.Text = baudrate.ToString();

			if (COMname != null && dialog.comboBox1.Items.Contains(COMname))
				dialog.comboBox1.SelectedItem = COMname;

			if (midiDeviceID != -1)
			{
				var name = AudioLib.PortMidi.Pm_GetDeviceInfo(midiDeviceID).name;
				if (dialog.comboBox2.Items.Contains(name))
					dialog.comboBox2.SelectedItem = name;
			}

			dialog.ShowDialog();
			return dialog;
		}
	}
}
