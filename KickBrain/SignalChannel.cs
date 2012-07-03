using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioLib;

namespace KickBrain
{
	
	public class SignalChannel : ISignalChannel
	{
		// IChannel
		public List<Signal> Signals { get; private set; }

		public string Name;
		public SignalMode Mode;
		public Signal InputA;
		public Signal InputB;
		public Event Trigger;
		public double Min;
		public double Max;
		public VelocityMap VelocityMap;

		double Output;

		public SignalChannel(string name)
		{
			Name = name;
			Mode = SignalMode.Add;

			Signals = new List<Signal>();

			// attention: Channel name and signal name are the same for SignalChannels
			Signals.Add(new Signal(this, name, GetValue));

			VelocityMap = new VelocityMap(4);
		}

		public string ChannelName
		{
			get { return Name; }
			set { Name = value; }
		}

		public double GetValue()
		{
			return Output;
		}

		public void Process(object sender)
		{
			var input = (IInput)sender;
			double sig = input.Signals[0].SignalDelegate();
			Console.WriteLine("Signal triggered on channel " + ChannelName + ": " + sig);

			var a = InputA.SignalDelegate();
			var b = InputB.SignalDelegate();

			if (Mode == SignalMode.Add)
			{
				Output = a + b;
			}
			else if (Mode == SignalMode.Difference)
			{
				Output = Math.Abs(a - b);
			}
			else if (Mode == SignalMode.Divide)
			{
				if (b == 0.0)
					Output = Double.MaxValue;
				else
					Output = a / b;
			}
			else if (Mode == SignalMode.Maximum)
			{
				Output = (a > b) ? a : b;
			}
			else if (Mode == SignalMode.Minimum)
			{
				Output = (a < b) ? a : b;
			}
			else if (Mode == SignalMode.Multiply)
			{
				Output = a * b;
			}
			else if (Mode == SignalMode.Subtract)
			{
				Output = a - b;
			}

		}

	}
}
