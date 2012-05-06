using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface IInput : IChannel, ITrigger
	{
		/// Event that triggers when new data is available on the channel
		event Action DataEvent;

		object Config { get; set; }

		void ConfigUpdated();

		void AddData(int data);
	}
}
