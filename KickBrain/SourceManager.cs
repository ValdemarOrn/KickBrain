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
		// All IInputs
		public List<IInput> InputChannels;

		// All ISignalChannels
		List<ISignalChannel> SignalChannels;

		// All ITriggerChannels
		List<IEventChannel> EventChannels;

		// All OutputPorts
		List<OutputPort> OutputPorts;

		public SourceManager()
		{
			InputChannels = new List<IInput>();
			SignalChannels = new List<ISignalChannel>();
			EventChannels = new List<IEventChannel>();
			OutputPorts = new List<OutputPort>();
		}


		// ------------ Input Channels ------------

		public void AddInputChannel(IInput input)
		{
			if (InputChannels.Contains(input))
				return;

			InputChannels.Add(input);
		}

		public void RemoveInputChannel(int index)
		{
			if(InputChannels.Count > index)
				InputChannels.RemoveAt(index);
		}


		// ------------ Signal Channels ------------

		public void AddSignalChannel(ISignalChannel channel)
		{
			if (SignalChannels.Contains(channel))
				return;

			SignalChannels.Add(channel);
		}

		public List<ISignalChannel> GetSignalChannels()
		{
			// returns a shallow copy
			return SignalChannels.Select(x => x).ToList();
		}

		public bool SetChannelName(ISignalChannel channel, string name)
		{
			if (channel.ChannelName == name)
				return true;

			var channels = Brain.KB.Sources.GetSignalChannels();
			bool contains = channels.Any(x => x.ChannelName == name);
			if (contains)
			{
				Brain.KB.ShowError("There is already a channel with the name " + name + ".\nNames must be unique, please select another one.");
				return false;
			}
			else
			{
				channel.ChannelName = name;
				return true;
			}
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
			if (EventChannels.Contains(trigger))
				return;

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

		/// <summary>
		/// Detaches the specified delegate from any and all events registered with this source manager
		/// </summary>
		/// <param name="dele"></param>
		public void DetachAllEvents(Action<object> dele)
		{
			GetAllEvents().ForEach(x => x.Remove(dele));
		}


		// ------------------- Output Ports ------------------

		public void AddOutputPort(OutputPort port)
		{
			if (OutputPorts.Contains(port))
				return;

			OutputPorts.Add(port);
		}

		public List<OutputPort> GetOutputPorts()
		{
			// returns a shallow copy
			return OutputPorts.Select(x => x).ToList();
		}

		public void RemoveOutputPort(OutputPort port)
		{
			if (!OutputPorts.Contains(port))
				return;

			OutputPorts.Remove(port);
			port.Dispose();
		}
		
	}
}
