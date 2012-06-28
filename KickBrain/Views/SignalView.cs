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
		public Timer TriggerTimer;

		public SignalView()
		{
			InitializeComponent();
			Ctrl = new SignalController(this);

			TriggerTimer = new Timer();
			TriggerTimer.Interval = 100;
			TriggerTimer.Tick += new EventHandler(delegate(object sender, EventArgs e){checkBoxTriggerOn.Checked = false;});
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			Ctrl.AddSignal();
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{

		}

		private void listBoxSignals_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!Visible)
				return;

			//Ctrl.SaveSignal();
			Ctrl.LoadChannel(listBoxSignals.SelectedIndex);
		}

		private void SignalView_VisibleChanged(object sender, EventArgs e)
		{
			if (!Visible)
			{
				Brain.KB.Sources.DetachAllEvents(Ctrl.Trigger);
				return;
			}

			Ctrl.LoadSignalChannels();
			Ctrl.LoadSignals();
			Ctrl.LoadEvents();
			Ctrl.LoadModes();
			Ctrl.LoadChannel(Ctrl.SelectedIndex);
			listBoxSignals.SelectedIndex = Ctrl.SelectedIndex;
			
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Ctrl.SaveSignal();
			Ctrl.LoadSignalChannels();
		}

		private void comboBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)
		{
			Ctrl.ConnectEvent();
		}
	}
}
