using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	// A container, pairing a single signal with its parent channel, a name and the actual signal delegate
	// each IChannel has a List of signals.
	public class Signal
	{
		public ISignalChannel Owner { get; set; }
		
		public string Name { get; set; }

		public Func<double> SignalDelegate { get; set; }

		public Signal(ISignalChannel owner, string name, Func<double> dele)
		{
			Owner = owner;
			Name = name;
			SignalDelegate = dele;
		}

		public string ToXML()
		{
			return String.Format("<Signal><Name>{0}</Name><Owner>{1}</Owner></Signal>", Name, Owner.ChannelName);
		}
	}
}
