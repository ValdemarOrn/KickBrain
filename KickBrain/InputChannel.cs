using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace KickBrain
{
	public class InputChannel : IInput
	{
		public SerialInput Input;

		public int Channel;

		/// Event that triggers when new data is available on the channel
		public event Action DataEvent;

		// IChannel
		public Dictionary<string, Func<double>> Values { get; private set; }

		// ITrigger - Event that triggers when a trigger should be fired
		public event Action Trigger;

		// used for CC mode
		AudioLib.TF.MovingAverage movingAverage;

		Buffer Buffer;

		// ------- Control parameters -------

		public object Config
		{
			get { return InputConfig; }
			set { InputConfig = (InputChannelConfig)value; }
		}

		private InputChannelConfig InputConfig { get; set; }

		public void ConfigUpdated()
		{
			movingAverage.Samples = InputConfig.CCAverage;
		}

		public InputChannel(SerialInput input, int channel)
		{
			Input = input;
			Channel = channel;
			//Data = new List<double>();
			movingAverage = new AudioLib.TF.MovingAverage(4);
			Buffer = new Buffer(10000);

			Config = new InputChannelConfig();
			this.InputConfig.Name = "Ch " + channel;

			Values = new Dictionary<string, Func<double>>();
			Values.Add("Power", GetPower);
			Values.Add("Value", GetValue);

			KickBrain.KB.Sources.AddChannel(this);
			KickBrain.KB.Sources.AddTrigger(this);
		}

		DateTime LastTriggered;

		/// in trigger mode, this is the maximum signal peak
		/// In CC mode, this is just the value of the signal (but processed)
		double outputPower;

		/// This is the processed value of channel
		double outputValue;

		public void AddData(int data)
		{
			double value = data / 256.0;

			if (InputConfig.ContinuousControl)
				value = ProcessCC(value);
			else
				value = ProcessTrigger(value);
			
			if(DataEvent != null)
				DataEvent();

			currentSample++;
		}

		private double ProcessCC(double value)
		{
			value = movingAverage.process(value);

			double lastSample = Buffer.GetSample(0);
			if (Math.Abs(lastSample - value) < InputConfig.CCHisteresis)
				value = lastSample;
			Buffer.Add(value);

			// assign the value to the power. In CC mode power = processed signal
			outputPower = value;
			outputValue = value;


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
			value = value * InputConfig.Gain;

			// noise floor
			//if (value < InputConfig.NoiseFloor)
			//	value = 0;

			// prevents the signal from decreasing by more than a specified amount between each sample
			double lastValue = Buffer.GetSample(0);
			if (value < (lastValue * InputConfig.DecayRate))
				value = lastValue * InputConfig.DecayRate;

			Buffer.Add(value);
			int x = Buffer.GetIndex(InputConfig.TriggerAttack);
			double valuePre = Buffer.Data[x];

			// ------------------- Get channel power (max peak value) ------------

			outputPower = Buffer.GetMax(InputConfig.TriggerLength + InputConfig.TriggerAttack);
			outputValue = value;

			// -------------------Trigger sensor---------------------------

			// Start a new trigger
			if (((value - valuePre) >= InputConfig.TriggerThreshold) && ((value / valuePre) >= InputConfig.TriggerScale) && value >= InputConfig.NoiseFloor)
			{
				// Trigger if retrigger time has passed
				if (LastTriggered.AddMilliseconds(InputConfig.TriggerRetrigger) <= DateTime.Now)
				{
					triggerIsOn = true;
					LastTriggered = DateTime.Now;
					triggerAtSample = currentSample + InputConfig.TriggerLength;
				}
			}

			// execute the trigger event once TriggerLength has passed
			if (triggerAtSample == currentSample)
			{
				if (InputConfig.Enabled && Trigger != null)
					Trigger();
			}

			// turn off
			if (value < InputConfig.NoiseFloor && triggerIsOn)
			{
				outputPower = 0.0;
				triggerIsOn = false;
				if (InputConfig.Enabled && Trigger != null)
					Trigger();
			}
			return value;
		}

		public string GetName()
		{
			return InputConfig.Name;
		}

		public double GetValue()
		{
			return outputValue;
		}

		public double GetPower()
		{
			return outputPower;
		}
	}
}
