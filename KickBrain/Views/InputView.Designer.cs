namespace KickBrain.Views
{
	partial class InputView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxSamplerate = new System.Windows.Forms.TextBox();
			this.textBoxByteRate = new System.Windows.Forms.TextBox();
			this.textBoxHits = new System.Windows.Forms.TextBox();
			this.textBoxVelocity = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.TabControlWaves = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonZoomX = new System.Windows.Forms.Button();
			this.textBoxZoomX = new System.Windows.Forms.TextBox();
			this.velocityMapControl1 = new AudioLib.UI.VelocityMapControl();
			this.TabControlWaves.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxSamplerate
			// 
			this.textBoxSamplerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSamplerate.Location = new System.Drawing.Point(289, 490);
			this.textBoxSamplerate.Name = "textBoxSamplerate";
			this.textBoxSamplerate.Size = new System.Drawing.Size(100, 20);
			this.textBoxSamplerate.TabIndex = 37;
			// 
			// textBoxByteRate
			// 
			this.textBoxByteRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxByteRate.Location = new System.Drawing.Point(289, 446);
			this.textBoxByteRate.Name = "textBoxByteRate";
			this.textBoxByteRate.Size = new System.Drawing.Size(100, 20);
			this.textBoxByteRate.TabIndex = 36;
			// 
			// textBoxHits
			// 
			this.textBoxHits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxHits.Location = new System.Drawing.Point(289, 402);
			this.textBoxHits.Name = "textBoxHits";
			this.textBoxHits.Size = new System.Drawing.Size(100, 20);
			this.textBoxHits.TabIndex = 35;
			// 
			// textBoxVelocity
			// 
			this.textBoxVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxVelocity.Location = new System.Drawing.Point(289, 358);
			this.textBoxVelocity.Name = "textBoxVelocity";
			this.textBoxVelocity.Size = new System.Drawing.Size(100, 20);
			this.textBoxVelocity.TabIndex = 34;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(289, 474);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 33;
			this.label4.Text = "Samplerate";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(289, 430);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 32;
			this.label3.Text = "Serial bytes / sec.";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(289, 386);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "# Hits";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(289, 342);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 30;
			this.label1.Text = "Velocity";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(702, 32);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(243, 478);
			this.propertyGrid1.TabIndex = 29;
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
			// 
			// TabControlWaves
			// 
			this.TabControlWaves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabControlWaves.Controls.Add(this.tabPage1);
			this.TabControlWaves.Location = new System.Drawing.Point(8, 12);
			this.TabControlWaves.Name = "TabControlWaves";
			this.TabControlWaves.SelectedIndex = 0;
			this.TabControlWaves.Size = new System.Drawing.Size(688, 309);
			this.TabControlWaves.TabIndex = 26;
			this.TabControlWaves.SelectedIndexChanged += new System.EventHandler(this.WaveTabs_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(680, 283);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "NoChannels";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// buttonZoomX
			// 
			this.buttonZoomX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonZoomX.Location = new System.Drawing.Point(89, 356);
			this.buttonZoomX.Name = "buttonZoomX";
			this.buttonZoomX.Size = new System.Drawing.Size(105, 23);
			this.buttonZoomX.TabIndex = 23;
			this.buttonZoomX.Text = "Zoom X";
			this.buttonZoomX.UseVisualStyleBackColor = true;
			this.buttonZoomX.Click += new System.EventHandler(this.buttonZoomX_Click);
			// 
			// textBoxZoomX
			// 
			this.textBoxZoomX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxZoomX.Location = new System.Drawing.Point(8, 358);
			this.textBoxZoomX.Name = "textBoxZoomX";
			this.textBoxZoomX.Size = new System.Drawing.Size(65, 20);
			this.textBoxZoomX.TabIndex = 22;
			this.textBoxZoomX.Text = "0.1";
			// 
			// velocityMapControl1
			// 
			this.velocityMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.velocityMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.velocityMapControl1.Location = new System.Drawing.Point(410, 327);
			this.velocityMapControl1.Map = null;
			this.velocityMapControl1.Name = "velocityMapControl1";
			this.velocityMapControl1.Size = new System.Drawing.Size(285, 183);
			this.velocityMapControl1.TabIndex = 38;
			// 
			// InputView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
			this.Controls.Add(this.TabControlWaves);
			this.Controls.Add(this.buttonZoomX);
			this.Controls.Add(this.textBoxZoomX);
			this.Name = "InputView";
			this.Size = new System.Drawing.Size(953, 513);
			this.VisibleChanged += new System.EventHandler(this.InputView_VisibleChanged);
			this.TabControlWaves.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal AudioLib.UI.VelocityMapControl velocityMapControl1;
		internal System.Windows.Forms.TextBox textBoxSamplerate;
		internal System.Windows.Forms.TextBox textBoxByteRate;
		internal System.Windows.Forms.TextBox textBoxHits;
		internal System.Windows.Forms.TextBox textBoxVelocity;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.PropertyGrid propertyGrid1;
		internal System.Windows.Forms.TabControl TabControlWaves;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button buttonZoomX;
		internal System.Windows.Forms.TextBox textBoxZoomX;
	}
}
