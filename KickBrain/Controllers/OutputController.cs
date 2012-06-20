using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KickBrain.Views;

namespace KickBrain.Controllers
{
	public class OutputController
	{
		public OutputView ui;

		SignalChannel CurrentChannel;
		List<SignalChannel> Channels;



		public OutputController(OutputView form)
		{
			this.ui = form;
			Channels = new List<SignalChannel>();
		}

		
	}
}
