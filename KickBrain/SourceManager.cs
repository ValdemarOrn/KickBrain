using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	/// <summary>
	/// This class takes care of maintaining a list of all signal generators and trigger generators (sources)
	/// that are available. It has methods to query, add, reorder and remove sources
	/// </summary>
	public class SourceManager
	{
		// All IChannels
		List<IChannel> Signals;

		// All ITriggers
		List<ITrigger> Triggers;

		public SourceManager()
		{
			Signals = new List<IChannel>();
			Triggers = new List<ITrigger>();
		}

		public void AddChannel(IChannel channel)
		{
			Signals.Add(channel);
		}

		public void AddTrigger(ITrigger trigger)
		{
			Triggers.Add(trigger);
		}

		public void SetChannelIndex(IChannel channel, int newIndex)
		{
			if (!Signals.Contains(channel))
				KickBrain.KB.ShowError("This channel is not registered in the Channel Manager!");
		}
	}
}
