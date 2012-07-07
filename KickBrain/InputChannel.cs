﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace KickBrain
{
	public class InputChannel : IInput
	{
		public const string TRIGGER_EVENT = "Trigger Event";
		public const string TRIGGER_DATA = "Data Event";
		public const string VALUE_POWER = "Power";
		public const string VALUE_VALUE = "Value";

		/// Event that triggers when new data is available on the channel
		Event DataEvent;
		Event TriggerEvent;

		public int Channel;

		// IChannel
		public List<Signal> Signals { get; private set; }

		// ITrigger - Event that triggers when a trigger should be fired
		public List<Event> Events { get; set; }

		// used for CC mode
		AudioLib.TF.MovingAverage movingAverage;

		Buffer Buffer;

		// ------- Control parameters -------

		public object Config
		{
			get { return InputConfig; }
			set { InputConfig = (InputChannelConfig)value; InputConfig.SetOwner(this); }
		}

		private InputChannelConfig InputConfig { get; set; }

		public void ConfigUpdated()
		{
			movingAverage.Samples = InputConfig.CCAverage;
		}

		public InputChannel(int channel)
		{
			Channel = channel;
			//Data = new List<double>();
			movingAverage = new AudioLib.TF.MovingAverage(4);
			Buffer = new Buffer(10000);

			Config = new InputChannelConfig(this);
			this.InputConfig.Name = "Ch " + channel;

			// Set up IChannel - GetValue
			Signals = new List<Signal>();
			Signals.Add(new Signal(this, VALUE_POWER, GetPowerMapped));
			Signals.Add(new Signal(this, VALUE_VALUE, GetValue));

			// Set up ITrigger
			TriggerEvent = new Event(this, TRIGGER_EVENT);
			DataEvent = new Event(this, TRIGGER_DATA);

			Events = new List<Event>();
			Events.Add(TriggerEvent);
			Events.Add(DataEvent);

			Brain.KB.Sources.AddSignalChannel(this);
			Brain.KB.Sources.AddTriggerChannel(this);
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
				ProcessCC(value);
			else
				ProcessTrigger(value);
			
			if(DataEvent != null)
				DataEvent.Invoke(this);

			currentSample++;
		}

		private void ProcessCC(double value)
		{
			value = movingAverage.process(value);

			double lastSample = Buffer.GetSample(0);
			if (Math.Abs(lastSample - value) < InputConfig.CCHisteresis)
				value = lastSample;
			Buffer.Add(value);

			// assign the value to the power. In CC mode power = processed signal
			outputPower = InputConfig.Velocity.Map(value);
			outputValue = value;
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

		private void ProcessTrigger(double value)
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
				if (InputConfig.Enabled)
					TriggerEvent.Invoke(this);
			}

			// turn off
			if (value < InputConfig.NoiseFloor && triggerIsOn)
			{
				string name = InputConfig.Name;

				outputPower = 0.0;
				triggerIsOn = false;
				if (InputConfig.Enabled)
				{ 
					TriggerEvent.Invoke(this); 
				}
			}
		}

		public string ChannelName { get; set; }

		public double GetValue()
		{
			return outputValue;
		}

		public double GetPower()
		{
			return outputPower;
		}

		public double GetPowerMapped()
		{
			return InputConfig.Velocity.Map(outputPower);
		}

		public string ToXML()
		{
			string serialText = Serializer.SerializeToXML(Config);
			var doc = new System.Xml.XmlDocument();
			doc.LoadXml(serialText);
			serialText = doc.SelectSingleNode("InputChannelConfig").OuterXml;
			return "<Input Index=\"" + Channel + "\">" + serialText + "</Input>";
		}

		public void LoadXML(string xml)
		{
			var doc = new System.Xml.XmlDocument();
			doc.LoadXml(xml);
			var configText = doc.SelectSingleNode("Input/InputChannelConfig").OuterXml;
			var cfg = (InputChannelConfig)Serializer.DeserializeToXML(configText, typeof(InputChannelConfig));
			cfg.SetOwner(this);
			Channel = Convert.ToInt32(doc.ChildNodes[0].Attributes["Index"].Value);
			ChannelName = doc.SelectSingleNode("Input/InputChannelConfig/Name").InnerText;
		}
	}
}
