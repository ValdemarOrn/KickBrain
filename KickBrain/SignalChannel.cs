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

		public SignalChannel(string name)
		{
			Name = name;
			Mode = SignalMode.Add;

			Signals = new List<Signal>();

			// attention: Channel name and signal name are the same for SignalChannels
			Signals.Add(new Signal(this, name, GetValue));

			VelocityMap = new VelocityMap(4);
		}

		public string GetName()
		{
			return Name;
		}

		public double GetValue()
		{
			return 42;
		}

		public void Calculate(object sender)
		{

		}

	}
}
