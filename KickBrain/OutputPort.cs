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

		public Crosstalk(Signal signal, double factor)
		{
			Signal = signal;
			Factor = factor;
		}

		public string ToXML()
		{
			return String.Format("<Crosstalk><Factor>{0:0.000}</Factor>{1}</Crosstalk>", Factor, Signal.ToXML());
		}
	}

	[Serializable]
	public class OutputPort : IDisposable
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

				if (_event != null)
					_event.Add(this.Trigger, null);
			}
		}
		public List<Crosstalk> CrosstalkSignals;

		public string Name;
		public bool Enabled;
		public int MidiChannel;
		public int CCNumber;
		public bool IsNote;
		public bool FilterEnabled;
		public Signal Filter;
		public double? FilterMin;
		public double? FilterMax;
		public VelocityMap VelocityMap;

		public OutputPort() : this("")
		{
			
		}

		public OutputPort(string name)
		{
			Name = name;
			Enabled = true;
			IsNote = true;
			VelocityMap = new VelocityMap(4);
			CrosstalkSignals = new List<Crosstalk>();
		}

		public void Trigger(object sender)
		{
			if (Signal == null || !Enabled)
				return;

			double val = Signal.SignalDelegate();
			val = VelocityMap.Map(val);

			if (Filter != null && FilterEnabled)
			{
				double filterVal = Filter.SignalDelegate();
				if (FilterMin != null && filterVal < FilterMin)
					return;

				if (FilterMax != null && filterVal > FilterMax)
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

		public void Dispose()
		{
			Event = null;
			Signal = null;
			Filter = null;
		}

		public string ToXML()
		{
			string output = "<Output>";
			output += Signal.ToXML();
			output += Event.ToXML();
			output += "<Name>" + Name + "</Name>";
			output += "<Enabled>" + Enabled + "</Enabled>";
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

		public void LoadXML(string xml)
		{
			var doc = new System.Xml.XmlDocument();
			doc.LoadXml(xml);

			Name = doc.SelectSingleNode("Output/Name").InnerText;
			Boolean.TryParse(doc.SelectSingleNode("Output/Enabled").InnerText, out Enabled);
			Int32.TryParse(doc.SelectSingleNode("Output/MidiChannel").InnerText, out MidiChannel);
			Int32.TryParse(doc.SelectSingleNode("Output/CCNumber").InnerText, out CCNumber);
			Boolean.TryParse(doc.SelectSingleNode("Output/IsNote").InnerText, out IsNote);
			Boolean.TryParse(doc.SelectSingleNode("Output/FilterEnabled").InnerText, out FilterEnabled);


			double fMin = 0.0;
			var parsed = Double.TryParse(doc.SelectSingleNode("Output/FilterMin").InnerText, out fMin);
			if (parsed)
				FilterMin = fMin;
			else
				FilterMin = null;

			double fMax = 0.0;
			parsed = Double.TryParse(doc.SelectSingleNode("Output/FilterMax").InnerText, out fMax);
			if (parsed)
				FilterMax = fMax;
			else
				FilterMax = null;

			var veloMap = doc.SelectSingleNode("Output/VelocityMap").OuterXml;
			VelocityMap = (VelocityMap)Serializer.DeserializeToXML(veloMap, typeof(VelocityMap));

			var Signals = Brain.KB.Sources.GetAllSignals();
			var Events = Brain.KB.Sources.GetAllEvents();

			try
			{
				Signal = Signals.First(
					x => x.Name == doc.SelectSingleNode("Output/Signal/Name").InnerText && 
					x.Owner.ChannelName == doc.SelectSingleNode("Output/Signal/Owner").InnerText
					);
			}
			catch (Exception e)
			{ 
				Brain.KB.ShowError("Unable to load signal " 
					+ doc.SelectSingleNode("Output/Signal/Name").InnerText 
					+ " from channel " 
					+ doc.SelectSingleNode("Output/Signal/Owner").InnerText);
			}

			try
			{
				Filter = Signals.First(
					x => x.Name == doc.SelectSingleNode("Output/Filter/Signal/Name").InnerText && 
					x.Owner.ChannelName == doc.SelectSingleNode("Output/Filter/Signal/Owner").InnerText
					);
			}
			catch (Exception e)
			{
				Brain.KB.ShowError("Unable to load signal "
					+ doc.SelectSingleNode("Output/Filter/Signal/Name").InnerText
					+ " from channel "
					+ doc.SelectSingleNode("Output/Filter/Signal/Owner").InnerText);
			}

			try
			{
				Event = Events.First(
					x => x.Name == doc.SelectSingleNode("Output/Event/Name").InnerText &&
					x.Owner.ChannelName == doc.SelectSingleNode("Output/Event/Owner").InnerText
					);
			}
			catch (Exception e)
			{
				Brain.KB.ShowError("Unable to load event "
					+ doc.SelectSingleNode("Output/Event/Name").InnerText
					+ " from channel "
					+ doc.SelectSingleNode("Output/Event/Owner").InnerText);
			}

			var xtalkSignals = doc.SelectNodes("Output/CrosstalkSignals");

			for(int i =0; i<xtalkSignals.Count; i++)
			{
				var signal = xtalkSignals[i];

				try
				{
					var sig = Signals.First(
						x => x.Name == signal.SelectSingleNode("Crosstalk/Signal/Name").InnerText &&
						x.Owner.ChannelName == signal.SelectSingleNode("Crosstalk/Signal/Owner").InnerText
						);

					double factor = Convert.ToDouble(signal.SelectSingleNode("Crosstalk/Factor").InnerText);
					CrosstalkSignals.Add(new Crosstalk(sig, factor));
				}
				catch (Exception e)
				{
					Brain.KB.ShowError("Unable to load signal "
						+ signal.SelectSingleNode("Crosstalk/Signal/Name").InnerText
						+ " from channel "
						+ signal.SelectSingleNode("Crosstalk/Signal/Owner").InnerText);
				}
			}
		}
	}
}
