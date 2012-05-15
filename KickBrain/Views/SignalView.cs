using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KickBrain.Controllers;

namespace KickBrain.Views
{
	public partial class SignalView : UserControl
	{
		public SignalController Ctrl;

		public SignalView()
		{
			InitializeComponent();
			Ctrl = new SignalController(this);
			//Ctrl.LoadAllSignals();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			Ctrl.AddSignal();
		}

		private void listBoxSignals_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!Visible)
				return;

			//Ctrl.SaveSignal();
			Ctrl.LoadSignal(listBoxSignals.SelectedIndex);
		}

		private void SignalView_VisibleChanged(object sender, EventArgs e)
		{
			Ctrl.LoadAllSources();
			Ctrl.LoadSignal(Ctrl.SelectedIndex);
			listBoxSignals.SelectedIndex = Ctrl.SelectedIndex;
			
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Ctrl.SaveSignal();
			Ctrl.LoadAllSources();
		}

		private void comboBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)
		{
			Ctrl.ConnectTrigger();
		}
	}
}
