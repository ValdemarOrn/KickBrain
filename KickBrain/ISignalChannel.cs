using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	// A single channel generates multiple signals
	public interface ISignalChannel
	{
		string ChannelName { get; }
		List<Signal> Signals { get; }
		
	}
}
