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
			ChannelCount = channelCount;
		}

		DateTime lastTrig;
		Random r = new Random();
		protected override void Receive()
		{
			while (true)
			{
				Thread.Sleep(1);
				byte[] buf = new byte[8 + 1];

				for (int i = 0; i < buf.Length; i++)
				{
					buf[i] = (byte)r.Next(1,4);
				}

				if (DateTime.Now > lastTrig.AddSeconds(1))
				{
					lastTrig = DateTime.Now;
					buf[0] = 240;
				}

				for (int i = 0; i < Brain.KB.InputChannels.Count && i < buf.Length; i++)
				{
					Brain.KB.InputChannels[i].AddData(buf[i]);
				}
			}
		}
	}
}
