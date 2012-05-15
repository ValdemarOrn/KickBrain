using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KickBrain.Views;

namespace KickBrain.Controllers
{
	public class SignalController
	{
		public SignalView ui;

		Signal CurrentSignal;
		List<Signal> Signals;
		List<Event> Triggers;

		public SignalController(SignalView form)
		{
			this.ui = form;
			Signals = new List<Signal>();
			Triggers = new List<Event>();
		}

		public int SelectedIndex
		{
			get { return Signals.IndexOf(CurrentSignal); }
		}

		public void LoadAllSources()
		{
			// Signals
			var channels = Brain.KB.Sources.GetChannels();
			ui.listBoxSignals.Items.Clear();
			ui.comboBoxA.Items.Clear();
			ui.comboBoxB.Items.Clear();
			Signals.Clear();

			foreach (var channel in channels)
			{
				foreach (var signal in channel.Signals)
				{
					Signals.Add(signal);
					ui.listBoxSignals.Items.Add(channel.GetName() + " - " + signal.Name);
					ui.comboBoxA.Items.Add(channel.GetName() + " - " + signal.Name);
					ui.comboBoxB.Items.Add(channel.GetName() + " - " + signal.Name);
				}
			}

			ui.listBoxSignals.SelectedIndex = SelectedIndex;

			// Triggers
			var triggerChannels = Brain.KB.Sources.GetTriggers();
			ui.comboBoxTrigger.Items.Clear();
			foreach (var channel in triggerChannels)
			{
				foreach (var trigger in channel.Triggers)
				{
					Triggers.Add(trigger);
					ui.comboBoxTrigger.Items.Add(channel.GetName() + " - " + trigger.Name);
				}
			}

			// Modes
			ui.comboBoxMode.Items.Clear();
			foreach (var mode in SignalMode.Modes)
				ui.comboBoxMode.Items.Add(mode.ToString());

			if (SelectedIndex != -1)
				LoadSignal(SelectedIndex);
		}

		public void AddSignal()
		{
			var ch = new SignalChannel("New Channel");
			Brain.KB.Sources.AddChannel(ch);
			LoadAllSources();
			ui.listBoxSignals.SelectedIndex = Signals.Count - 1;
		}

		public void LoadSignal(int i)
		{
			if (i < 0 || i >= ui.listBoxSignals.Items.Count)
				return;

			if (Signals[i].Owner.GetType() != typeof(SignalChannel))
			{
				CurrentSignal = null;
				return;
			}

			CurrentSignal = Signals[i];

			var ch = (SignalChannel)CurrentSignal.Owner;

			ui.textBoxSignalName.Text = ch.Name;
			ui.comboBoxMode.Text = ch.Mode.ToString();
			ui.comboBoxA.SelectedIndex = (ch.InputA != null) ? Signals.IndexOf(ch.InputA) : -1;
			ui.comboBoxB.SelectedIndex = (ch.InputB != null) ? Signals.IndexOf(ch.InputB) : -1;
			ui.comboBoxTrigger.SelectedIndex = (ch.Trigger != null) ? Triggers.IndexOf(ch.Trigger) : -1;
			ui.velocityMapControl1.Map = ch.VelocityMap;
		}

		public void SaveSignal()
		{
			if (CurrentSignal == null || CurrentSignal.Owner.GetType() != typeof(SignalChannel))
				return;

			var ch = (SignalChannel)CurrentSignal.Owner;

			ch.Name = ui.textBoxSignalName.Text;
			ch.Mode = SignalMode.Modes.First(x => x.ToString() == ui.comboBoxMode.Text);
			ch.InputA = (ui.comboBoxA.SelectedIndex == -1) ? null : Signals[ui.comboBoxA.SelectedIndex];
			ch.InputB = (ui.comboBoxB.SelectedIndex == -1) ? null : Signals[ui.comboBoxB.SelectedIndex];
			ch.Trigger = (ui.comboBoxTrigger.SelectedIndex == -1) ? null : Triggers[ui.comboBoxTrigger.SelectedIndex];
		}

		internal void ConnectTrigger()
		{
			var ch = (SignalChannel)CurrentSignal.Owner;
			if (ch.Trigger != null)
				ch.Trigger.Remove(ch.Calculate);

			//ch.Trigger.
		}
	}
}
