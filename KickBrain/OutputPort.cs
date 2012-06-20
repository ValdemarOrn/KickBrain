using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public class OutputPort
	{
		public Signal InputSignal;

		public List<Event> Triggers;
		public List<Tuple<Signal, double>> CrosstalkSignals;

		public List<OutputDestination> Outputs;

		public int TriggerBlockMillis;
	}
}
