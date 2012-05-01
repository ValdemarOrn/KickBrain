using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public class Buffer
	{
		public double[] Data;
		int i;

		public Buffer(int len)
		{
			Data = new double[len];
			i = 0;
		}

		public void Add(double sample)
		{
			i = (i + 1) % Data.Length;
			Data[i] = sample;
		}

		public int GetIndex(int offset)
		{
			int x = (i - offset + 1000 * Data.Length) % Data.Length;
			return x;
		}

		public double GetSample(int offset)
		{
			return Data[GetIndex(offset)];
		}

		public double GetMax(int offset)
		{
			int x = GetIndex(offset);
			double max = double.MinValue;
			while (true)
			{
				if (Data[x] > max)
					max = Data[x];

				if (x == i)
					break;
				else
					x = (x + 1) % Data.Length;
			}

			return max;
		}
	}
}
