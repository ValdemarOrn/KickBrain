using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialAudio
{
	public partial class AddPort : Form
	{
		protected SerialInput input;

		public AddPort()
		{
			InitializeComponent();
			var ports = SerialPort.GetPortNames();
			foreach (var port in ports)
				comboBox1.Items.Add(port);

			comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				input = new SerialInput(comboBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to open Serial Port " + comboBox1.Text + "\n" + ex.Message);
			}

			this.Close();
		}

		public static SerialInput Show()
		{
			var dialog = new AddPort();
			dialog.ShowDialog();
			return dialog.input;
		}
	}
}
