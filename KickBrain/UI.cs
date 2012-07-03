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
		public OutputView OutputView;

		public UI()
		{
			InitializeComponent();
			InputView = new InputView();
			SignalView = new SignalView();
			OutputView = new OutputView();

			Controls.Add(InputView);
			Controls.Add(SignalView);
			Controls.Add(OutputView);

			InputView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			SignalView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			OutputView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

			InputView.Top = 80;
			InputView.Left = 15;
			InputView.Width = ClientSize.Width - 2*15;
			InputView.Height = ClientSize.Height - 80 - 15;
			InputView.Visible = true;
			InputView.Hide();

			SignalView.Top = 80;
			SignalView.Left = 15;
			SignalView.Width = ClientSize.Width - 2 * 15;
			SignalView.Height = ClientSize.Height - 80 - 15;
			SignalView.Visible = true;
			SignalView.Hide();

			OutputView.Top = 80;
			OutputView.Left = 15;
			OutputView.Width = ClientSize.Width - 2 * 15;
			OutputView.Height = ClientSize.Height - 80 - 15;
			OutputView.Visible = true;
			OutputView.Hide();

			ChangePage(LabelInputs, null);
		}

		private void ChangePage(object sender, EventArgs e)
		{
			this.InputView.Hide();
			this.SignalView.Hide();
			this.OutputView.Hide();

			if (sender == LabelInputs)
				InputView.Show();
			else if (sender == labelSignals)
			{
				SignalView.Show();
			}
			else if (sender == labelOutputs)
			{
				OutputView.Show();
			}
		}

		private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var xml = Brain.KB.ToXML();
			var doc = new System.Xml.XmlDocument();
			doc.LoadXml(xml);
			var sw = new System.IO.StringWriter();
			var xtw = new System.Xml.XmlTextWriter(sw);
			xtw.Formatting = System.Xml.Formatting.Indented;
			doc.WriteTo(xtw);

			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "XML File|*.xml";
			saveFileDialog1.Title = "Save Configuration";
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.ShowDialog();

			if (saveFileDialog1.FileName == "")
				return;

			System.IO.File.WriteAllText(saveFileDialog1.FileName, sw.ToString());
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool connected = Brain.KB.Configure();

			if (!connected)
				return;

			InputView.Ctrl.UpdateControls();
		}

		private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = "c:\\" ;
			openFileDialog1.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*" ;
			openFileDialog1.FilterIndex = 0 ;
			openFileDialog1.RestoreDirectory = true ;

			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;

			var xml = System.IO.File.ReadAllText(openFileDialog1.FileName);
			Brain.KB.FromXML(xml);
		}
	}
}
