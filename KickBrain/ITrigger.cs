using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public interface ITrigger
	{
		// Event that triggers when a trigger should be fired
		event Action Trigger;

	}
}
