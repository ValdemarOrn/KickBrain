using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KickBrain
{
	class SerialInputMock : SerialInput
	{
		public override void Connect(string portName, int baud, int channelCount)
		{
			Name = portName;
			Baudrate = baud;
			ChannelCount = channelCount;
		}

		long kk = 0;
		DateTime lastTrig;
		Random r = new Random();
		protected override void Receive()
		{
			while (!Stopping)
			{
				Thread.Sleep(1);
				byte[] buf = new byte[10 + 1];


				// Data rate
				PerSecond += buf.Length;
				if ((DateTime.Now - StartTime).TotalMilliseconds >= 1000)
				{
					Brain.KB.ui.InputView.Ctrl.SetSamplerate((int)(((double)PerSecond) / (ChannelCount + 1)));
					Brain.KB.ui.InputView.Ctrl.SetByterate(PerSecond);
					//Console.WriteLine("Bytes per sec: " + PerSecond + ", Samplerate: " + (PerSecond / (ChannelCount + 1)));
					PerSecond = 0;
					StartTime = DateTime.Now;
				}

				for (int i = 0; i < buf.Length; i++)
				{
					buf[i] = (byte)r.Next(1,4);
				}

				buf[9] = (byte)((Math.Sin(0.005 * kk)+1)*127);
				kk++;

				if (DateTime.Now > lastTrig.AddSeconds(1))
				{
					lastTrig = DateTime.Now;
					buf[0] = 240;
				}

				for (int i = 0; i < Brain.KB.Sources.InputChannels.Count && i < buf.Length; i++)
				{
					Brain.KB.Sources.InputChannels[i].AddData(buf[i]);
				}
			}
		}
	}
}
