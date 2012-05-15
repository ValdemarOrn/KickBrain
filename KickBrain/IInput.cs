using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface IInput : ISignalChannel, IEventChannel
	{
		object Config { get; set; }

		void ConfigUpdated();

		void AddData(int data);
	}
}
