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

		SignalChannel CurrentChannel;
		List<SignalChannel> Channels;

		

		public SignalController(SignalView form)
		{
			this.ui = form;
			Channels = new List<SignalChannel>();
		}

		public int SelectedIndex
		{
			get { return Channels.IndexOf(CurrentChannel); }
		}

		public void LoadSignalChannels()
		{
			// Channels
			var channels = Brain.KB.Sources.GetSignalChannels();
			
			ui.listBoxSignals.Items.Clear();
			Channels.Clear();

			foreach (var channel in channels)
			{
				// check if this is a signal channel
				if (channel.GetType() == typeof(SignalChannel))
				{
					// add to channels list
					Channels.Add((SignalChannel)channel);
					// show in the list on the left side
					ui.listBoxSignals.Items.Add(channel.ChannelName);
				}
			}

			// reload selected index
			try
			{
				ui.listBoxSignals.SelectedIndex = SelectedIndex;
			}
			catch (Exception e)
			{
				ui.listBoxSignals.SelectedIndex = 0;
				CurrentChannel = Channels[0];
			}
		}

		List<Signal> signals;

		public void LoadSignals()
		{
			if (signals != null)
				signals.Clear();
			signals = Brain.KB.Sources.GetAllSignals();

			ui.comboBoxA.Items.Clear();
			ui.comboBoxB.Items.Clear();

			// loop through all the signals, of allt types of channels
			foreach (var signal in signals)
			{
				ui.comboBoxA.Items.Add(signal.Owner.ChannelName + " - " + signal.Name);
				ui.comboBoxB.Items.Add(signal.Owner.ChannelName + " - " + signal.Name);
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

		public void LoadModes()
		{
			ui.comboBoxMode.Items.Clear();
			foreach (var mode in SignalMode.Modes)
				ui.comboBoxMode.Items.Add(mode.ToString());

			if (SelectedIndex != -1)
				LoadChannel(SelectedIndex);
		}

		public void AddSignal()
		{
			var ch = new SignalChannel("New Channel");
			Brain.KB.Sources.AddSignalChannel(ch);
			LoadSignalChannels();
			ui.listBoxSignals.SelectedIndex = Channels.Count - 1;
			LoadSignals();
		}

		public void LoadChannel(int i)
		{
			// detach from ALL events
			Brain.KB.Sources.DetachAllEvents(this.Trigger);

			if (i < 0 || i >= ui.listBoxSignals.Items.Count)
				return;

			if (Channels[i].GetType() != typeof(SignalChannel))
			{
				CurrentChannel = null;
				return;
			}

			CurrentChannel = Channels[i];

			var ch = CurrentChannel;

			ui.textBoxSignalName.Text = ch.Name;
			ui.comboBoxMode.Text = ch.Mode.ToString();
			ui.comboBoxA.SelectedIndex = (ch.InputA != null) ? signals.IndexOf(ch.InputA) : -1;
			ui.comboBoxB.SelectedIndex = (ch.InputB != null) ? signals.IndexOf(ch.InputB) : -1;
			ui.comboBoxEvent.SelectedIndex = (ch.Trigger != null) ? events.IndexOf(ch.Trigger) : -1;
			ui.velocityMapControl.Map = ch.VelocityMap;

			// Attach the trigger that updates the view
			if (ch.Trigger != null)
				ch.Trigger.Add(this.Trigger, null);
		}

		public void SaveSignal()
		{
			if (CurrentChannel == null || CurrentChannel.GetType() != typeof(SignalChannel))
				return;

			var ch = CurrentChannel;

			ch.Name = ui.textBoxSignalName.Text;
			ch.Mode = SignalMode.Modes.First(x => x.ToString() == ui.comboBoxMode.Text);
			ch.InputA = (ui.comboBoxA.SelectedIndex == -1) ? null : signals[ui.comboBoxA.SelectedIndex];
			ch.InputB = (ui.comboBoxB.SelectedIndex == -1) ? null : signals[ui.comboBoxB.SelectedIndex];
			ch.Trigger = (ui.comboBoxEvent.SelectedIndex == -1) ? null : events[ui.comboBoxEvent.SelectedIndex];
		}

		internal void ConnectEvent()
		{
			var ch = CurrentChannel;
			if (ch.Trigger != null)
			{
				ch.Trigger.Remove(ch.Process);
				ch.Trigger.Remove(this.Trigger);
			}

			ch.Trigger = (ui.comboBoxEvent.SelectedIndex == -1) ? null : events[ui.comboBoxEvent.SelectedIndex];

			if (ch.Trigger != null)
			{
				ch.Trigger.Add(ch.Process, ch);
				ch.Trigger.Add(this.Trigger, null);
			}
		}

		public void Trigger(object sender)
		{
			try
			{
				double valA = 0.0;
				if (CurrentChannel.InputA != null)
					valA = CurrentChannel.InputA.SignalDelegate();

				double valB = 0.0;
				if (CurrentChannel.InputB != null)
					valB = CurrentChannel.InputB.SignalDelegate();

				// Invoke from main thread
				Action<object> TriggerDele = Trigger;
				if (ui.InvokeRequired)
				{
					ui.Invoke(TriggerDele, new object[] { sender });
					return;
				}

				ui.labelSigAOutput.Text = String.Format("{0:0.00}", valA);
				ui.labelSigBOutput.Text = String.Format("{0:0.00}", valB);
				ui.checkBoxTriggerOn.Checked = true;
				ui.velocityMapControl.SetTrigger(CurrentChannel.Signals[0].SignalDelegate());
				ui.textBoxOutput.Text = String.Format("{0:0.00}", CurrentChannel.Signals[0].SignalDelegate());
				ui.TriggerTimer.Stop();
				ui.TriggerTimer.Start();
			}
			catch (Exception e)
			{ }

		}
	}
}
