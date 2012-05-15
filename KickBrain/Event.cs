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
		public object Owner { get; set; }
		public string Name { get; set; }

		List<Action<object>> Actions;

		public Event(object owner, string name)
		{
			Owner = owner;
			Name = name;

			Actions = new List<Action<object>>();
		}

		/// <summary>
		/// Adds a new delegate to be called by the event when it is invoked
		/// </summary>
		/// <param name="dele"></param>
		public void Add(Action<object> dele)
		{
			lock (lockObject)
			{
				Actions.Add(dele);
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
			lock (lockObject)
			{
				foreach (var del in Actions)
				{
					del(sender);
				}
			}
		}
	}
}
