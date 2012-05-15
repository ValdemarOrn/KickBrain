using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using KickBrain.Controllers;

namespace KickBrain.Views
{
	public partial class InputView : UserControl
	{
		public List<WaveView> Views;
		public InputController Ctrl;

		Timer TriggerRefreshTimer;

		public InputView()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

			InitializeComponent();

			Ctrl = new InputController(this);
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

			Ctrl.SetRefresh(rate);
		}

		private void buttonConfigure_Click(object sender, EventArgs e)
		{
			Ctrl.Configure();
		}

		public void WaveTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			Ctrl.SetActiveChannel();
		}

		private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			Ctrl.PropertyChanged();

		}
	}
}
