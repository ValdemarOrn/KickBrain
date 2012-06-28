﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KickBrain
{
	/// <summary>
	/// Singleton class that glues the thing together.
	/// </summary>
	public class Brain
	{
		#region singleton
		
		static Brain Instance;
		static object LockObject = new object();
		public static Brain KB
		{
			get
			{
				lock (LockObject)
				{
					if (Instance == null)
					{
						Instance = new Brain();
						Instance.Init();
					}

					return Instance;
				}
			}
		}

		#endregion
		// ---------------------------------

		public SourceManager Sources;

		public List<IInput> InputChannels;

		public SerialInput Input;
		public MidiOutput Output;
		public UI ui;
		public Config Config;

		private Brain()
		{
			
		}

		public void Init()
		{
			Sources = new SourceManager();

			ui = new UI();
			Config = new Config(@"KickBrain.json");
			Config.Load();

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

		public bool Configure()
		{
			if (Input != null)
				Input.Stop();

			if (Output != null)
				Output.Close();

			var dialog = ConfigureDialog.Show();

			if (dialog.Connected)
			{
				// Create the Channels
				InputChannels = new List<IInput>();
				int i = 0;
				while (InputChannels.Count < dialog.NumberOfChannels)
					InputChannels.Add(new InputChannel(i++));

				// Open the serial interface
				OpenSerialInput(dialog.COMPort, dialog.BaudRate, dialog.NumberOfChannels);

				// open the midi device
				OpenMidiOutput(dialog.MidiDeviceID);

				Config.Save();

				ConnectEvents();
			}

			return dialog.Connected;
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

		private void OpenSerialInput(string COMPort, int BaudRate, int NumberOfChannels)
		{
			if (COMPort == null || COMPort == "")
			{
				ShowError("Illegal COM Port name: " + COMPort);
				return;
			}

			SerialInput SerialInput = null;
			try
			{
				SerialInput = new SerialInputMock();
				SerialInput.Connect(COMPort, BaudRate, NumberOfChannels);
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
		}

		// hard connections between inputChannel triggers and midioutput
		// To be replaced by the flexible routing system
		private void ConnectEvents()
		{
			if (Output == null || Input == null)
				return;

			// connect the trigger events of the inputs to the output
//			foreach (var inp in Input.Channels)
//				inp.TriggerEvent += Output.TriggerEvent;
		}
	}
}
