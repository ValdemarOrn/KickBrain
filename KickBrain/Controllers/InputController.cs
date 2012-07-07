using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KickBrain.Views;

namespace KickBrain.Controllers
{
	public class InputController
	{
		public InputView ui;
		public InputChannel CurrentChannel;

		public int SelectedIndex;

		public InputController(InputView form)
		{
			this.ui = form;
		}

		void AddWiew()
		{
			try
			{
				// Invoke from main thread
				Action AddDele = AddWiew;
				if (ui.InvokeRequired)
				{
					ui.Invoke(AddDele, new object[] { });
					return;
				}

				var view = new WaveView();
				view.Top = 0;
				view.Left = 0;
				view.Height = ui.TabControlWaves.Height - 30;
				view.Width = ui.TabControlWaves.ClientSize.Width - 8;
				view.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right); // Resize waveView with the window
				view.ZoomX = 0.1;
				Double.TryParse(ui.textBoxZoomX.Text, out view.ZoomX);

				var page = new TabPage("");
				ui.TabControlWaves.TabPages.Add(page);
				page.Controls.Add(view);
				ui.Views.Add(view);
			}
			catch (Exception e)
			{
				MessageBox.Show("Unable to add new view to the GUI\n" + e.Message);
			}
		}

		public void Trigger(object sender_)
		{
			var sender = (InputChannel)sender_;
			var power = CurrentChannel.GetPower();

			// Invoke from main thread
			Action<object> TriggerDele = Trigger;
			if (ui.InvokeRequired)
			{
				ui.Invoke(TriggerDele, new object[] { sender_ });
				return;
			}

			if (power == 0.0)
				return;

			ui.velocityMapControl1.SetTrigger(power);

			ui.textBoxVelocity.Text = Math.Round(power, 3).ToString();
			int hits = 0;
			Int32.TryParse(ui.textBoxHits.Text, out hits);
			ui.textBoxHits.Text = (hits + 1).ToString();
		}

		public void SetZoom(double zoom)
		{
			foreach (var wave in ui.Views)
				wave.ZoomX = zoom;
		}

		public void LoadInput(int channel)
		{
			// Remove previous triggers
			Brain.KB.Sources.DetachAllEvents(this.Trigger);

			
			if (channel >= Brain.KB.ChannelCount)
				return;

			SelectedIndex = channel;
			ui.TabControlWaves.SelectedIndex = channel;

			if (channel < 0)
				return;

			CurrentChannel = (InputChannel)Brain.KB.Sources.InputChannels[channel];

			ui.propertyGrid1.SelectedObject = CurrentChannel.Config;
			ui.velocityMapControl1.Map = ((InputChannelConfig)CurrentChannel.Config).Velocity;
			ui.textBoxHits.Text = "0";
			ui.textBoxVelocity.Text = "";

			// Subscribe to the trigger event
			var triggerEvent = CurrentChannel.Events.First(x => x.Name == InputChannel.TRIGGER_EVENT);
			triggerEvent.Add(this.Trigger, null);

			ui.velocityMapControl1.Invalidate();
		}

		public void SetChannelEnabled(bool enabled)
		{
			((InputChannelConfig)CurrentChannel.Config).Enabled = enabled;
		}

		public void LoadInputs()
		{
			int idx = SelectedIndex;

			// remove current tabs
			ui.TabControlWaves.TabPages.Clear();
			ui.Views.Clear();

			// Bind the channels to the views
			foreach (InputChannel channel in Brain.KB.Sources.InputChannels)
				ui.Ctrl.AddWiew();

			// Load channel names
			var channels = Brain.KB.Sources.InputChannels;
			for (int i = 0; i < channels.Count; i++)
				ui.TabControlWaves.TabPages[i].Text = channels[i].ChannelName;

			// Load triggers for all views

			for (int i = 0; i < Brain.KB.Sources.InputChannels.Count; i++)
			{
				var ch = Brain.KB.Sources.InputChannels[i];

				// subscribe to the channel's data trigger
				var dataEvent = ch.Events.First(x => x.Name == InputChannel.TRIGGER_DATA);
				dataEvent.Add(ui.Views[i].AddData, null);

				// Subscribe to the trigger trigger
				var triggerEvent = ch.Events.First(x => x.Name == InputChannel.TRIGGER_EVENT);
				triggerEvent.Add(ui.Views[i].Trigger, null);
			}

			if (idx == -1)
				idx = 0;
			if (idx < ui.TabControlWaves.TabCount)
				LoadInput(idx);
		}


		public void SetByterate(int bytesPerSec)
		{
			// Invoke from main thread
			Action<int> SetRateDele = SetByterate;
			if (ui.InvokeRequired)
			{
				ui.Invoke(SetRateDele, new object[] { bytesPerSec });
				return;
			}

			ui.textBoxByteRate.Text = bytesPerSec.ToString();
		}

		public void SetSamplerate(int samplerate)
		{
			// Invoke from main thread
			Action<int> SetRateDele = SetSamplerate;
			if (ui.InvokeRequired)
			{
				ui.Invoke(SetRateDele, new object[] { samplerate });
				return;
			}

			ui.textBoxSamplerate.Text = samplerate.ToString();
		}

		internal void PropertyChanged()
		{
			CurrentChannel.ConfigUpdated();
			ui.velocityMapControl1.Invalidate();
			ui.TabControlWaves.SelectedTab.Text = CurrentChannel.ChannelName;
		}

		internal void setNoInput(bool noInput)
		{
			// Invoke from main thread
			Action<bool> dele = setNoInput;
			if (ui.InvokeRequired)
			{
				ui.Invoke(dele, new object[] { noInput });
				return;
			}

			if (noInput)
			{
				ui.textBoxByteRate.Text = "No Input";
				ui.textBoxByteRate.ForeColor = System.Drawing.Color.Red;
			}
			else
			{
				ui.textBoxByteRate.Text = "";
				ui.textBoxByteRate.ForeColor = System.Drawing.Color.Black;
			}
		}
	}
}
