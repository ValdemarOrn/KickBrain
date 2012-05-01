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
	public partial class AddPortDialog : Form
	{
		public SerialInput SerialInput;
		public MidiOutput MidiOutput;

		public AddPortDialog()
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
			try
			{
				SerialInput = new SerialInput(comboBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text));
			}
			catch (Exception ex)
			{
				SerialInput.Stop();
				MessageBox.Show("Unable to open Serial Port " + comboBox1.Text + "\n" + ex.Message);
				return;
			}

			try
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

				if (deviceId < 0) throw new Exception("Unable to open Midi Interface with name " + comboBox2.SelectedText);

				MidiOutput = new MidiOutput(deviceId);
			}
			catch (Exception ex)
			{
				try
				{
					SerialInput.Stop();
				}
				catch (Exception exx)
				{

				}

				try
				{
					MidiOutput.Close();
				}
				catch (Exception exx)
				{

				}
				MessageBox.Show("Unable to open Midi Port " + comboBox2.Text + "\n" + ex.Message);
				return;
			}

			this.Close();
		}

		public static AddPortDialog Show()
		{
			var dialog = new AddPortDialog();
			dialog.ShowDialog();
			return dialog;
		}
	}
}
