using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KickBrain
{
	public class KickBrain
	{
		static KickBrain Instance;
		static object LockObject = new object();

		public static KickBrain KB
		{
			get
			{
				lock (LockObject)
				{
					if (Instance == null)
						Instance = new KickBrain();

					return Instance;
				}
			}
		}

		// ---------------------------------

		private KickBrain()
		{
			ui = new UI();
			Config = new Config(@"KickBrain.json");
			Config.Load();
			Init();
		}

		public SerialInput Input;
		public MidiOutput Output;

		public UI ui;

		public Config Config;

		public void Init()
		{
			/*var ComPort = Config.Get<string>("Input.COMPort");
			var baud = (int)Config.Get<double>("Input.BaudRate");
			var numChannels = Config.Get<int>("Input.NumberOfChannels");
			var samplerate = Config.Get<int>("Input.SampleRate");

			if (ComPort != null && ComPort.Length > 0 && baud > 0 && numChannels > 0 && samplerate > 0)
			{
				OpenSerialInput(ComPort, baud, numChannels, samplerate);
			}

			var devID = Config.Get<int?>("Output.DeviceID");
			if (devID != null && devID >= 0)
			{
				OpenMidiOutput((int)devID);
			}

			ConnectEvents();*/
		}

		public void ShowError(string message)
		{
			MessageBox.Show("An error has occured: \n" + message);
		}

		public void Configure()
		{
			if (Input != null)
				Input.Stop();

			if (Output != null)
				Output.Close();

			var dialog = AddPortDialog.Show();

			OpenSerialInput(dialog.COMPort, dialog.BaudRate, dialog.NumberOfChannels, dialog.SampleRate);
			OpenMidiOutput(dialog.MidiDeviceID);

			Config.Save();

			ConnectEvents();
		}

		private void OpenMidiOutput(int DeviceID)
		{
			if (DeviceID < 0)
			{
				ShowError("Illegal Device ID for Midi Output. ID: " + DeviceID);
				return;
			}

			try
			{
				var MidiOutput = new MidiOutput(DeviceID);
				Output = MidiOutput;

				Config.Set("Output.DeviceID", DeviceID);
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		private void OpenSerialInput(string COMPort, int BaudRate, int NumberOfChannels, int SampleRate)
		{
			SerialInput SerialInput = null;
			try
			{
				SerialInput = new SerialInput(COMPort, BaudRate, SampleRate, NumberOfChannels);
			}
			catch (Exception ex)
			{
				if (SerialInput != null)
					SerialInput.Stop();

				ShowError("Unable to open Serial Port " + COMPort + "\n" + ex.Message);
				return;
			}

			Input = SerialInput;
			Input.Start();

			Config.Set("Input.COMPort", COMPort);
			Config.Set("Input.BaudRate", BaudRate);
			Config.Set("Input.NumberOfChannels", NumberOfChannels);
			Config.Set("Input.SampleRate", SampleRate);
		}

		private void ConnectEvents()
		{
			if (Output == null)
				return;

			// connect the trigger events of the inputs to the output
			foreach (var inp in Input.Channels)
				inp.TriggerEvent += Output.TriggerEvent;
		}

	}
}
