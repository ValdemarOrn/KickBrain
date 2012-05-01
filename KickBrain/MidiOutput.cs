using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioLib;

namespace SerialAudio
{
	public class MidiOutput
	{
		public PortMidi.PmDeviceInfo Info;
		public IntPtr Stream;
		public int DeviceID { get; private set; }

		public MidiOutput(int deviceID)
		{
			this.DeviceID = deviceID;
			var err = PortMidi.Pt_Start(1, null, (IntPtr)0);
			IntPtr stream;
			var error = PortMidi.Pm_OpenOutput(out stream, DeviceID, (IntPtr)0, 0, PortMidi.Pt_Time, (IntPtr)0, 0);
			this.Stream = stream;
		}

		/*void ~MidiOutput()
		{
			Close();
		}
		*/
		public void Close()
		{
			PortMidi.Pm_Close(Stream);
		}

		public void NoteOn(int note, double velocity)
		{ 
		
		}

		public void NoteOff(int note)
		{

		}

		public void CC(int CC, double value)
		{

		}
	}
}
