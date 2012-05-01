using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace KickBrain
{
	public class WaveChannel
	{
		public SerialInput Input;

		public int Channel;

		/// Event that triggers when new data is available on the channel
		public event Action<WaveChannel, double> DataEvent;

		// Event that triggers when a trigger should be fired
		public event Action<WaveChannel, double> TriggerEvent;

		// used for CC mode
		AudioLib.TF.MovingAverage movingAverage;

		Buffer Buffer;

		// ------- Control parameters -------

		public WaveChannelConfig Config { get; set; }

		public void ConfigUpdated()
		{
			movingAverage.Samples = Config.CCAverage;
		}

		public WaveChannel(SerialInput input, int channel)
		{
			Input = input;
			Channel = channel;
			//Data = new List<double>();
			movingAverage = new AudioLib.TF.MovingAverage(4);
			Buffer = new Buffer(10000);

			Config = new WaveChannelConfig();
		}

		DateTime LastTriggered;

		

		public void AddData(int data)
		{
			double value = data / 256.0;

			if(Config.ContinuousControl)
				value = ProcessCC(value);
			else
				value = ProcessTrigger(value);
			
			if(DataEvent != null)
				DataEvent(this, value);

			currentSample++;
		}

		private double ProcessCC(double value)
		{
			value = movingAverage.process(value);

			double lastSample = Buffer.GetSample(0);
			if (Math.Abs(lastSample - value) < Config.CCHisteresis)
				value = lastSample;
			Buffer.Add(value);

			return value;
		}

		/// Boolean state that tells if a trigger is currently on. Used to
		/// turn off triggers after the go below the noise floor
		bool triggerIsOn;

		/// Running counter, incremented every time a sample is added
		long currentSample;

		/// the sample number for when to actually fire the trigger
		/// This is used because after the trigger threshold has been reached
		/// We still need to allow a few samples (TriggerLength) to pass so that
		/// we can measure the peak of the signal.
		long triggerAtSample;

		private double ProcessTrigger(double value)
		{
			value = value * Config.Gain;

			// noise floor
			if (value < Config.NoiseFloor)
				value = 0;

			// prevents the signal from decreasing by more than a specified amount between each sample
			double lastValue = Buffer.GetSample(0);
			if (value < (lastValue * Config.DecayRate))
				value = lastValue * Config.DecayRate;

			Buffer.Add(value);
			int x = Buffer.GetIndex(Config.TriggerAttack);
			double valuePre = Buffer.Data[x];

			// -------------------Trigger sensor---------------------------

			// Start a new trigger
			if (((value - valuePre) >= Config.TriggerThreshold) && ((value / valuePre) >= Config.TriggerScale))
			{
				// Trigger if retrigger time has passed
				if (LastTriggered.AddMilliseconds(Config.TriggerRetrigger) <= DateTime.Now)
				{
					triggerIsOn = true;
					LastTriggered = DateTime.Now;
					triggerAtSample = currentSample + Config.TriggerLength;
				}
			}

			// execute the trigger event once TriggerLength has passed
			if (triggerAtSample == currentSample)
			{
				double power = Buffer.GetMax(Config.TriggerLength + Config.TriggerAttack);
				if (Config.Enabled && TriggerEvent != null)
					TriggerEvent(this, power);
			}

			// turn off
			if (value < Config.NoiseFloor && triggerIsOn)
			{
				triggerIsOn = false;
				if (Config.Enabled && TriggerEvent != null)
					TriggerEvent(this, 0.0);
			}
			return value;
		}
	}
}
