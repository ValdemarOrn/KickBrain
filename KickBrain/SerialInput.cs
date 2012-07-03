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

		public string Name { get; protected set; }
		public int ChannelCount { get; protected set; }
		public int Baudrate { get; protected set; }

		public SerialInput()
		{ 

		}

		public virtual void Connect(string portName, int baud, int channelCount)
		{
			port = new SerialPort();


			Name = portName;
			ChannelCount = channelCount;
			Baudrate = baud;

			port.PortName = portName;

			port.BaudRate = baud;
			port.Parity = Parity.None;
			port.DataBits = 8;
			port.StopBits = StopBits.One;
			port.Handshake = Handshake.None;

			port.Open();
		}

		public void Start()
		{
			Stopping = false;
			CurrentChannel = -9999;
			var t = new Thread(new ThreadStart(Receive));
			t.Start();
		}

		public void Stop()
		{
			Stopping = true;
			lock (Lock)
			{
				if(port != null)
					port.Close();

				return;
			}
		}

		protected bool Stopping;
		object Lock = new object();

		// data rate
		protected DateTime StartTime;
		protected int PerSecond;

		int CurrentChannel;

		protected virtual void Receive()
		{
			lock (Lock)
			{
				port.ReadTimeout = 10;

				while (!Stopping)
				{
					byte[] buf = new byte[ChannelCount + 1];
					int count = port.Read(buf, 0, ChannelCount + 1);

					// Data rate
					PerSecond += count;
					if ((DateTime.Now - StartTime).TotalMilliseconds >= 1000)
					{
						Brain.KB.ui.InputView.Ctrl.SetSamplerate((int)(((double)PerSecond) / (ChannelCount + 1)));
						Brain.KB.ui.InputView.Ctrl.SetByterate(PerSecond);
						//Console.WriteLine("Bytes per sec: " + PerSecond + ", Samplerate: " + (PerSecond / (ChannelCount + 1)));
						PerSecond = 0;
						StartTime = DateTime.Now;
					}

					bool foundZero = false;
					for (int i = 0; i < count; i++ )
					{
						int recv = buf[i];

						if (recv == 0 && foundZero)
						{
							int k = 25;
						}

						if (recv == 0)
							foundZero = true;

						if (recv == 0)
						{
							CurrentChannel = 0;
						}
						else if (CurrentChannel < 0)
						{
							continue;
						}
						else if (CurrentChannel < Brain.KB.Sources.InputChannels.Count)
						{
							Brain.KB.Sources.InputChannels[CurrentChannel].AddData(recv);
							CurrentChannel++;
						}
					}
				}
			}
		}
	}
}
