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
		// All ISignalChannels
		List<ISignalChannel> Channels;

		// All ITriggerChannels
		List<IEventChannel> Triggers;

		public SourceManager()
		{
			Channels = new List<ISignalChannel>();
			Triggers = new List<IEventChannel>();
		}

		public List<ISignalChannel> GetChannels()
		{
			// returns a shallow copy
			return Channels.Select(x => x).ToList();
		}

		public void AddChannel(ISignalChannel channel)
		{
			Channels.Add(channel);
		}

		public List<IEventChannel> GetTriggers()
		{
			// returns a shallow copy
			return Triggers.Select(x => x).ToList();
		}

		public void AddTrigger(IEventChannel trigger)
		{
			Triggers.Add(trigger);
		}

		public void SetChannelIndex(ISignalChannel channel, int newIndex)
		{
			if (!Channels.Contains(channel))
				Brain.KB.ShowError("This channel is not registered in the Channel Manager!");
		}
	}
}
