using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialAudio
{
	public class KickBrain
	{
		static KickBrain Instance;

		public static KickBrain KB
		{
			get
			{
				if (Instance == null)
					Instance = new KickBrain();

				return Instance;
			}
		}

		// ---------------------------------

		private KickBrain()
		{
			Inputs = new List<SerialInput>();
			ui = new UI();
		}

		public List<SerialInput> Inputs;

		public UI ui;

		public void AddInput()
		{
			var input = AddPort.Show();
			if (input == null)
				return;

			foreach (WaveChannel channel in input.Channels)
				ui.Ctrl.AddWiew(channel);

			input.StartReceive();

			// initialize processing values
			ui.WaveTabs_SelectedIndexChanged(null, null);
		}
	}
}
