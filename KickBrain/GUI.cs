using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace KickBrain
{
	public partial class UI : Form
	{
		public UI()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

			InitializeComponent();
		}

		private void ChangePage(object sender, EventArgs e)
		{
			this.InputView.Hide();

			if (sender == LabelInputs)
				this.InputView.Show();
		}
	}
}
