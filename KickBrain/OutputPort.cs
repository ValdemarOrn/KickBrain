using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioLib;

namespace KickBrain
{
	public class Crosstalk
	{
		public Signal Signal;
		public double Factor;

		public Crosstalk()
		{
			Factor = 0.5;
		}
	}

	public class OutputPort
	{
		public Signal Signal;

		public Event _event;
		public Event Event
		{
			get { return _event; }
			
			set 
			{
				if(_event != null)
					_event.Remove(this.Trigger);

				_event = value;
				_event.Add(this.Trigger, null);
			}
		}
		public List<Crosstalk> CrosstalkSignals;

		public string Name;
		public int MidiChannel;
		public int CCNumber;
		public bool IsNote;
		public bool FilterEnabled;
		public Signal Filter;
		public double FilterMin;
		public double FilterMax;
		public VelocityMap VelocityMap;

		public OutputPort() : this("")
		{
			
		}

		public OutputPort(string name)
		{
			Name = name;
			VelocityMap = new VelocityMap(4);
			CrosstalkSignals = new List<Crosstalk>();
		}

		public void Trigger(object sender)
		{
			if (Signal == null)
				return;

			double val = Signal.SignalDelegate();
			val = VelocityMap.Map(val);

			if (Filter != null)
			{
				double filterVal = Filter.SignalDelegate();
				if (filterVal < FilterMin || filterVal > FilterMax)
					return;
			}

			foreach (var xsig in CrosstalkSignals)
				if (IsCrosstalk(xsig))
					return;

			if (IsNote)
				Brain.KB.Output.NoteOn(MidiChannel, CCNumber, (int)(val * 127.0));
			else
				Brain.KB.Output.CC(MidiChannel, CCNumber, (int)(val * 127.0));
		}

		public bool IsCrosstalk(Crosstalk sig)
		{
			double val = sig.Signal.SignalDelegate() * sig.Factor;
			if (val > Signal.SignalDelegate())
				return true;
			else
				return false;
		}
	}
}
