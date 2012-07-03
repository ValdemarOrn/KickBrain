using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	// A container, pairing a single trigger with its parent channel, a name and the actual event
	// each ITrigger has a List of triggers.
	public class Event
	{
		public IEventChannel Owner { get; set; }
		public string Name { get; set; }

		List<Action<object>> Actions;

		// used to pair action delegates to signalchannels
		Dictionary<Action<object>, ISignalChannel> SignalChannelObjects;

		/// <summary>
		/// This dictionary is used to pair up action delegates and another delegate which returns
		/// the "rank" of the action delegate. This is used to call action delegates in a specific order
		/// Note: Only signalChannels are actually ranked, anything else (UI events, output events etc) don't
		/// depend on any specific order, except they depend on being called AFTER all signalchannels have been processed
		/// </summary>
		public Func<ISignalChannel, int> OrderByDelegate;

		public Event(IEventChannel owner, string name)
		{
			Owner = owner;
			Name = name;

			Actions = new List<Action<object>>();
			SignalChannelObjects = new Dictionary<Action<object>, ISignalChannel>();
			OrderByDelegate = Brain.KB.Sources.GetSignalChannelIndex;
		}

		/// <summary>
		/// Adds a new delegate to be called by the event when it is invoked
		/// </summary>
		/// <param name="dele">a delegate to be called when the action is invoked</param>
		/// <param name="actionObject">the object that contains the delegate. Used to set the order in which the delegates are called</param>
		public void Add(Action<object> dele, ISignalChannel actionObject)
		{
			lock (lockObject)
			{
				Actions.Add(dele);
				SignalChannelObjects[dele] = actionObject;
			}
		}

		/// <summary>
		/// Removes a delegate from the list of delegates to be called, if it is on the list
		/// </summary>
		/// <param name="dele"></param>
		public void Remove(Action<object> dele)
		{
			lock (lockObject)
			{
				if (SignalChannelObjects.ContainsKey(dele))
					SignalChannelObjects.Remove(dele);

				if (Actions.Contains(dele))
					Actions.Remove(dele);
			}
		}

		object lockObject = new object();

		/// <summary>
		/// Invokes the event and calls all delegates
		/// </summary>
		/// <param name="sender"></param>
		public void Invoke(object sender)
		{

			// We use the orderByDelegate to order all the actions.
			// we use the SignalChannelObjects to find which object corresponds to which delegate
			// Todo: Fix this, it's a bottleneck!
			List<Action<object>> orderedList = Actions.OrderBy(x => OrderByDelegate(SignalChannelObjects[x])).ToList();

			foreach (var del in orderedList)
			{
				del(sender);
			}
		}

		public string ToXML()
		{
			return String.Format("<Event><Name>{0}</Name><Owner>{1}</Owner></Event>", Name, Owner.ChannelName);
		}
	}
}
