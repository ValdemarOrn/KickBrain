using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public class OutputDestination
	{
		public int MidiChannel;
		public int CCNumber;
		public bool IsNote;
		public Signal Filter;
		public double FilterMin;
		public double FilterMax;

		public OutputDestination()
		{ 
			
		}

		public void Send(double value)
		{
			if (Filter != null)
			{
				var filterVal = Filter.SignalDelegate();
				if (filterVal < FilterMin || filterVal > FilterMax)
					return;
			}

			// else, send midi!
			// todo: implement
		}
	}
}
