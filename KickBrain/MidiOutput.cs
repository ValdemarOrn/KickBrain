using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioLib;

namespace KickBrain
{
	public class MidiOutput
	{
		[Newtonsoft.Json.JsonIgnore]
		public PortMidi.PmDeviceInfo Info;

		[Newtonsoft.Json.JsonIgnore]
		public IntPtr Stream;

		public int DeviceID { get; internal set; }

		PortMidi.PmTimeProcPtr TimeProc; // We must store a delegate to the callback, otherwise it will be garbage collected!
										 // and a marshalling error occurs!

		// Constructor used by the deserializer. It depends on DeviceID already being set (BEFORE calling the constructor!
		internal MidiOutput()
		{
			Start();
		}
		public MidiOutput(int deviceID)
		{
			this.DeviceID = deviceID;
			Start();
		}

		~MidiOutput()
		{
			Close();
		}

		public void Start()
		{
			if (PortMidi.Pt_Started() == 0)
			{
				var err = PortMidi.Pt_Start(1, null, (IntPtr)0);
				if (err != PortMidi.PtError.ptNoError)
					throw new Exception("Unable to stop PortTime");
			}

			IntPtr stream;
			TimeProc = PortMidi.Pt_Time;
			var error = PortMidi.Pm_OpenOutput(out stream, DeviceID, (IntPtr)0, 0, TimeProc, (IntPtr)0, 1);
			if (error != PortMidi.PmError.pmNoError)
				throw new Exception("Unable to open MIDI Output with ID " + DeviceID + " - " + error.ToString());
			this.Stream = stream;
		}

		public void TriggerEvent(WaveChannel sender, double value)
		{
			value = sender.Config.Velocity.Map(value);

			if (sender.Config.ContinuousControl)
			{
				CC(sender.Config.MIDIChannel, sender.Config.MIDIControl, (int)Math.Round(value * 127));
			}
			else
			{
				if(value == 0.0)
					NoteOff(sender.Config.MIDIChannel, sender.Config.MIDIControl);
				else
					NoteOn(sender.Config.MIDIChannel, sender.Config.MIDIControl, (int)Math.Round(value * 127));
			}

			Console.WriteLine("Midi trigger complete");
		}
		
		public void Close()
		{
			PortMidi.Pm_Close(Stream);
			if(PortMidi.Pt_Started() > 0)
				PortMidi.Pt_Stop();
		}

		void NoteOn(int channel, int note, int velocity)
		{
			int status = MidiMessageType.NoteOn | channel;
			var message = PortMidi.Pm_Message(status, note, velocity);

			var err = PortMidi.Pm_WriteShort(Stream, TimeProc((IntPtr)0), message);
			if (err != PortMidi.PmError.pmNoError)
				KickBrain.KB.ShowError("Error sending noteOn: " + err.ToString());
		}

		void NoteOff(int channel, int note)
		{
			int status = MidiMessageType.NoteOff | channel;
			var message = PortMidi.Pm_Message(status, note, 0);

			var err = PortMidi.Pm_WriteShort(Stream, TimeProc((IntPtr)0), message);
			if (err != PortMidi.PmError.pmNoError)
				KickBrain.KB.ShowError("Error sending noteOff: " + err.ToString());
		}

		void CC(int channel, int CC, int value)
		{
			int status = MidiMessageType.ControlChange | channel;
			var message = PortMidi.Pm_Message(status, CC, value);

			var err = PortMidi.Pm_WriteShort(Stream, TimeProc((IntPtr)0), message);
			if (err != PortMidi.PmError.pmNoError)
				KickBrain.KB.ShowError("Error sending CC: " + err.ToString());
		}
	}
}
