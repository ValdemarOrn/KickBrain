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
		List<ISignalChannel> SignalChannels;

		// All ITriggerChannels
		List<IEventChannel> EventChannels;

		public SourceManager()
		{
			SignalChannels = new List<ISignalChannel>();
			EventChannels = new List<IEventChannel>();
		}


		// ------------ Channels ------------

		public void AddSignalChannel(ISignalChannel channel)
		{
			SignalChannels.Add(channel);
		}

		public List<ISignalChannel> GetSignalChannels()
		{
			// returns a shallow copy
			return SignalChannels.Select(x => x).ToList();
		}

		/// <summary>
		/// Get all signals of all channels
		/// </summary>
		/// <returns></returns>
		public List<Signal> GetAllSignals()
		{
			var output = new List<Signal>();
			foreach(var channel in SignalChannels)
			{
				foreach(var signal in channel.Signals)
				{
					output.Add(signal);
				}
			}

			return output;
		}

		public void SetSignalChannelIndex(ISignalChannel channel, int newIndex)
		{
			if (!SignalChannels.Contains(channel))
				Brain.KB.ShowError("This channel is not registered in the Channel Manager!");
		}

		public int GetSignalChannelIndex(ISignalChannel channel)
		{
			if (channel == null)
				return 99999;
			if (!SignalChannels.Contains(channel))
				return 99999;
			else
				return SignalChannels.IndexOf(channel);
		}

		// ------------ Triggers ------------

		public void AddTriggerChannel(IEventChannel trigger)
		{
			EventChannels.Add(trigger);
		}

		public List<IEventChannel> GetTriggerChannels()
		{
			// returns a shallow copy
			return EventChannels.Select(x => x).ToList();
		}

		/// <summary>
		/// Get all signals of all channels
		/// </summary>
		/// <returns></returns>
		public List<Event> GetAllEvents()
		{
			var output = new List<Event>();
			foreach (var channel in EventChannels)
			{
				foreach (var signal in channel.Events)
				{
					output.Add(signal);
				}
			}

			return output;
		}

		
	}
}
