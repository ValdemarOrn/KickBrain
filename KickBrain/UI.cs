﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SerialAudio
{
	public partial class UI : Form
	{
		public List<WaveView> Views;
		public UIController Ctrl;

		Timer TriggerRefreshTimer;

		public UI()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

			InitializeComponent();

			Ctrl = new UIController(this);
			Views = new List<WaveView>();

			TriggerRefreshTimer = new Timer();
			TriggerRefreshTimer.Tick += delegate(object sender, EventArgs e) 
				{ progressBarVelocity.Value = (int)(0.9 * progressBarVelocity.Value); };

			TriggerRefreshTimer.Interval = 1000 / 30;
			TriggerRefreshTimer.Start();
		}

		private void buttonZoomX_Click(object sender, EventArgs e)
		{
			double zoom = 1.0;

			try
			{
				zoom = Convert.ToDouble(textBoxZoomX.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to read zoom value: " + textBoxZoomX.Text);
				return;
			}

			Ctrl.SetZoom(zoom);
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			double rate = 30.0;

			try
			{
				rate = Convert.ToDouble(textBoxRefresh.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to read refresh rate value: " + textBoxRefresh.Text);
				return;
			}

			Ctrl.SetZoom(rate);
		}

		private void buttonAddPort_Click(object sender, EventArgs e)
		{
			Ctrl.AddInput();
		}

		public void button1_Click(object sender, EventArgs e)
		{
			Ctrl.SetConfig();
		}

		public void WaveTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			var channel = ((WaveView)(WaveTabs.SelectedTab.Controls[0])).Channel;
			Ctrl.SetActiveChannel(channel);
		}

		private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Ctrl.SetChannelEnabled(checkBoxEnabled.Checked);
		}
	}
}
