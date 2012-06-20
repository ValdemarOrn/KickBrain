using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface IEventChannel
	{
		string ChannelName { get; }
		List<Event> Events { get; }

	}
}
