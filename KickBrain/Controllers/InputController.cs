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

		public InputController(InputView form)
		{
			this.ui = form;
		}

		public void AddWiew(InputChannel channel)
		{
			try
			{
				// Invoke from main thread
				Action<InputChannel> AddDele = AddWiew;
				if (ui.InvokeRequired)
				{
					ui.Invoke(AddDele, new object[] { channel });
					return;
				}

				var view = new WaveView();
				view.Channel = channel;
				view.Top = 0;
				view.Left = 0;
				view.Height = ui.WaveTabs.Height - 30;
				view.Width = ui.WaveTabs.ClientSize.Width - 8;
				view.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right); // Resize waveView with the window
				view.ZoomX = Convert.ToDouble(ui.textBoxZoomX.Text);
				view.RefreshRate = Convert.ToDouble(ui.textBoxRefresh.Text);

				// subscribe to the channel's data trigger
				var dataEvent = channel.Triggers.First(x => x.Name == InputChannel.TRIGGER_DATA);
				dataEvent.Add(view.AddData);

				// Subscribe to the trigger trigger
				var triggerEvent = channel.Triggers.First(x => x.Name == InputChannel.TRIGGER_TRIGGER);
				triggerEvent.Add(this.Trigger);
				triggerEvent.Add(view.Trigger);

				var page = new TabPage("Ch " + channel.Channel);
				ui.WaveTabs.TabPages.Add(page);
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
			var velocity = CurrentChannel.GetPower();
			//if (sender != this.CurrentChannel)
			//	return;

			// Invoke from main thread
			Action<IEventChannel> TriggerDele = Trigger;
			if (ui.InvokeRequired)
			{
				ui.Invoke(TriggerDele, null);
				return;
			}

			if (velocity == 0.0)
				return;

			ui.velocityMapControl1.SetTrigger(velocity);

			velocity = ((InputChannelConfig)CurrentChannel.Config).Velocity.Map(velocity);

			double barValue = velocity * ui.progressBarVelocity.Maximum;
			if (barValue > ui.progressBarVelocity.Maximum)
				barValue = ui.progressBarVelocity.Maximum;
			ui.progressBarVelocity.Value = (int)(barValue);

			ui.textBoxVelocity.Text = Math.Round(velocity, 3).ToString();
			int hits = 0;
			Int32.TryParse(ui.textBoxHits.Text, out hits);
			ui.textBoxHits.Text = (hits + 1).ToString();

			Console.WriteLine("UI TRigger");
		}

		public void SetZoom(double zoom)
		{
			foreach (var wave in ui.Views)
				wave.ZoomX = zoom;
		}

		public void SetRefresh(double rate)
		{
			foreach (var wave in ui.Views)
				wave.RefreshRate = rate;
		}

		public void SetActiveChannel()
		{
			SetActiveChannel(ui.WaveTabs.SelectedIndex);
		}

		public void SetActiveChannel(int channel)
		{
			if (channel < 0 || channel >= Brain.KB.Input.ChannelCount)
				return;

			CurrentChannel = ((WaveView)(ui.WaveTabs.SelectedTab.Controls[0])).Channel;

			ui.propertyGrid1.SelectedObject = CurrentChannel.Config;
			ui.velocityMapControl1.Map = ((InputChannelConfig)CurrentChannel.Config).Velocity;
			ui.textBoxHits.Text = "0";
			ui.textBoxVelocity.Text = "";

			ui.velocityMapControl1.Invalidate();
		}

		public void SetChannelEnabled(bool enabled)
		{
			((InputChannelConfig)CurrentChannel.Config).Enabled = enabled;
		}

		public void Configure()
		{
			bool connected = Brain.KB.Configure();

			if (!connected)
				return;

			// remove current tabs
			ui.WaveTabs.TabPages.Clear();

			foreach (InputChannel channel in Brain.KB.Input.Channels)
				ui.Ctrl.AddWiew(channel);

			// initialize processing values
			ui.Ctrl.SetActiveChannel(0);
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
			ui.WaveTabs.SelectedTab.Text = CurrentChannel.GetName();
		}
	}
}
