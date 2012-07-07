using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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

		public SerialInput Input;
		public MidiOutput Output;
		public UI ui;

		public int ChannelCount
		{
			get { return (Input != null) ? Input.ChannelCount : 0; }
		}

		public int Baudrate
		{
			get { return (Input != null) ? Input.Baudrate : 115200; }
		}

		public string COMport
		{
			get { return (Input != null) ? Input.Name : ""; }
		}

		public int MidiDeviceID
		{
			get { return (Output != null) ? Output.DeviceID : -1; }
		}

		public string MidiDeviceName
		{
			get { return (Output != null) ? AudioLib.PortMidi.Pm_GetDeviceInfo(Output.DeviceID).name : ""; }
		}

		private Brain()
		{
			
		}

		public void Init()
		{
			Sources = new SourceManager();

			ui = new UI();
		}

		public void ShowError(string message)
		{
			MessageBox.Show("An error has occured: \n" + message);
		}

		public void SetNoInput(bool noInput)
		{
			ui.InputView.Ctrl.setNoInput(noInput);
		}

		public bool Configure()
		{
			var dialog = ConfigureDialog.Show(ChannelCount, Baudrate, COMport, MidiDeviceID);

			if (dialog.Connected)
			{
				SetNumberOfChannels(dialog.NumberOfChannels);

				// Open the serial interface
				OpenSerialInput(dialog.COMPort, dialog.BaudRate, dialog.NumberOfChannels);

				// open the midi device
				OpenMidiOutput(dialog.MidiDeviceID);
			}

			return dialog.Connected;
		}

		public void SetNumberOfChannels(int numChannels)
		{
			// Create or remove channels as needed
			while (Sources.InputChannels.Count < numChannels)
				Sources.AddInputChannel(new InputChannel(Sources.InputChannels.Count));
			while (Sources.InputChannels.Count > numChannels)
				Sources.RemoveInputChannel(Sources.InputChannels.Count - 1);

			ui.Ctrl.LoadInputs();
		}
		
		private void OpenSerialInput(string COMPort, int BaudRate, int NumberOfChannels)
		{
			if (Input != null)
				Input.Stop();

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
		}

		private void OpenMidiOutput(int DeviceID)
		{
			if (Output != null)
				Output.Close();

			AudioLib.PortMidi.Pm_CountDevices();

			if (DeviceID < 0)
			{
				ShowError("Illegal Device ID for Midi Output. ID: " + DeviceID);
				return;
			}

			try
			{
				var MidiOutput = new MidiOutput(DeviceID);
				Output = MidiOutput;
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		internal string ToXML()
		{
			XmlDocument doc = new XmlDocument();
			doc.PreserveWhitespace = false;
			
			var configNode = doc.CreateNode(XmlNodeType.Element, "Configuration", "");
			var tempNode = doc.CreateElement("temp");

			var GlobalConfigNode = doc.CreateNode(XmlNodeType.Element, "GlobalConfiguration", "");
			var inputConfigNode = doc.CreateNode(XmlNodeType.Element, "InputConfiguration", "");
			var outputConfigNode = doc.CreateNode(XmlNodeType.Element, "OutputConfiguration", "");

			configNode.AppendChild(GlobalConfigNode);
			configNode.AppendChild(inputConfigNode);
			configNode.AppendChild(outputConfigNode);
			doc.AppendChild(configNode);

			// Create global config
			GlobalConfigNode.InnerXml = String.Format("<InputName>{0}</InputName><MidiDeviceID>{1}</MidiDeviceID><Channels>{2}</Channels><Baudrate>{3}</Baudrate>", 
				COMport, MidiDeviceID, ChannelCount, Baudrate);

			// Create input config
			for (int i = 0; i < Sources.InputChannels.Count; i++)
			{
				
				var ch = (InputChannel)Sources.InputChannels[i];
				var serText = ch.ToXML();
				tempNode.InnerXml = serText;
				inputConfigNode.AppendChild(tempNode.ChildNodes[0]);
			}

			// Create output config
			var ports = Sources.GetOutputPorts();
			for (int i = 0; i < ports.Count; i++)
			{
				var port = ports[i];
				var serText = port.ToXML();
				tempNode.InnerXml = serText;
				outputConfigNode.AppendChild(tempNode.ChildNodes[0]);
			}

			return doc.OuterXml;
		}

		internal void FromXML(string xml)
		{
			var doc = new XmlDocument();
			doc.LoadXml(xml);
			string comPort = doc.SelectSingleNode("Configuration/GlobalConfiguration/InputName").InnerText;

			int midiDeviceId = -1;
			Int32.TryParse(doc.SelectSingleNode("Configuration/GlobalConfiguration/MidiDeviceID").InnerText, out midiDeviceId);

			int channelCount = 12;
			Int32.TryParse(doc.SelectSingleNode("Configuration/GlobalConfiguration/Channels").InnerText, out channelCount);

			int baudrate = 115200;
			Int32.TryParse(doc.SelectSingleNode("Configuration/GlobalConfiguration/Baudrate").InnerText, out baudrate);

			SetNumberOfChannels(channelCount);
			OpenSerialInput(comPort, baudrate, channelCount);

			OpenMidiOutput(midiDeviceId);

			// Load input config

			for (int i = 0; i < ChannelCount; i++)
			{
				var node = doc.SelectSingleNode("Configuration/InputConfiguration/Input[@Index='" + i + "']");
				if (node == null)
					continue;
				((InputChannel)Sources.InputChannels[i]).LoadXML(node.OuterXml);
			}

			var ports = Sources.GetOutputPorts();
			foreach (var port in ports)
				Sources.RemoveOutputPort(port);

			var nodes = doc.SelectNodes("Configuration/OutputConfiguration/Output");

			for (int i = 0; i < nodes.Count; i++)
			{
				var outputPort = new OutputPort();
				outputPort.LoadXML(nodes[i].OuterXml);
				Sources.AddOutputPort(outputPort);
			}


		}
	}
}
