using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SerialAudio
{
	[Serializable]
	public class WaveChannel
	{
		//public List<double> Data;
		[XmlIgnore]
		public SerialInput Input;

		public int Channel;

		/// Event that triggers when new data is available on the channel
		public event Action<WaveChannel, double> DataEvent;
		// Event that triggers when a trigger should be fired
		public event Action<WaveChannel, double> TriggerEvent;

		public WaveChannel(SerialInput input, int channel)
		{
			Input = input;
			Channel = channel;
			//Data = new List<double>();
			hp = new AudioLib.TF.Highpass1(2);
			lp = new AudioLib.TF.Lowpass1(2);

			Config = new WaveChannelConfig();
		}

		double lastValue;

		// the number of samples remaining from the time the trigger went off
		// the signal strength in this time period is used to calculate the velocity of the hit
		int triggerTime;

		// the power of the current hit.
		double triggerPower;

		public void AddData(int data)
		{
			double value = data / 256.0;
				
			if(Config.HighpassEnabled)
				value = hp.process(value);

			//var power = Math.Abs(value); // used for trigger power

			value = Math.Abs(value); // Rectify

			if (Config.CurveEnabled)
			{
				double curve = 3 - 3 * (Math.Log(value + 0.1) + 1) + 1;
				value = value * curve;
			}

			value = value * Config.Gain;

			if (Config.LowpassEnabled)
				value = lp.process(value);

			if (value < Config.Threshold)
				value = 0;

			double unslewed = value;

			// SlewFactor prevents spikes in the signal unless they are larger than some factor of the previous sample
			if (Config.SlewFactorEnabled)
			{
				if ((value / lastValue) < Config.SlewFactor)
					value = lastValue;
			}

			// SlewRate prevents the signal from decreasing by more than a specified amount between each sample
			if (Config.SlewRateEnabled)
			{
				if (value < (lastValue * Config.SlewRate))
					value = lastValue * Config.SlewRate;
			}

			

			// -------------------Trigger sensor---------------------------

			if (((value - lastValue) >= Config.TriggerThreshold) && ((value / lastValue) >= Config.TriggerFactor) && ((triggerTime + Config.TriggerBlock) < 0))
			{
				triggerTime = Config.TriggerHold + 1;
				triggerPower = 0;
			}

			// if triggering, measure power and decrement timer
			if (triggerTime > 0)
			{
				triggerPower = (value >= triggerPower) ? value : triggerPower;
				triggerTime--;

				if (triggerTime == 0 && Config.Enabled)
					TriggerEvent(this, triggerPower);
			}
			else
			{
				triggerTime--;
			}

			// turn off
			if ((triggerTime + Config.TriggerBlock) <= 0 && value < Config.TriggerThreshold && triggerPower > 0.0)
			{
				triggerPower = 0.0;
				if (Config.Enabled)
					TriggerEvent(this, 0.0);
			}

			lastValue = value;

			if(DataEvent != null)
				DataEvent(this, value);
		}

		AudioLib.TF.Highpass1 hp;
		AudioLib.TF.Lowpass1 lp;

		// ------- Control parameters -------

		WaveChannelConfig _config;
		public WaveChannelConfig Config
		{
			get { return _config; }
			set
			{
				_config = value;
				hp.SetParam(0, _config.HighpassFrequency);
				lp.SetParam(0, _config.LowpassFrequency);
			}
		}
	}
}
