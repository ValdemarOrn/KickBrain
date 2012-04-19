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
				view.Height = 257;
				view.Width = ui.Width - 50;
				view.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right))); // Resize waveView with the window
				view.ZoomX = Convert.ToDouble(ui.textBoxZoomX.Text);
				view.RefreshRate = Convert.ToDouble(ui.textBoxRefresh.Text);

				// subscribe to the channel's data event
				channel.DataEvent += view.AddData;

				// Subscribe to the trigger event
				channel.TriggerEvent += this.Trigger;
				channel.TriggerEvent += view.Trigger;

				var page = new TabPage("Port: " + channel.Input.Name + " Channel " + channel.Channel);
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
				var lp = Convert.ToDouble(ui.textBoxLowpass.Text);
				config.LowpassFrequency = (lp < 1.0) ? lp : 1.0;
				var hp = Convert.ToDouble(ui.textBoxHighpass.Text);
				config.HighpassFrequency = (hp < 1.0) ? hp : 1.0;
				config.SlewRate = Convert.ToSingle(ui.textBoxSlewRate.Text);
				config.SlewFactor = Convert.ToSingle(ui.textBoxSlewFactor.Text);

				config.Gain = Convert.ToDouble(ui.textBoxGain.Text);
				config.Threshold = Convert.ToDouble(ui.textBoxThreshold.Text);

				config.TriggerHold = Convert.ToInt32(ui.textBoxTriggerHold.Text);
				config.TriggerThreshold = Convert.ToDouble(ui.textBoxTriggerThreshold.Text);
				config.TriggerFactor = Convert.ToDouble(ui.textBoxTriggerFactor.Text);
				config.TriggerBlock = Convert.ToInt32(ui.textBoxTriggerBlock.Text);

				config.HighpassEnabled = ui.checkBoxHighpass.Checked;
				config.LowpassEnabled = ui.checkBoxLowpass.Checked;
				config.SlewRateEnabled = ui.checkBoxSlewRate.Checked;
				config.SlewFactorEnabled = ui.checkBoxSlewFactor.Checked;
				config.CurveEnabled = ui.checkBoxCurve.Checked;

				config.Enabled = ui.checkBoxEnabled.Checked;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in input values. \n" + ex.Message);
			}

			CurrentChannel.Config = config;

			LoadChannelConfig(CurrentChannel.Config);
		}

		public void SetActiveChannel(WaveChannel channel)
		{
			CurrentChannel = ((WaveView)(ui.WaveTabs.SelectedTab.Controls[0])).Channel;
			LoadChannelConfig(CurrentChannel.Config);
		}

		public void LoadChannelConfig(WaveChannelConfig config)
		{
			ui.checkBoxEnabled.Checked = config.Enabled;

			ui.textBoxHighpass.Text = Math.Round(config.HighpassFrequency, 4).ToString();
			ui.textBoxSlewRate.Text = Math.Round(config.SlewRate, 4).ToString();
			ui.textBoxSlewFactor.Text = Math.Round(config.SlewFactor, 4).ToString();
			ui.textBoxLowpass.Text = Math.Round(config.LowpassFrequency, 4).ToString();

			ui.textBoxGain.Text = Math.Round(config.Gain, 4).ToString();
			ui.textBoxThreshold.Text = Math.Round(config.Threshold, 4).ToString();

			ui.textBoxTriggerHold.Text = config.TriggerHold.ToString();
			ui.textBoxTriggerThreshold.Text = config.TriggerThreshold.ToString();
			ui.textBoxTriggerFactor.Text = Math.Round(config.TriggerFactor, 4).ToString();
			ui.textBoxTriggerBlock.Text = config.TriggerBlock.ToString();

			ui.checkBoxHighpass.Checked = config.HighpassEnabled;
			ui.checkBoxLowpass.Checked = config.LowpassEnabled;
			ui.checkBoxSlewRate.Checked = config.SlewRateEnabled;
			ui.checkBoxSlewFactor.Checked = config.SlewFactorEnabled;
			ui.checkBoxCurve.Checked = config.CurveEnabled;
		}

		public void SetChannelEnabled(bool enabled)
		{
			CurrentChannel.Config.Enabled = enabled;
		}

		public void AddInput()
		{
			KickBrain.KB.AddInput();
		}
	}
}
