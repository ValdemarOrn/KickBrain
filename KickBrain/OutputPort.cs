using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioLib;

namespace KickBrain
{
	[Serializable]
	public class Crosstalk
	{
		public Signal Signal;
		public double Factor;

		public Crosstalk()
		{
			Factor = 0.5;
		}

		public string ToXML()
		{
			return String.Format("<Crosstalk><Factor>{0:0.000}</Factor>{1}</Crosstalk>", Factor, Signal.ToXML());
		}
	}

	[Serializable]
	public class OutputPort
	{
		public Signal Signal;

		Event _event;
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

		public string ToXML()
		{
			string output = "<Output>";
			output += Signal.ToXML();
			output += Event.ToXML();
			output += "<Name>" + Name + "</Name>";
			output += "<MidiChannel>" + MidiChannel + "</MidiChannel>";
			output += "<CCNumber>" + CCNumber + "</CCNumber>";
			output += "<IsNote>" + IsNote + "</IsNote>";
			output += "<FilterEnabled>" + FilterEnabled + "</FilterEnabled>";
			output += "<FilterMin>" + FilterMin + "</FilterMin>";
			output += "<FilterMax>" + FilterMax + "</FilterMax>";
			output += "<Filter>" + Filter.ToXML() + "</Filter>";

			output += "<CrosstalkSignals>";
			foreach (var xtalk in CrosstalkSignals)
			{
				output += xtalk.ToXML();
			}
			output += "</CrosstalkSignals>";

			var veloXml = Serializer.SerializeToXML(VelocityMap);
			var doc = new System.Xml.XmlDocument();
			doc.LoadXml(veloXml);
			veloXml = doc.ChildNodes[1].OuterXml;
			output += veloXml;

			output += "</Output>";
			return output;
		}
	}
}
