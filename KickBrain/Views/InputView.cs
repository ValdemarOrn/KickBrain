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

		public InputView()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

			InitializeComponent();

			Ctrl = new InputController(this);
			Views = new List<WaveView>();
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

		public void WaveTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			Ctrl.LoadInput(this.TabControlWaves.SelectedIndex);
		}

		private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			Ctrl.PropertyChanged();
			Brain.KB.ui.Ctrl.SetLabelNames();
		}

		private void InputView_VisibleChanged(object sender, EventArgs e)
		{
			if (!Visible)
			{
				// Remove all triggers
				Brain.KB.Sources.DetachAllEvents(Ctrl.Trigger);

				foreach (var view in Views)
				{
					Brain.KB.Sources.DetachAllEvents(view.AddData);
					Brain.KB.Sources.DetachAllEvents(view.Trigger);
				}

				return;
			}

			Ctrl.LoadInputs();

			Ctrl.LoadInput(Ctrl.SelectedIndex);
		}
	}
}
