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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// LabelInputs
			// 
			this.LabelInputs.AutoSize = true;
			this.LabelInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelInputs.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LabelInputs.Location = new System.Drawing.Point(23, 34);
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
			this.labelSignals.Location = new System.Drawing.Point(118, 34);
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
			this.labelOutputs.Location = new System.Drawing.Point(224, 34);
			this.labelOutputs.Name = "labelOutputs";
			this.labelOutputs.Size = new System.Drawing.Size(75, 24);
			this.labelOutputs.TabIndex = 3;
			this.labelOutputs.Text = "Outputs";
			this.labelOutputs.Click += new System.EventHandler(this.ChangePage);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(976, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigurationToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadConfigurationToolStripMenuItem
			// 
			this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
			this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
			this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.loadConfigurationToolStripMenuItem_Click);
			// 
			// saveConfigurationToolStripMenuItem
			// 
			this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
			this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
			this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(976, 570);
			this.Controls.Add(this.labelOutputs);
			this.Controls.Add(this.labelSignals);
			this.Controls.Add(this.LabelInputs);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(992, 525);
			this.Name = "UI";
			this.Text = "KickBrain";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelInputs;
		private System.Windows.Forms.Label labelSignals;
		private System.Windows.Forms.Label labelOutputs;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}