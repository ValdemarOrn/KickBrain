using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace KickBrain
{
	public class InputChannelConfig
	{
		// Basic Settings

		[CategoryAttribute("Basic Settings")]
		[DescriptionAttribute("Enable or disable MIDI output from this Channel.")]
		public string Name { get; set; }

		[CategoryAttribute("Basic Settings")]
		[DescriptionAttribute("Enable or disable MIDI output from this Channel.")]
		public bool Enabled { get; set; }

		[CategoryAttribute("Basic Settings")]
		[DescriptionAttribute("Specifies whether the signal from this channel should behave as a continuous controller or a trigger.")]
		public bool ContinuousControl { get; set; }


		// CC Config

		[CategoryAttribute("Continous Control")]
		[DescriptionAttribute("Sets how many samples are averaged together to create a smoother signal.")]
		public int CCAverage { get; set; }

		[CategoryAttribute("Continous Control")]
		[DescriptionAttribute("Sets how much the signal must change before a MIDI message is generated.")]
		public double CCHisteresis { get; set; }

		// Trigger Config

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets how fast the signal will fade out after it has peaked.")]
		public double DecayRate { get; set; }

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets the gain of the digital input signal.")]
		public double Gain { get; set; }

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets the noise floor of the signal. All values below this threshold will be treated as 0.")]
		public double NoiseFloor { get; set; }



		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets the number of samples that we use to measure a change in the signal. Larger values give more sensitivity but also more latency.")]
		public int TriggerAttack { get; set; }

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets how long we wait for the peak value, after a trigger has been fired. Larger values give better accuracy but also more latency.")]
		public int TriggerLength { get; set; }

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets the minimum absolute change that the signal must display in order to trigger an event")]
		public double TriggerThreshold { get; set; }

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets the minimum relative change that the signal must display in order to trigger and event.")]
		public double TriggerScale { get; set; }

		[CategoryAttribute("Trigger Control")]
		[DescriptionAttribute("Sets the minimum time in milliseconds between triggers. Values that are too low can cause unwanted retriggering")]
		public int TriggerRetrigger { get; set; }

		[BrowsableAttribute(false)]
		public AudioLib.VelocityMap Velocity { get; set; }

		int _midiChannel;

		[CategoryAttribute("Midi Output")]
		[DescriptionAttribute("Sets which MIDI channel the data is transmitted on")]
		public int MIDIChannel
		{
			get
			{
				return _midiChannel;
			}
			set
			{
				if (value < 0)
					value = 0;
				if (value > 15)
					value = 15;
				_midiChannel = value;
			}
		}

		int _midiControl;

		[CategoryAttribute("Midi Output")]
		[DescriptionAttribute("Sets which note or Continous Controller number the data is transmitted on")]
		public int MIDIControl
		{
			get
			{
				return _midiControl;
			}
			set
			{
				if (value < 0)
					value = 0;
				if (value > 127)
					value = 127;
				_midiControl = value;
			}
		}


		public InputChannelConfig()
		{
			Velocity = new AudioLib.VelocityMap(6);

			DecayRate = 0.97;
			Gain = 1.0;
			NoiseFloor = 0.01;

			TriggerThreshold = 0.02;
			TriggerAttack = 2;
			TriggerLength = 4;
			TriggerScale = 1.5;
			TriggerRetrigger = 25;

			Enabled = false;
			ContinuousControl = false;

			MIDIChannel = 1;
			MIDIControl = 60;
		}
	}
}
