using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialAudio
{
	public class UIController
	{
		public UI ui;
		public WaveChannel CurrentChannel;

		public UIController(UI form)
		{
			this.ui = form;
		}

		public void AddWiew(WaveChannel channel)
		{
			try
			{
				// Invoke from main thread
				Action<WaveChannel> AddDele = AddWiew;
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
				view.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right))); // Resize waveView with the window
				view.ZoomX = Convert.ToDouble(ui.textBoxZoomX.Text);
				view.RefreshRate = Convert.ToDouble(ui.textBoxRefresh.Text);

				// subscribe to the channel's data event
				channel.DataEvent += view.AddData;

				// Subscribe to the trigger event
				channel.TriggerEvent += this.Trigger;
				channel.TriggerEvent += view.Trigger;

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

		public void Trigger(WaveChannel sender, double velocity)
		{
			if (sender != this.CurrentChannel)
				return;

			// Invoke from main thread
			Action<WaveChannel, double> TriggerDele = Trigger;
			if (ui.InvokeRequired)
			{
				ui.Invoke(TriggerDele, new object[] { sender, velocity });
				return;
			}

			if (velocity == 0.0)
				return;

			double barValue = velocity * ui.progressBarVelocity.Maximum;
			if (barValue > ui.progressBarVelocity.Maximum)
				barValue = ui.progressBarVelocity.Maximum;
			ui.progressBarVelocity.Value = (int)(barValue);

			ui.labelVelocity.Text = Math.Round(velocity, 3).ToString();
			ui.labelCount.Text = (Convert.ToInt32(ui.labelCount.Text) + 1).ToString();
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

		public void SetConfig()
		{
			var config = new WaveChannelConfig();

			try
			{
				config.DecayRate = Convert.ToSingle(ui.textBoxSlewRate.Text);

				config.Gain = Convert.ToDouble(ui.textBoxGain.Text);
				config.NoiseFloor = Convert.ToDouble(ui.textBoxNoiseFloor.Text);

				config.TriggerAttack = Convert.ToInt32(ui.textBoxTriggerAttack.Text);
				config.TriggerLength = Convert.ToInt32(ui.textBoxTriggerLength.Text);
				config.TriggerThreshold = Convert.ToDouble(ui.textBoxTriggerThreshold.Text);
				config.TriggerScale = Convert.ToDouble(ui.textBoxTriggerScale.Text);
				config.TriggerRetrigger = Convert.ToInt32(ui.textBoxTriggerBlock.Text);

				config.CCHisteresis = Convert.ToDouble(ui.textBoxCCHisteresis.Text);
				config.CCAverage = Convert.ToInt32(ui.textBoxCCAverage.Text);

				config.Enabled = ui.checkBoxEnabled.Checked;
				config.ContinuousControl = ui.checkBoxContinousControl.Checked;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in input values. \n" + ex.Message);
			}

			CurrentChannel.Config = config;

			LoadChannelConfig(CurrentChannel.Config);
		}

		public void SetActiveChannel()
		{
			SetActiveChannel(ui.WaveTabs.SelectedIndex);
		}

		public void SetActiveChannel(int channel)
		{
			CurrentChannel = ((WaveView)(ui.WaveTabs.SelectedTab.Controls[0])).Channel;
			LoadChannelConfig(CurrentChannel.Config);
		}

		public void LoadChannelConfig(WaveChannelConfig config)
		{
			ui.propertyGrid1.SelectedObject = config;

			ui.checkBoxEnabled.Checked = config.Enabled;

			ui.textBoxSlewRate.Text = Math.Round(config.DecayRate, 4).ToString();

			ui.textBoxGain.Text = Math.Round(config.Gain, 4).ToString();
			ui.textBoxNoiseFloor.Text = Math.Round(config.NoiseFloor, 4).ToString();

			ui.textBoxTriggerAttack.Text = config.TriggerAttack.ToString();
			ui.textBoxTriggerLength.Text = config.TriggerLength.ToString();
			ui.textBoxTriggerThreshold.Text = config.TriggerThreshold.ToString();
			ui.textBoxTriggerScale.Text = Math.Round(config.TriggerScale, 4).ToString();
			ui.textBoxTriggerBlock.Text = config.TriggerRetrigger.ToString();

			ui.textBoxCCHisteresis.Text = config.CCHisteresis.ToString();
			ui.textBoxCCAverage.Text = config.CCAverage.ToString();

			ui.checkBoxContinousControl.Checked = config.ContinuousControl;
		}

		public void SetChannelEnabled(bool enabled)
		{
			CurrentChannel.Config.Enabled = enabled;
		}

		public void Configure()
		{
			ui.WaveTabs.TabPages.Clear();

			KickBrain.KB.Configure();

			foreach (WaveChannel channel in KickBrain.KB.Input.Channels)
				ui.Ctrl.AddWiew(channel);

			// initialize processing values
			ui.Ctrl.SetActiveChannel(0);
		}
	}
}
