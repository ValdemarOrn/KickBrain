using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialAudio
{
	public class WaveChannelConfig
	{
		public bool Enabled;

		public double HighpassFrequency;

		public double DecayRate;

		public double Gain;
		public double NoiseFloor;

		public int TriggerAttack;
		public int TriggerLength;
		public double TriggerThreshold;
		public double TriggerScale;
		public int TriggerRetrigger;

		public bool DecayEnabled;
		public bool HighpassEnabled;

		public WaveChannelConfig()
		{
			HighpassFrequency = 0.05;
			DecayRate = 0.997;
			Gain = 1.0;
			NoiseFloor = 0.02;

			TriggerThreshold = 0.02;
			TriggerAttack = 4;
			TriggerLength = 10;
			TriggerScale = 1.25;
			TriggerRetrigger = 25;

			HighpassEnabled = true;
			DecayEnabled = true;

			Enabled = true;
		}
	}
}
