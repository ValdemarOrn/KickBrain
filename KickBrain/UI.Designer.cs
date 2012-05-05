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
			this.textBoxZoomX = new System.Windows.Forms.TextBox();
			this.buttonZoomX = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.textBoxRefresh = new System.Windows.Forms.TextBox();
			this.WaveTabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonAddPort = new System.Windows.Forms.Button();
			this.progressBarVelocity = new System.Windows.Forms.ProgressBar();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxVelocity = new System.Windows.Forms.TextBox();
			this.textBoxHits = new System.Windows.Forms.TextBox();
			this.textBoxByteRate = new System.Windows.Forms.TextBox();
			this.textBoxSamplerate = new System.Windows.Forms.TextBox();
			this.velocityMapControl1 = new AudioLib.UI.VelocityMapControl();
			this.WaveTabs.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxZoomX
			// 
			this.textBoxZoomX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxZoomX.Location = new System.Drawing.Point(12, 307);
			this.textBoxZoomX.Name = "textBoxZoomX";
			this.textBoxZoomX.Size = new System.Drawing.Size(65, 20);
			this.textBoxZoomX.TabIndex = 0;
			this.textBoxZoomX.Text = "0.1";
			// 
			// buttonZoomX
			// 
			this.buttonZoomX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonZoomX.Location = new System.Drawing.Point(93, 305);
			this.buttonZoomX.Name = "buttonZoomX";
			this.buttonZoomX.Size = new System.Drawing.Size(105, 23);
			this.buttonZoomX.TabIndex = 1;
			this.buttonZoomX.Text = "Zoom X";
			this.buttonZoomX.UseVisualStyleBackColor = true;
			this.buttonZoomX.Click += new System.EventHandler(this.buttonZoomX_Click);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Location = new System.Drawing.Point(93, 349);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(105, 23);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.Text = "Refresh Rate";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// textBoxRefresh
			// 
			this.textBoxRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxRefresh.Location = new System.Drawing.Point(12, 351);
			this.textBoxRefresh.Name = "textBoxRefresh";
			this.textBoxRefresh.Size = new System.Drawing.Size(65, 20);
			this.textBoxRefresh.TabIndex = 2;
			this.textBoxRefresh.Text = "30";
			// 
			// WaveTabs
			// 
			this.WaveTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WaveTabs.Controls.Add(this.tabPage1);
			this.WaveTabs.Location = new System.Drawing.Point(12, 12);
			this.WaveTabs.Multiline = true;
			this.WaveTabs.Name = "WaveTabs";
			this.WaveTabs.SelectedIndex = 0;
			this.WaveTabs.Size = new System.Drawing.Size(703, 258);
			this.WaveTabs.TabIndex = 6;
			this.WaveTabs.SelectedIndexChanged += new System.EventHandler(this.WaveTabs_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(695, 232);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "NoChannels";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// buttonAddPort
			// 
			this.buttonAddPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddPort.Location = new System.Drawing.Point(93, 393);
			this.buttonAddPort.Name = "buttonAddPort";
			this.buttonAddPort.Size = new System.Drawing.Size(105, 23);
			this.buttonAddPort.TabIndex = 7;
			this.buttonAddPort.Text = "Configure";
			this.buttonAddPort.UseVisualStyleBackColor = true;
			this.buttonAddPort.Click += new System.EventHandler(this.buttonConfigure_Click);
			// 
			// progressBarVelocity
			// 
			this.progressBarVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressBarVelocity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.progressBarVelocity.Location = new System.Drawing.Point(93, 436);
			this.progressBarVelocity.Maximum = 10000;
			this.progressBarVelocity.Name = "progressBarVelocity";
			this.progressBarVelocity.Size = new System.Drawing.Size(105, 23);
			this.progressBarVelocity.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBarVelocity.TabIndex = 9;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(721, 32);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(243, 427);
			this.propertyGrid1.TabIndex = 12;
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(328, 291);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Velocity";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(328, 335);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "# Hits";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(328, 379);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Serial bytes / sec.";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(328, 423);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Samplerate";
			// 
			// textBoxVelocity
			// 
			this.textBoxVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxVelocity.Location = new System.Drawing.Point(328, 307);
			this.textBoxVelocity.Name = "textBoxVelocity";
			this.textBoxVelocity.Size = new System.Drawing.Size(100, 20);
			this.textBoxVelocity.TabIndex = 17;
			// 
			// textBoxHits
			// 
			this.textBoxHits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxHits.Location = new System.Drawing.Point(328, 351);
			this.textBoxHits.Name = "textBoxHits";
			this.textBoxHits.Size = new System.Drawing.Size(100, 20);
			this.textBoxHits.TabIndex = 18;
			// 
			// textBoxByteRate
			// 
			this.textBoxByteRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxByteRate.Location = new System.Drawing.Point(328, 395);
			this.textBoxByteRate.Name = "textBoxByteRate";
			this.textBoxByteRate.Size = new System.Drawing.Size(100, 20);
			this.textBoxByteRate.TabIndex = 19;
			// 
			// textBoxSamplerate
			// 
			this.textBoxSamplerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSamplerate.Location = new System.Drawing.Point(328, 439);
			this.textBoxSamplerate.Name = "textBoxSamplerate";
			this.textBoxSamplerate.Size = new System.Drawing.Size(100, 20);
			this.textBoxSamplerate.TabIndex = 20;
			// 
			// velocityMapControl1
			// 
			this.velocityMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.velocityMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.velocityMapControl1.Location = new System.Drawing.Point(446, 276);
			this.velocityMapControl1.Name = "velocityMapControl1";
			this.velocityMapControl1.Size = new System.Drawing.Size(267, 183);
			this.velocityMapControl1.TabIndex = 21;
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(976, 487);
			this.Controls.Add(this.velocityMapControl1);
			this.Controls.Add(this.textBoxSamplerate);
			this.Controls.Add(this.textBoxByteRate);
			this.Controls.Add(this.textBoxHits);
			this.Controls.Add(this.textBoxVelocity);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.progressBarVelocity);
			this.Controls.Add(this.buttonAddPort);
			this.Controls.Add(this.WaveTabs);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.textBoxRefresh);
			this.Controls.Add(this.buttonZoomX);
			this.Controls.Add(this.textBoxZoomX);
			this.MinimumSize = new System.Drawing.Size(992, 525);
			this.Name = "UI";
			this.Text = "KickBrain";
			this.WaveTabs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonZoomX;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonAddPort;
		internal System.Windows.Forms.TextBox textBoxZoomX;
		internal System.Windows.Forms.TextBox textBoxRefresh;
		internal System.Windows.Forms.ProgressBar progressBarVelocity;
		internal System.Windows.Forms.TabControl WaveTabs;
		internal System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox textBoxVelocity;
		internal System.Windows.Forms.TextBox textBoxHits;
		internal System.Windows.Forms.TextBox textBoxByteRate;
		internal System.Windows.Forms.TextBox textBoxSamplerate;
		internal AudioLib.UI.VelocityMapControl velocityMapControl1;
		private System.Windows.Forms.TabPage tabPage1;
	}
}