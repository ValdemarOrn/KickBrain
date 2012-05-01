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
			ui = new UI();
		}

		public SerialInput Input;
		public MidiOutput Output;

		public UI ui;

		public void Configure()
		{
			if (Input != null)
				Input.Stop();

			if (Output != null)
				Output.Close();

			var dialog = AddPortDialog.Show();
			if (dialog.SerialInput == null || dialog.MidiOutput == null)
				return;

			Input = dialog.SerialInput;
			Input.Start();

			Output = dialog.MidiOutput;
			
		}
	}
}
