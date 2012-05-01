using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace KickBrain
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

		public void Start()
		{
			Stopping = false;
			CurrentChannel = -9999;
			port.ReadTimeout = 10;
			var t = new Thread(new ThreadStart(Receive));
			t.Start();
		}

		public void Stop()
		{
			Stopping = true;
			lock (Lock)
			{
				port.Close();
				return;
			}
		}

		public bool Stopping;
		object Lock = new object();

		// data rate
		DateTime StartTime;
		int PerSecond;

		int CurrentChannel;

		protected void Receive()
		{
			lock (Lock)
			{
				while (!Stopping)
				{
					byte[] buf = new byte[ChannelCount + 1];
					int count = port.Read(buf, 0, ChannelCount + 1);

					if (count != ChannelCount + 1)
						continue;

					// Data rate
					PerSecond += count;
					if ((DateTime.Now - StartTime).TotalMilliseconds >= 1000)
					{
						KickBrain.KB.ui.Ctrl.SetSamplerate((int)(((double)PerSecond) / (ChannelCount + 1)));
						KickBrain.KB.ui.Ctrl.SetByterate(PerSecond);
						//Console.WriteLine("Bytes per sec: " + PerSecond + ", Samplerate: " + (PerSecond / (ChannelCount + 1)));
						PerSecond = 0;
						StartTime = DateTime.Now;
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
}
