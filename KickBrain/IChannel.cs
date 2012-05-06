using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface IChannel
	{
		string GetName();
		Dictionary<string, Func<double>> Values { get; }
		
	}
}
