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
	public partial class OutputView : UserControl
	{
		public OutputController Ctrl;
		public Timer TriggerTimer;

		public List<TextBox> CrosstalkFactors;
		public List<ComboBox> CrosstalkSignals;
		public List<Label> CrosstalkLabels;

		public OutputView()
		{
			InitializeComponent();
			Ctrl = new OutputController(this);

			CrosstalkFactors = new List<TextBox>();
			CrosstalkSignals = new List<ComboBox>();
			CrosstalkLabels = new List<Label>();

			TriggerTimer = new Timer();
			TriggerTimer.Interval = 100;
			TriggerTimer.Tick += new EventHandler(delegate(object sender, EventArgs e) { checkBoxTriggerOn.Checked = false; });
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{

		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{

		}

		private void listBoxSignals_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void buttonAdd_Click_1(object sender, EventArgs e)
		{
			Ctrl.AddOutput();
		}

		private void OutputView_VisibleChanged(object sender, EventArgs e)
		{
			if (!Visible)
			{
				Brain.KB.Sources.DetachAllEvents(Ctrl.Trigger);
				return;
			}

			Ctrl.LoadOutputs();
			Ctrl.LoadSignals();
			Ctrl.LoadEvents();

			Ctrl.LoadOutput(Ctrl.SelectedIndex);
			listBoxOutputs.SelectedIndex = Ctrl.SelectedIndex;
		}

		private void listBoxOutputs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!Visible)
				return;

			Ctrl.LoadOutput(listBoxOutputs.SelectedIndex);
		}

		private void Save(object sender, EventArgs e)
		{
			Ctrl.SaveOutput();
			Ctrl.LoadOutputs();
		}

		private void buttonAddCrosstalk_Click(object sender, EventArgs e)
		{
			if (comboBoxCrosstalk.SelectedIndex == -1)
				return;

			Ctrl.AddCrosstalk(comboBoxCrosstalk.SelectedIndex);
		}

		private void buttonRemove_Click_1(object sender, EventArgs e)
		{
			Ctrl.RemoveOutput();
		}
	}
}
