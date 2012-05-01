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
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBoxContinousControl = new System.Windows.Forms.CheckBox();
			this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxCCHisteresis = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxCCAverage = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxTriggerLength = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxTriggerBlock = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxTriggerScale = new System.Windows.Forms.TextBox();
			this.textBoxTriggerThreshold = new System.Windows.Forms.TextBox();
			this.textBoxTriggerAttack = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxNoiseFloor = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxGain = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxSlewRate = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.progressBarVelocity = new System.Windows.Forms.ProgressBar();
			this.labelVelocity = new System.Windows.Forms.Label();
			this.labelCount = new System.Windows.Forms.Label();
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
			this.buttonAddPort.Text = "Configure";
			this.buttonAddPort.UseVisualStyleBackColor = true;
			this.buttonAddPort.Click += new System.EventHandler(this.buttonConfigure_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.checkBoxContinousControl);
			this.groupBox1.Controls.Add(this.checkBoxEnabled);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBoxCCHisteresis);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.textBoxCCAverage);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxTriggerLength);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.textBoxTriggerBlock);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBoxTriggerScale);
			this.groupBox1.Controls.Add(this.textBoxTriggerThreshold);
			this.groupBox1.Controls.Add(this.textBoxTriggerAttack);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBoxNoiseFloor);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBoxGain);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxSlewRate);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(456, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 230);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Processing";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(416, 161);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(14, 13);
			this.label24.TabIndex = 51;
			this.label24.Text = "V";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(416, 135);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(45, 13);
			this.label23.TabIndex = 50;
			this.label23.Text = "samples";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(416, 110);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(20, 13);
			this.label22.TabIndex = 49;
			this.label22.Text = "ms";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(416, 84);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(12, 13);
			this.label21.TabIndex = 48;
			this.label21.Text = "x";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(416, 58);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(14, 13);
			this.label20.TabIndex = 47;
			this.label20.Text = "V";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(416, 32);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(14, 13);
			this.label19.TabIndex = 46;
			this.label19.Text = "V";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(186, 135);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(45, 13);
			this.label18.TabIndex = 45;
			this.label18.Text = "samples";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(186, 109);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(45, 13);
			this.label17.TabIndex = 44;
			this.label17.Text = "samples";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(186, 84);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(12, 13);
			this.label16.TabIndex = 43;
			this.label16.Text = "x";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(186, 58);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(12, 13);
			this.label15.TabIndex = 42;
			this.label15.Text = "x";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(5, 188);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(103, 18);
			this.label13.TabIndex = 39;
			this.label13.Text = "Continous Control";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 162);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 18);
			this.label5.TabIndex = 38;
			this.label5.Text = "Enabled";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBoxContinousControl
			// 
			this.checkBoxContinousControl.AutoSize = true;
			this.checkBoxContinousControl.Location = new System.Drawing.Point(114, 188);
			this.checkBoxContinousControl.Name = "checkBoxContinousControl";
			this.checkBoxContinousControl.Size = new System.Drawing.Size(15, 14);
			this.checkBoxContinousControl.TabIndex = 37;
			this.checkBoxContinousControl.UseVisualStyleBackColor = true;
			// 
			// checkBoxEnabled
			// 
			this.checkBoxEnabled.AutoSize = true;
			this.checkBoxEnabled.Location = new System.Drawing.Point(114, 162);
			this.checkBoxEnabled.Name = "checkBoxEnabled";
			this.checkBoxEnabled.Size = new System.Drawing.Size(15, 14);
			this.checkBoxEnabled.TabIndex = 35;
			this.checkBoxEnabled.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(235, 161);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 18);
			this.label6.TabIndex = 34;
			this.label6.Text = "CC Histeresis";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxCCHisteresis
			// 
			this.textBoxCCHisteresis.Location = new System.Drawing.Point(344, 158);
			this.textBoxCCHisteresis.Name = "textBoxCCHisteresis";
			this.textBoxCCHisteresis.Size = new System.Drawing.Size(66, 20);
			this.textBoxCCHisteresis.TabIndex = 33;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(235, 135);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(103, 18);
			this.label12.TabIndex = 32;
			this.label12.Text = "CC Average";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxCCAverage
			// 
			this.textBoxCCAverage.Location = new System.Drawing.Point(344, 132);
			this.textBoxCCAverage.Name = "textBoxCCAverage";
			this.textBoxCCAverage.Size = new System.Drawing.Size(66, 20);
			this.textBoxCCAverage.TabIndex = 31;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 18);
			this.label3.TabIndex = 30;
			this.label3.Text = "Trigger Length";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxTriggerLength
			// 
			this.textBoxTriggerLength.Location = new System.Drawing.Point(114, 132);
			this.textBoxTriggerLength.Name = "textBoxTriggerLength";
			this.textBoxTriggerLength.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerLength.TabIndex = 29;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(235, 109);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(103, 18);
			this.label11.TabIndex = 28;
			this.label11.Text = "Retrigger";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxTriggerBlock
			// 
			this.textBoxTriggerBlock.Location = new System.Drawing.Point(344, 107);
			this.textBoxTriggerBlock.Name = "textBoxTriggerBlock";
			this.textBoxTriggerBlock.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerBlock.TabIndex = 27;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(235, 84);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 18);
			this.label8.TabIndex = 26;
			this.label8.Text = "Trigger Scale";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(223, 58);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(115, 18);
			this.label9.TabIndex = 25;
			this.label9.Text = "Trigger Threshold";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(5, 109);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(103, 18);
			this.label10.TabIndex = 24;
			this.label10.Text = "Trigger Attack";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxTriggerScale
			// 
			this.textBoxTriggerScale.Location = new System.Drawing.Point(344, 81);
			this.textBoxTriggerScale.Name = "textBoxTriggerScale";
			this.textBoxTriggerScale.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerScale.TabIndex = 23;
			// 
			// textBoxTriggerThreshold
			// 
			this.textBoxTriggerThreshold.Location = new System.Drawing.Point(344, 55);
			this.textBoxTriggerThreshold.Name = "textBoxTriggerThreshold";
			this.textBoxTriggerThreshold.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerThreshold.TabIndex = 22;
			// 
			// textBoxTriggerAttack
			// 
			this.textBoxTriggerAttack.Location = new System.Drawing.Point(114, 106);
			this.textBoxTriggerAttack.Name = "textBoxTriggerAttack";
			this.textBoxTriggerAttack.Size = new System.Drawing.Size(66, 20);
			this.textBoxTriggerAttack.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(235, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 18);
			this.label7.TabIndex = 20;
			this.label7.Text = "Noise Floor";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxNoiseFloor
			// 
			this.textBoxNoiseFloor.Location = new System.Drawing.Point(344, 29);
			this.textBoxNoiseFloor.Name = "textBoxNoiseFloor";
			this.textBoxNoiseFloor.Size = new System.Drawing.Size(66, 20);
			this.textBoxNoiseFloor.TabIndex = 19;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(28, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 18);
			this.label4.TabIndex = 11;
			this.label4.Text = "Gain";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxGain
			// 
			this.textBoxGain.Location = new System.Drawing.Point(114, 81);
			this.textBoxGain.Name = "textBoxGain";
			this.textBoxGain.Size = new System.Drawing.Size(66, 20);
			this.textBoxGain.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(28, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "Decay Rate";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxSlewRate
			// 
			this.textBoxSlewRate.Location = new System.Drawing.Point(114, 55);
			this.textBoxSlewRate.Name = "textBoxSlewRate";
			this.textBoxSlewRate.Size = new System.Drawing.Size(66, 20);
			this.textBoxSlewRate.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 188);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(66, 23);
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
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(936, 551);
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		internal System.Windows.Forms.TextBox textBoxZoomX;
		internal System.Windows.Forms.TextBox textBoxRefresh;
		internal System.Windows.Forms.TextBox textBoxSlewRate;
		internal System.Windows.Forms.TextBox textBoxGain;
		internal System.Windows.Forms.TextBox textBoxNoiseFloor;
		internal System.Windows.Forms.TextBox textBoxTriggerScale;
		internal System.Windows.Forms.TextBox textBoxTriggerThreshold;
		internal System.Windows.Forms.TextBox textBoxTriggerAttack;
		internal System.Windows.Forms.ProgressBar progressBarVelocity;
		internal System.Windows.Forms.Label labelVelocity;
		internal System.Windows.Forms.TextBox textBoxTriggerBlock;
		internal System.Windows.Forms.Label labelCount;
		internal System.Windows.Forms.TabControl WaveTabs;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox textBoxTriggerLength;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.CheckBox checkBoxContinousControl;
		internal System.Windows.Forms.CheckBox checkBoxEnabled;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox textBoxCCHisteresis;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox textBoxCCAverage;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
	}
}