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
			Buffer = new Buffer(1000);

			Config = new WaveChannelConfig();
		}

		DateTime LastTriggered;

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

		public void AddData(int data)
		{
			double value = data / 256.0;
				
			if(Config.HighpassEnabled)
				value = hp.process(value);

			//var power = Math.Abs(value); // used for trigger power

			value = Math.Abs(value); // Rectify

			value = value * Config.Gain;

			// noise floor
			if (value < Config.NoiseFloor)
				value = 0;

			// SlewRate prevents the signal from decreasing by more than a specified amount between each sample
			if (Config.DecayEnabled)
			{
				double lastValue = Buffer.GetSample(0);
				if (value < (lastValue * Config.DecayRate))
					value = lastValue * Config.DecayRate;
			}

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
				TriggerEvent(this, power);
			}

			// turn off
			if (value < Config.NoiseFloor && triggerIsOn)
			{
				triggerIsOn = false;
				if (Config.Enabled)
					TriggerEvent(this, 0.0);
			}

			if(DataEvent != null)
				DataEvent(this, value);

			currentSample++;
		}

		AudioLib.TF.Highpass1 hp;
		Buffer Buffer;

		// ------- Control parameters -------

		WaveChannelConfig _config;
		public WaveChannelConfig Config
		{
			get { return _config; }
			set
			{
				_config = value;
				hp.SetParam(0, _config.HighpassFrequency);
			}
		}
	}
}
