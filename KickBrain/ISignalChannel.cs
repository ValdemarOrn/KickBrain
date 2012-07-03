using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	// A single channel generates multiple signals
	public interface ISignalChannel
	{
		string ChannelName { get; set; }

		List<Signal> Signals { get; }
		
	}
}
