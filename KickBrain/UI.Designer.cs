namespace SerialAudio
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
			this.buttonAddPort = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBoxSlewFactor = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxSlewFactor = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxTriggerBlock = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxTriggerFactor = new System.Windows.Forms.TextBox();
			this.textBoxTriggerThreshold = new System.Windows.Forms.TextBox();
			this.textBoxTriggerHold = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxThreshold = new System.Windows.Forms.TextBox();
			this.checkBoxCurve = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxGain = new System.Windows.Forms.TextBox();
			this.checkBoxLowpass = new System.Windows.Forms.CheckBox();
			this.checkBoxSlewRate = new System.Windows.Forms.CheckBox();
			this.checkBoxHighpass = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxLowpass = new System.Windows.Forms.TextBox();
			this.textBoxSlewRate = new System.Windows.Forms.TextBox();
			this.textBoxHighpass = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.progressBarVelocity = new System.Windows.Forms.ProgressBar();
			this.labelVelocity = new System.Windows.Forms.Label();
			this.labelCount = new System.Windows.Forms.Label();
			this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxZoomX
			// 
			this.textBoxZoomX.Location = new System.Drawing.Point(12, 316);
			this.textBoxZoomX.Name = "textBoxZoomX";
			this.textBoxZoomX.Size = new System.Drawing.Size(65, 20);
			this.textBoxZoomX.TabIndex = 0;
			this.textBoxZoomX.Text = "0.1";
			// 
			// buttonZoomX
			// 
			this.buttonZoomX.Location = new System.Drawing.Point(93, 314);
			this.buttonZoomX.Name = "buttonZoomX";
			this.buttonZoomX.Size = new System.Drawing.Size(105, 23);
			this.buttonZoomX.TabIndex = 1;
			this.buttonZoomX.Text = "Zoom X";
			this.buttonZoomX.UseVisualStyleBackColor = true;
			this.buttonZoomX.Click += new System.EventHandler(this.buttonZoomX_Click);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Location = new System.Drawing.Point(93, 343);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(105, 23);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.Text = "Refresh Rate";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// textBoxRefresh
			// 
			this.textBoxRefresh.Location = new System.Drawing.Point(12, 345);
			this.textBoxRefresh.Name = "textBoxRefresh";
			this.textBoxRefresh.Size = new System.Drawing.Size(65, 20);
			this.textBoxRefresh.TabIndex = 2;
			this.textBoxRefresh.Text = "30";
			// 
			// WaveTabs
			// 
			this.WaveTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WaveTabs.Location = new System.Drawing.Point(12, 12);
			this.WaveTabs.Multiline = true;
			this.WaveTabs.Name = "WaveTabs";
			this.WaveTabs.SelectedIndex = 0;
			this.WaveTabs.Size = new System.Drawing.Size(912, 286);
			this.WaveTabs.TabIndex = 6;
			this.WaveTabs.SelectedIndexChanged += new System.EventHandler(this.WaveTabs_SelectedIndexChanged);
			// 
			// buttonAddPort
			// 
			this.buttonAddPort.Location = new System.Drawing.Point(93, 372);
			this.buttonAddPort.Name = "buttonAddPort";
			this.buttonAddPort.Size = new System.Drawing.Size(105, 23);
			this.buttonAddPort.TabIndex = 7;
			this.buttonAddPort.Text = "Add Serial Port";
			this.buttonAddPort.UseVisualStyleBackColor = true;
			this.buttonAddPort.Click += new System.EventHandler(this.buttonAddPort_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBoxSlewFactor);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.textBoxSlewFactor);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.textBoxTriggerBlock);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBoxTriggerFactor);
			this.groupBox1.Controls.Add(this.textBoxTriggerThreshold);
			this.groupBox1.Controls.Add(this.textBoxTriggerHold);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBoxThreshold);
			this.groupBox1.Controls.Add(this.checkBoxCurve);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBoxGain);
			this.groupBox1.Controls.Add(this.checkBoxLowpass);
			this.groupBox1.Controls.Add(this.checkBoxSlewRate);
			this.groupBox1.Controls.Add(this.checkBoxHighpass);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxLowpass);
			this.groupBox1.Controls.Add(this.textBoxSlewRate);
			this.groupBox1.Controls.Add(this.textBoxHighpass);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(518, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(406, 220);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Processing";
			// 
			// checkBoxSlewFactor
			// 
			this.checkBoxSlewFactor.AutoSize = true;
			this.checkBoxSlewFactor.Location = new System.Drawing.Point(175, 136);
			this.checkBoxSlewFactor.Name = "checkBoxSlewFactor";
			this.checkBoxSlewFactor.Size = new System.Drawing.Size(15, 14);
			this.checkBoxSlewFactor.TabIndex = 31;
			this.checkBoxSlewFactor.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(17, 136);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 18);
			this.label12.TabIndex = 30;
			this.label12.Text = "Slew Factor";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxSlewFactor
			// 
			this.textBoxSlewFactor.Location = new System.Drawing.Point(103, 133);
			this.textBoxSlewFactor.Name = "textBoxSlewFactor";
			this.textBoxSlewFactor.Size = new System.Drawing.Size(66, 20);
			this.textBoxSlewFactor.TabIndex = 29;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(209, 136);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(103, 18);
			this.label11.TabIndex = 28;
			this.label11.Text = "Trigger Block";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxTriggerBlock
			// 
			this.textBoxTriggerBlock.Location = new System.Drawing.Point(318, 133);
			this.textBoxTriggerBlock.Name = "textBoxTriggerBlock";
			this.textBoxTriggerBlock.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerBlock.TabIndex = 27;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(209, 110);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 18);
			this.label8.TabIndex = 26;
			this.label8.Text = "Trigger Factor";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(197, 84);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(115, 18);
			this.label9.TabIndex = 25;
			this.label9.Text = "Trigger Threshold";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(209, 59);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(103, 18);
			this.label10.TabIndex = 24;
			this.label10.Text = "Trigger Hold";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxTriggerFactor
			// 
			this.textBoxTriggerFactor.Location = new System.Drawing.Point(318, 107);
			this.textBoxTriggerFactor.Name = "textBoxTriggerFactor";
			this.textBoxTriggerFactor.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerFactor.TabIndex = 23;
			// 
			// textBoxTriggerThreshold
			// 
			this.textBoxTriggerThreshold.Location = new System.Drawing.Point(318, 81);
			this.textBoxTriggerThreshold.Name = "textBoxTriggerThreshold";
			this.textBoxTriggerThreshold.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerThreshold.TabIndex = 22;
			// 
			// textBoxTriggerHold
			// 
			this.textBoxTriggerHold.Location = new System.Drawing.Point(318, 55);
			this.textBoxTriggerHold.Name = "textBoxTriggerHold";
			this.textBoxTriggerHold.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerHold.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(209, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 18);
			this.label7.TabIndex = 20;
			this.label7.Text = "Threshold";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxThreshold
			// 
			this.textBoxThreshold.Location = new System.Drawing.Point(318, 29);
			this.textBoxThreshold.Name = "textBoxThreshold";
			this.textBoxThreshold.Size = new System.Drawing.Size(66, 20);
			this.textBoxThreshold.TabIndex = 19;
			// 
			// checkBoxCurve
			// 
			this.checkBoxCurve.AutoSize = true;
			this.checkBoxCurve.Location = new System.Drawing.Point(175, 110);
			this.checkBoxCurve.Name = "checkBoxCurve";
			this.checkBoxCurve.Size = new System.Drawing.Size(15, 14);
			this.checkBoxCurve.TabIndex = 18;
			this.checkBoxCurve.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 18);
			this.label4.TabIndex = 11;
			this.label4.Text = "Gain";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxGain
			// 
			this.textBoxGain.Location = new System.Drawing.Point(103, 107);
			this.textBoxGain.Name = "textBoxGain";
			this.textBoxGain.Size = new System.Drawing.Size(66, 20);
			this.textBoxGain.TabIndex = 10;
			// 
			// checkBoxLowpass
			// 
			this.checkBoxLowpass.AutoSize = true;
			this.checkBoxLowpass.Location = new System.Drawing.Point(175, 84);
			this.checkBoxLowpass.Name = "checkBoxLowpass";
			this.checkBoxLowpass.Size = new System.Drawing.Size(15, 14);
			this.checkBoxLowpass.TabIndex = 9;
			this.checkBoxLowpass.UseVisualStyleBackColor = true;
			// 
			// checkBoxSlewRate
			// 
			this.checkBoxSlewRate.AutoSize = true;
			this.checkBoxSlewRate.Location = new System.Drawing.Point(175, 58);
			this.checkBoxSlewRate.Name = "checkBoxSlewRate";
			this.checkBoxSlewRate.Size = new System.Drawing.Size(15, 14);
			this.checkBoxSlewRate.TabIndex = 8;
			this.checkBoxSlewRate.UseVisualStyleBackColor = true;
			// 
			// checkBoxHighpass
			// 
			this.checkBoxHighpass.AutoSize = true;
			this.checkBoxHighpass.Location = new System.Drawing.Point(175, 32);
			this.checkBoxHighpass.Name = "checkBoxHighpass";
			this.checkBoxHighpass.Size = new System.Drawing.Size(15, 14);
			this.checkBoxHighpass.TabIndex = 7;
			this.checkBoxHighpass.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "Lowpass filter";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "Slew Rate";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Highpass Filter";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxLowpass
			// 
			this.textBoxLowpass.Location = new System.Drawing.Point(103, 81);
			this.textBoxLowpass.Name = "textBoxLowpass";
			this.textBoxLowpass.Size = new System.Drawing.Size(66, 20);
			this.textBoxLowpass.TabIndex = 3;
			// 
			// textBoxSlewRate
			// 
			this.textBoxSlewRate.Location = new System.Drawing.Point(103, 55);
			this.textBoxSlewRate.Name = "textBoxSlewRate";
			this.textBoxSlewRate.Size = new System.Drawing.Size(66, 20);
			this.textBoxSlewRate.TabIndex = 2;
			// 
			// textBoxHighpass
			// 
			this.textBoxHighpass.Location = new System.Drawing.Point(103, 29);
			this.textBoxHighpass.Name = "textBoxHighpass";
			this.textBoxHighpass.Size = new System.Drawing.Size(66, 20);
			this.textBoxHighpass.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(103, 170);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Set";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// progressBarVelocity
			// 
			this.progressBarVelocity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.progressBarVelocity.Location = new System.Drawing.Point(93, 410);
			this.progressBarVelocity.Maximum = 10000;
			this.progressBarVelocity.Name = "progressBarVelocity";
			this.progressBarVelocity.Size = new System.Drawing.Size(105, 23);
			this.progressBarVelocity.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBarVelocity.TabIndex = 9;
			// 
			// labelVelocity
			// 
			this.labelVelocity.Location = new System.Drawing.Point(17, 415);
			this.labelVelocity.Name = "labelVelocity";
			this.labelVelocity.Size = new System.Drawing.Size(60, 18);
			this.labelVelocity.TabIndex = 10;
			this.labelVelocity.Text = "0.00";
			this.labelVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelCount
			// 
			this.labelCount.Location = new System.Drawing.Point(17, 448);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(60, 18);
			this.labelCount.TabIndex = 11;
			this.labelCount.Text = "0";
			this.labelCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBoxEnabled
			// 
			this.checkBoxEnabled.AutoSize = true;
			this.checkBoxEnabled.Location = new System.Drawing.Point(142, 449);
			this.checkBoxEnabled.Name = "checkBoxEnabled";
			this.checkBoxEnabled.Size = new System.Drawing.Size(15, 14);
			this.checkBoxEnabled.TabIndex = 32;
			this.checkBoxEnabled.UseVisualStyleBackColor = true;
			this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.checkBoxEnabled_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(90, 448);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 13);
			this.label5.TabIndex = 34;
			this.label5.Text = "Enabled";
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(936, 551);
			this.Controls.Add(this.checkBoxEnabled);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.labelVelocity);
			this.Controls.Add(this.progressBarVelocity);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonAddPort);
			this.Controls.Add(this.WaveTabs);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.textBoxRefresh);
			this.Controls.Add(this.buttonZoomX);
			this.Controls.Add(this.textBoxZoomX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "UI";
			this.Text = "KickBrain";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonZoomX;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonAddPort;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox textBoxZoomX;
		internal System.Windows.Forms.TextBox textBoxRefresh;
		internal System.Windows.Forms.TextBox textBoxLowpass;
		internal System.Windows.Forms.TextBox textBoxSlewRate;
		internal System.Windows.Forms.TextBox textBoxHighpass;
		internal System.Windows.Forms.CheckBox checkBoxLowpass;
		internal System.Windows.Forms.CheckBox checkBoxSlewRate;
		internal System.Windows.Forms.CheckBox checkBoxHighpass;
		internal System.Windows.Forms.TextBox textBoxGain;
		internal System.Windows.Forms.CheckBox checkBoxCurve;
		internal System.Windows.Forms.TextBox textBoxThreshold;
		internal System.Windows.Forms.TextBox textBoxTriggerFactor;
		internal System.Windows.Forms.TextBox textBoxTriggerThreshold;
		internal System.Windows.Forms.TextBox textBoxTriggerHold;
		internal System.Windows.Forms.ProgressBar progressBarVelocity;
		internal System.Windows.Forms.Label labelVelocity;
		internal System.Windows.Forms.TextBox textBoxTriggerBlock;
		internal System.Windows.Forms.TextBox textBoxSlewFactor;
		internal System.Windows.Forms.CheckBox checkBoxSlewFactor;
		internal System.Windows.Forms.Label labelCount;
		internal System.Windows.Forms.CheckBox checkBoxEnabled;
		internal System.Windows.Forms.TabControl WaveTabs;
	}
}