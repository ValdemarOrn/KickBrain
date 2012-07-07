using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickBrain
{
	public class UIController
	{
		public UI ui;

		public UIController(UI ui)
		{
			this.ui = ui;
		}

		public void Trigger(object sender)
		{
			InputChannel ch = (InputChannel)sender;
			var vu = (VUMeter)ui.VUMeters[ch.Channel];
			var val = (float)ch.GetPowerMapped();

			if(val > 0)
				vu.Peak = val;
		}

		public void LoadInputs()
		{
			// remove trigger
			DetachAllVUMeters();

			ui.panelMeters.Controls.Clear();
			ui.VUMeters.Clear();
			ui.VULabels.Clear();

			int width = 75;

			for (int i = 0; i < Brain.KB.Sources.InputChannels.Count; i++)
			{
				var input = Brain.KB.Sources.InputChannels[i];
				var vu = new VUMeter();
				vu.Top = 5;
				vu.Width = width;
				vu.Left = 10 + i * (vu.Width + 5);
				vu.Height = ui.panelMeters.Height - 30;
				ui.panelMeters.Controls.Add(vu);
				ui.VUMeters.Add(vu);

				var label = new System.Windows.Forms.Label();
				label.Text = "asdasda";
				label.AutoSize = false;
				label.Top = vu.Height + 5;
				label.Width = width;
				label.Left = 10 + i * (label.Width + 5);
				label.Height = 20;
				label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				ui.panelMeters.Controls.Add(label);
				ui.VULabels.Add(label);

				// Subscribe to the trigger event
				var triggerEvent = input.Events.First(x => x.Name == InputChannel.TRIGGER_DATA);
				triggerEvent.Add(this.Trigger, null);
			}

			SetLabelNames();
		}

		public void SetLabelNames()
		{
			for (int i = 0; i < Brain.KB.Sources.InputChannels.Count; i++)
			{
				var input = Brain.KB.Sources.InputChannels[i];

				var label = ui.VULabels[i];
				label.Text = input.ChannelName;
			}
		}

		public void DetachAllVUMeters()
		{
			Brain.KB.Sources.DetachAllEvents(this.Trigger);
		}

		public void EnterBackgroundMode()
		{
			ui.InputView.Hide();
			ui.SignalView.Hide();
			ui.OutputView.Hide();
			DetachAllVUMeters();
			ui.Hide();

			ui.notifyIcon.Visible = true;
		}

		internal void LeaveBackgroundMode()
		{
			LoadInputs();
			ui.InputView.Show();
			ui.Show();

			ui.notifyIcon.Visible = false;
		}
	}
}
