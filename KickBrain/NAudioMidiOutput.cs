using NAudio.Midi;
using System;
using System.Collections.Generic;

namespace KickBrain
{
	public class NAudioMidiOutput : IDisposable
	{
		public MidiOut Output;

		public int DeviceID { get; internal set; }

		public static List<Tuple<string, int>> GetMIDIOutDevices()
		{
			var output = new List<Tuple<string, int>>();

			// Get the product name for each device found  
			for (int device = 0; device < MidiOut.NumberOfDevices; device++)
			{
				var prod = MidiOut.DeviceInfo(device);
				var name = prod.ProductName;
				output.Add(new Tuple<string,int>(name, device));
			}

			return output;
		}

		public NAudioMidiOutput(int deviceID)
		{
			this.DeviceID = deviceID;
			Output = new MidiOut(DeviceID);
		}

		public void Dispose()
		{
			Output.Close();
		}

		public void Note(int channel, int note, int velocity)
		{
			if(velocity > 0)
				Output.Send(MidiMessage.StartNote(note, velocity, channel+1).RawData);
			else
				Output.Send(MidiMessage.StopNote(note, 0, channel+1).RawData);
		}

		public void CC(int channel, int CC, int value)
		{
			Output.Send(MidiMessage.ChangeControl(CC, value, channel+1).RawData);
		}

	}
}