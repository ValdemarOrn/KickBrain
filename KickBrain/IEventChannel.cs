using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface IEventChannel
	{
		string GetName();
		// Event that triggers when a trigger should be fired
		List<Event> Triggers { get; }

	}
}
