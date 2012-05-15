using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public class SignalMode
	{
		string[] strings = new string[] { "Add", "Subtract", "Multiply", "Divide", "Minumum", "Maximum", "Difference" };

		public static readonly SignalMode Add = new SignalMode(0);
		public static readonly SignalMode Subtract = new SignalMode(1);
		public static readonly SignalMode Multiply = new SignalMode(2);
		public static readonly SignalMode Divide = new SignalMode(3);
		public static readonly SignalMode Minimum = new SignalMode(4);
		public static readonly SignalMode Maximum = new SignalMode(5);
		public static readonly SignalMode Difference = new SignalMode(6);
		
		public static readonly List<SignalMode> Modes = new List<SignalMode>() { Add, Subtract, Multiply, Divide, Minimum, Maximum, Difference };
		
		int value;

		private SignalMode(int val)
		{
			value = val;
		}

		public override string ToString()
		{
			return strings[value];
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() == typeof(SignalMode))
				if (((SignalMode)obj).value == this.value)
					return true;

			return false;
		}

		public static bool operator ==(SignalMode a, SignalMode b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(SignalMode a, SignalMode b)
		{
			return !a.Equals(b);
		}

	}
}
