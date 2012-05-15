using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KickBrain.Views;

namespace KickBrain
{
	public partial class UI : Form
	{
		public InputView InputView;
		public SignalView SignalView;

		public UI()
		{
			InitializeComponent();
			InputView = new InputView();
			SignalView = new SignalView();

			Controls.Add(InputView);
			Controls.Add(SignalView);

			InputView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			SignalView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

			InputView.Top = 60;
			InputView.Left = 15;
			InputView.Width = ClientSize.Width - 2*15;
			InputView.Height = ClientSize.Height - 60 - 15;
			InputView.Visible = true;
			InputView.Hide();

			SignalView.Top = 60;
			SignalView.Left = 15;
			SignalView.Width = ClientSize.Width - 2 * 15;
			SignalView.Height = ClientSize.Height - 60 - 15;
			SignalView.Visible = true;
			SignalView.Hide();
		}

		private void ChangePage(object sender, EventArgs e)
		{
			this.InputView.Hide();
			this.SignalView.Hide();

			if (sender == LabelInputs)
				InputView.Show();
			else if (sender == labelSignals)
			{
				SignalView.Show();
			}
		}
	}
}
