using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace SerialAudio
{
	public class SerialInput
	{
		public static string FullName(string COMName)
		{
			var searcher = new System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");

			foreach (var queryObj in searcher.Get())
			{
				if (queryObj["Caption"].ToString().Contains("(COM"))
				{
					string name = (string)queryObj["Caption"];
					if (name.Contains(COMName))
						return name;
				}
			}

			return "";
		}

		SerialPort port;

		public List<WaveChannel> Channels;
		public string Name { get; private set; }
		public int ChannelCount { get; private set; }
		public int SampleRate { get; private set; }

		public SerialInput(string portName, int baud, int sampleRate, int channelCount)
		{
			port = new SerialPort();

			Channels = new List<WaveChannel>();
			Name = portName;
			ChannelCount = channelCount;
			SampleRate = sampleRate;

			port.PortName = portName;

			port.BaudRate = baud;
			port.Parity = Parity.None;
			port.DataBits = 8;
			port.StopBits = StopBits.One;
			port.Handshake = Handshake.None;

			port.Open();

			// set the channel number on the Arduino
			sampleRate = (int)(sampleRate / 50.0);
			if (sampleRate > 100)
				sampleRate = 100;
			sampleRate += 128; // set the top bit to true

			port.Write(new byte[] { (byte)channelCount, (byte)sampleRate }, 0, 2);

			// Create the Channels
			int i = 0;
			while (Channels.Count < ChannelCount)
				Channels.Add(new WaveChannel(this, i++));
		}

		public void StartReceive()
		{
			CurrentChannel = -9999;
			var t = new Thread(new ThreadStart(Receive));
			t.Start();
			
			//port.DataReceived += new SerialDataReceivedEventHandler(Receive);
			
		}

		// data rate
		DateTime Start;
		int PerSecond;

		int CurrentChannel;

		public void Receive()
		{
			while (true)
			{
				byte[] buf = new byte[ChannelCount + 1];
				int count = port.Read(buf, 0, ChannelCount + 1);

				// Data rate
				PerSecond += count;
				if ((DateTime.Now - Start).TotalMilliseconds >= 1000)
				{
					Console.WriteLine("Bytes per sec: " + PerSecond + ", Samplerate: " + (PerSecond / (ChannelCount + 1)));
					PerSecond = 0;
					Start = DateTime.Now;
				}

				foreach (int recv in buf)
				{
					if (recv == 0)
					{
						CurrentChannel = 0;
					}
					else if (CurrentChannel < 0)
					{
						continue;
					}
					else if (CurrentChannel < Channels.Count)
					{
						Channels[CurrentChannel].AddData(recv);
						CurrentChannel++;
					}
				}
			}
		}
	}
}
