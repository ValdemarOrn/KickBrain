using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface IInput : ISignalChannel, IEventChannel
	{
		string ChannelName { get; set; }

		object Config { get; set; }

		void ConfigUpdated();

		void AddData(int data);
	}
}
