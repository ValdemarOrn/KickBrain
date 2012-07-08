using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KickBrain.Views;

namespace KickBrain.Controllers
{
	public class OutputController
	{
		public OutputView ui;

		OutputPort CurrentPort;
		List<OutputPort> OutputPorts;

		public OutputController(OutputView form)
		{
			this.ui = form;
			OutputPorts = new List<OutputPort>();
		}

		public int SelectedIndex
		{
			get { return Brain.KB.Sources.GetOutputPorts().IndexOf(CurrentPort); }
		}

		List<Signal> signals;

		public void LoadSignals()
		{
			if (signals != null)
				signals.Clear();
			signals = Brain.KB.Sources.GetAllSignals();

			ui.comboBoxSignal.Items.Clear();
			ui.comboBoxCrosstalk.Items.Clear();
			ui.comboBoxFilterSignal.Items.Clear();

			// loop through all the signals, of all types of channels
			foreach (var signal in signals)
			{
				ui.comboBoxSignal.Items.Add(signal.Owner.ChannelName + " - " + signal.Name);
				ui.comboBoxCrosstalk.Items.Add(signal.Owner.ChannelName + " - " + signal.Name);
				ui.comboBoxFilterSignal.Items.Add(signal.Owner.ChannelName + " - " + signal.Name);
			}
		}

		List<Event> events;

		public void LoadEvents()
		{
			if (events != null)
				events.Clear();
			events = Brain.KB.Sources.GetAllEvents();

			ui.comboBoxEvent.Items.Clear();
			foreach (var trigger in events)
			{
				ui.comboBoxEvent.Items.Add(trigger.Owner.ChannelName + " - " + trigger.Name);
			}
		}

		public void LoadOutputs()
		{
			// Outputs
			OutputPorts = Brain.KB.Sources.GetOutputPorts();

			ui.listBoxOutputs.Items.Clear();

			foreach (var port in OutputPorts)
			{
				// show in the list on the left side
				ui.listBoxOutputs.Items.Add(port.Name);
			}

			// reload selected index
			try
			{
				ui.listBoxOutputs.SelectedIndex = SelectedIndex;
			}
			catch (Exception e)
			{
				ui.listBoxOutputs.SelectedIndex = 0;
				CurrentPort = Brain.KB.Sources.GetOutputPorts()[0];
			}
		}

		internal void AddOutput()
		{
			var output = new OutputPort("Output" + Brain.KB.Sources.GetOutputPorts().Count);
			Brain.KB.Sources.AddOutputPort(output);
			LoadOutputs();
			ui.listBoxOutputs.SelectedIndex = OutputPorts.Count - 1;
			LoadSignals();
		}

		internal void RemoveOutput()
		{
			int selIdx = ui.listBoxOutputs.SelectedIndex;
			Brain.KB.Sources.RemoveOutputPort(CurrentPort);
			LoadOutputs();
			ui.listBoxOutputs.SelectedIndex = (selIdx < ui.listBoxOutputs.Items.Count) ? selIdx : (selIdx - 1);
			
			LoadSignals();

			if (ui.listBoxOutputs.SelectedIndex == -1)
				ClearUI();
		}

		public void ClearUI()
		{
			ui.comboBoxCrosstalk.SelectedIndex = -1;
			ui.comboBoxEvent.SelectedIndex = -1;
			ui.comboBoxFilterSignal.SelectedIndex = -1;
			ui.comboBoxSignal.SelectedIndex = -1;
			ui.textBoxCCNumber.Text = "";
			ui.textBoxFilterMax.Text = "";
			ui.textBoxFilterMin.Text = "";
			ui.textBoxMidiChannel.Text = "";
			ui.textBoxName.Text = "";
			ui.checkBoxFilterEnabled.Checked = false;
			ui.checkBoxIsNote.Checked = false;
			ui.checkBoxTriggerOn.Checked = false;
			ui.panelCrosstalk.Controls.Clear();
			ui.velocityMapControl.Map = null;
		}

		public void LoadOutput(int i)
		{
			//Detach trigger from every available event!
			Brain.KB.Sources.DetachAllEvents(this.Trigger);

			if (i < 0 || i >= ui.listBoxOutputs.Items.Count)
				return;

			CurrentPort = OutputPorts[i];

			var port = CurrentPort;

			ui.comboBoxSignal.SelectedIndex = signals.IndexOf(port.Signal);
			ui.comboBoxEvent.SelectedIndex = events.IndexOf(port.Event);
			ui.comboBoxCrosstalk.SelectedIndex = -1;

			ui.textBoxName.Text = port.Name;
			ui.checkBoxEnabled.Checked = port.Enabled;
			ui.textBoxMidiChannel.Text = port.MidiChannel.ToString();
			ui.textBoxCCNumber.Text = port.CCNumber.ToString();
			ui.checkBoxIsNote.Checked = port.IsNote;
			ui.comboBoxFilterSignal.SelectedIndex = (port.Filter != null) ? signals.IndexOf(port.Filter) : -1;
			ui.checkBoxFilterEnabled.Checked = port.FilterEnabled;
			ui.textBoxFilterMin.Text = port.FilterMin.ToString();
			ui.textBoxFilterMax.Text = port.FilterMax.ToString();
			ui.velocityMapControl.Map = new AudioLib.VelocityMap(port.VelocityMap);

			// Attach the trigger that updates the view
			if (port.Event != null)
				port.Event.Add(this.Trigger, null);

			LoadCrosstalk();
		}

		public void SaveOutput()
		{
			if (CurrentPort == null)
				return;

			var port = CurrentPort;

			port.Signal = (ui.comboBoxSignal.SelectedIndex != -1) ? signals[ui.comboBoxSignal.SelectedIndex] : null;
			port.Event = (ui.comboBoxEvent.SelectedIndex != -1) ? events[ui.comboBoxEvent.SelectedIndex] : null;
			ui.comboBoxCrosstalk.SelectedIndex = -1;

			port.Name = ui.textBoxName.Text;
			port.Enabled = ui.checkBoxEnabled.Checked;
			Int32.TryParse(ui.textBoxMidiChannel.Text, out port.MidiChannel);
			Int32.TryParse(ui.textBoxCCNumber.Text, out port.CCNumber);
			port.IsNote = ui.checkBoxIsNote.Checked;
			port.Filter = (ui.comboBoxFilterSignal.SelectedIndex != -1) ? signals[ui.comboBoxFilterSignal.SelectedIndex] : null;
			port.FilterEnabled = ui.checkBoxFilterEnabled.Checked;

			double fMin = 0.0;
			var parsed = Double.TryParse(ui.textBoxFilterMin.Text, out fMin);
			if (parsed)
				port.FilterMin = fMin;
			else
				port.FilterMin = null;

			double fMax = 0.0;
			parsed = Double.TryParse(ui.textBoxFilterMax.Text, out fMax);
			if (parsed)
				port.FilterMax = fMax;
			else
				port.FilterMax = null;

			// save velocity map
			port.VelocityMap = ui.velocityMapControl.Map;

			// Save crosstalk
			int i = 0;
			foreach (var xtalk in port.CrosstalkSignals)
			{
				xtalk.Factor = 0.0;
				Double.TryParse(ui.CrosstalkFactors[i].Text, out xtalk.Factor);

				xtalk.Signal = (ui.CrosstalkSignals[i].SelectedIndex != -1) ? signals[ui.CrosstalkSignals[i].SelectedIndex] : null;
				i++;
			}
		}

		public void AddCrosstalk(int signalIndex)
		{
			if (CurrentPort == null)
				return;

			var xtalk = new Crosstalk();
			xtalk.Signal = signals[signalIndex];
			CurrentPort.CrosstalkSignals.Add(xtalk);
			LoadCrosstalk();
		}

		public void LoadCrosstalk()
		{
			ui.panelCrosstalk.Controls.Clear();
			ui.CrosstalkFactors.Clear();
			ui.CrosstalkSignals.Clear();
			ui.CrosstalkLabels.Clear();

			int i = 0;
			foreach (var xtalk in CurrentPort.CrosstalkSignals)
			{
				var tb = new System.Windows.Forms.TextBox();
				tb.Name = "CrosstalkFactor_"+i;
				tb.Width = 50;
				tb.Top = 5 + i * 25;
				tb.Left = 5;
				tb.Text = String.Format("{0:0.000}", xtalk.Factor);

				var cb = new System.Windows.Forms.ComboBox();
				cb.Name = "CrosstalkSignal_"+i;
				cb.Width = 90;
				cb.Top = 5 + i * 25;
				cb.Left = 60;
				foreach (var signal in signals)
					cb.Items.Add(signal.Owner.ChannelName + " - " + signal.Name);
				
				// set the index of the combobox to the selected signal
				if (xtalk.Signal == null)
					cb.SelectedIndex = -1;
				else
					cb.SelectedIndex = signals.IndexOf(xtalk.Signal);

				var lb = new System.Windows.Forms.Label();
				lb.Name = "CrosstalkLabel_" + i;
				lb.Text = "0.0";
				lb.Top = 8 + i * 25;
				lb.Left = 155;
				lb.Width = 40;

				var del = new System.Windows.Forms.Label();
				del.Name = "CrosstalkDelete_" + i;
				del.Text = "x";
				del.Top = 8 + i * 25;
				del.Left = 195;
				del.Font = new System.Drawing.Font(del.Font, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline); 
				del.ForeColor = System.Drawing.Color.CornflowerBlue;
				del.Click += new EventHandler(
					delegate(object sender, EventArgs e) 
					{
						var xtalkIndex = ((System.Windows.Forms.Label)sender).Name.Split('_')[1];
						int index = Convert.ToInt32(xtalkIndex); 
						RemoveCrosstalk(index); 
					}
				); 

				ui.panelCrosstalk.Controls.Add(tb);
				ui.panelCrosstalk.Controls.Add(cb);
				ui.panelCrosstalk.Controls.Add(lb);
				ui.panelCrosstalk.Controls.Add(del);

				ui.CrosstalkFactors.Add(tb);
				ui.CrosstalkSignals.Add(cb);
				ui.CrosstalkLabels.Add(lb);

				i++;
			}
		}

		private void RemoveCrosstalk(int index)
		{
			CurrentPort.CrosstalkSignals.RemoveAt(index);
			LoadCrosstalk();
		}

		public void Trigger(object sender)
		{
			// Invoke from main thread
			Action<object> TriggerDele = Trigger;
			if (ui.InvokeRequired)
			{
				ui.Invoke(TriggerDele, new object[] { sender });
				return;
			}

			ui.checkBoxTriggerOn.Checked = true;
			ui.TriggerTimer.Stop();
			ui.TriggerTimer.Start();

			if (CurrentPort.Signal == null)
				return;

			


			// show Crosstalk values. In red if threshold is reached
			int i = 0;
			foreach (var xtalk in CurrentPort.CrosstalkSignals)
			{
				var val = xtalk.Signal.SignalDelegate() * xtalk.Factor;
				ui.CrosstalkLabels[i].Text = String.Format("{0:0.000}", val);
				if (CurrentPort.IsCrosstalk(xtalk))
					ui.CrosstalkLabels[i].ForeColor = System.Drawing.Color.Red;
				else
					ui.CrosstalkLabels[i].ForeColor = System.Drawing.Color.Black;
				i++;
			}

			// check if filter prevents triggering
			if (CurrentPort.Filter != null)
			{
				ui.labelFilterValue.Text = String.Format("{0:0.000}", CurrentPort.Filter.SignalDelegate());

				double filterVal = CurrentPort.Filter.SignalDelegate();
				if (CurrentPort.FilterEnabled && (filterVal < CurrentPort.FilterMin || filterVal > CurrentPort.FilterMax))
					return;
			}

			// check if crosstalk prevents triggering
			foreach (var xsig in CurrentPort.CrosstalkSignals)
				if (CurrentPort.IsCrosstalk(xsig))
					return;

			if(CurrentPort.Signal != null)
				ui.velocityMapControl.SetTrigger(CurrentPort.Signal.SignalDelegate());
		}
	}
}
