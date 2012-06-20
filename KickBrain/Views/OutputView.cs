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

		public OutputView()
		{
			InitializeComponent();
			Ctrl = new OutputController(this);
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

		private void comboBoxSignal_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
