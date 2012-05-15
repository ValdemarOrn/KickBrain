using KickBrain.Views;
namespace KickBrain
{
	partial class UI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LabelInputs = new System.Windows.Forms.Label();
			this.labelSignals = new System.Windows.Forms.Label();
			this.labelOutputs = new System.Windows.Forms.Label();
			this.InputView = new KickBrain.Views.InputView();
			this.SignalView = new KickBrain.Views.SignalView();
			this.SuspendLayout();
			// 
			// LabelInputs
			// 
			this.LabelInputs.AutoSize = true;
			this.LabelInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelInputs.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LabelInputs.Location = new System.Drawing.Point(23, 16);
			this.LabelInputs.Name = "LabelInputs";
			this.LabelInputs.Size = new System.Drawing.Size(60, 24);
			this.LabelInputs.TabIndex = 1;
			this.LabelInputs.Text = "Inputs";
			this.LabelInputs.Click += new System.EventHandler(this.ChangePage);
			// 
			// labelSignals
			// 
			this.labelSignals.AutoSize = true;
			this.labelSignals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSignals.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.labelSignals.Location = new System.Drawing.Point(118, 16);
			this.labelSignals.Name = "labelSignals";
			this.labelSignals.Size = new System.Drawing.Size(71, 24);
			this.labelSignals.TabIndex = 2;
			this.labelSignals.Text = "Signals";
			this.labelSignals.Click += new System.EventHandler(this.ChangePage);
			// 
			// labelOutputs
			// 
			this.labelOutputs.AutoSize = true;
			this.labelOutputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelOutputs.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.labelOutputs.Location = new System.Drawing.Point(224, 16);
			this.labelOutputs.Name = "labelOutputs";
			this.labelOutputs.Size = new System.Drawing.Size(75, 24);
			this.labelOutputs.TabIndex = 3;
			this.labelOutputs.Text = "Outputs";
			this.labelOutputs.Click += new System.EventHandler(this.ChangePage);
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(976, 544);
			this.Controls.Add(this.labelOutputs);
			this.Controls.Add(this.labelSignals);
			this.Controls.Add(this.LabelInputs);
			this.Controls.Add(this.SignalView);
			this.Controls.Add(this.InputView);
			this.MinimumSize = new System.Drawing.Size(992, 525);
			this.Name = "UI";
			this.Text = "KickBrain";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public InputView InputView;
		private System.Windows.Forms.Label LabelInputs;
		private System.Windows.Forms.Label labelSignals;
		private System.Windows.Forms.Label labelOutputs;
		private SignalView SignalView;




	}
}