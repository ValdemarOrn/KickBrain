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
		public double LowpassFrequency;

		public double SlewRate;
		public double SlewFactor;

		public double Gain;
		public double Threshold;

		public int TriggerHold;
		public double TriggerThreshold;
		public double TriggerFactor;
		public int TriggerBlock;

		public bool SlewRateEnabled;
		public bool SlewFactorEnabled;
		public bool LowpassEnabled;
		public bool HighpassEnabled;
		public bool CurveEnabled;

		public WaveChannelConfig()
		{
			HighpassFrequency = 0.05;
			LowpassFrequency = 0.2;
			SlewRate = 0.997;
			Gain = 1.0;
			Threshold = 0.02;
			SlewFactor = 1.2;

			TriggerThreshold = 0.02;
			TriggerHold = 100;
			TriggerFactor = 1.4;
			TriggerBlock = 200;

			HighpassEnabled = true;
			LowpassEnabled = false;
			CurveEnabled = false;
			SlewRateEnabled = true;
			SlewFactorEnabled = false;

			Enabled = true;
		}
	}
}
