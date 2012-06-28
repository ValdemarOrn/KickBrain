namespace KickBrain.Views
{
	partial class OutputView
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
			this.labelSignal = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxSignal = new System.Windows.Forms.ComboBox();
			this.buttonAddCrosstalk = new System.Windows.Forms.Button();
			this.panelCrosstalk = new System.Windows.Forms.Panel();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.listBoxOutputs = new System.Windows.Forms.ListBox();
			this.comboBoxEvent = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxCrosstalk = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxMidiChannel = new System.Windows.Forms.TextBox();
			this.textBoxCCNumber = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBoxIsNote = new System.Windows.Forms.CheckBox();
			this.comboBoxFilterSignal = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxFilterEnabled = new System.Windows.Forms.CheckBox();
			this.textBoxFilterMax = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxFilterMin = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.velocityMapControl = new AudioLib.UI.VelocityMapControl();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.checkBoxTriggerOn = new System.Windows.Forms.CheckBox();
			this.labelFilterValue = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelSignal
			// 
			this.labelSignal.AutoSize = true;
			this.labelSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSignal.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.labelSignal.Location = new System.Drawing.Point(170, 68);
			this.labelSignal.Name = "labelSignal";
			this.labelSignal.Size = new System.Drawing.Size(62, 24);
			this.labelSignal.TabIndex = 0;
			this.labelSignal.Text = "Signal";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label2.Location = new System.Drawing.Point(170, 131);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Crosstalk";
			// 
			// comboBoxSignal
			// 
			this.comboBoxSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSignal.FormattingEnabled = true;
			this.comboBoxSignal.Location = new System.Drawing.Point(174, 99);
			this.comboBoxSignal.Name = "comboBoxSignal";
			this.comboBoxSignal.Size = new System.Drawing.Size(182, 21);
			this.comboBoxSignal.TabIndex = 6;
			this.comboBoxSignal.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignal_SelectedIndexChanged);
			// 
			// buttonAddCrosstalk
			// 
			this.buttonAddCrosstalk.Location = new System.Drawing.Point(362, 158);
			this.buttonAddCrosstalk.Name = "buttonAddCrosstalk";
			this.buttonAddCrosstalk.Size = new System.Drawing.Size(41, 22);
			this.buttonAddCrosstalk.TabIndex = 8;
			this.buttonAddCrosstalk.Text = "Add";
			this.buttonAddCrosstalk.UseVisualStyleBackColor = true;
			this.buttonAddCrosstalk.Click += new System.EventHandler(this.buttonAddCrosstalk_Click);
			// 
			// panelCrosstalk
			// 
			this.panelCrosstalk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panelCrosstalk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelCrosstalk.Location = new System.Drawing.Point(174, 186);
			this.panelCrosstalk.Name = "panelCrosstalk";
			this.panelCrosstalk.Size = new System.Drawing.Size(229, 279);
			this.panelCrosstalk.TabIndex = 11;
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRemove.Location = new System.Drawing.Point(89, 442);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonRemove.TabIndex = 15;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.UseVisualStyleBackColor = true;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAdd.Location = new System.Drawing.Point(3, 443);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 14;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
			// 
			// listBoxOutputs
			// 
			this.listBoxOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxOutputs.FormattingEnabled = true;
			this.listBoxOutputs.Location = new System.Drawing.Point(3, 3);
			this.listBoxOutputs.Name = "listBoxOutputs";
			this.listBoxOutputs.Size = new System.Drawing.Size(161, 433);
			this.listBoxOutputs.TabIndex = 16;
			this.listBoxOutputs.SelectedIndexChanged += new System.EventHandler(this.listBoxOutputs_SelectedIndexChanged);
			// 
			// comboBoxEvent
			// 
			this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEvent.FormattingEnabled = true;
			this.comboBoxEvent.Location = new System.Drawing.Point(174, 34);
			this.comboBoxEvent.Name = "comboBoxEvent";
			this.comboBoxEvent.Size = new System.Drawing.Size(182, 21);
			this.comboBoxEvent.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(170, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 24);
			this.label1.TabIndex = 21;
			this.label1.Text = "Event";
			// 
			// comboBoxCrosstalk
			// 
			this.comboBoxCrosstalk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCrosstalk.FormattingEnabled = true;
			this.comboBoxCrosstalk.Location = new System.Drawing.Point(174, 158);
			this.comboBoxCrosstalk.Name = "comboBoxCrosstalk";
			this.comboBoxCrosstalk.Size = new System.Drawing.Size(182, 21);
			this.comboBoxCrosstalk.TabIndex = 23;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(421, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 17);
			this.label3.TabIndex = 24;
			this.label3.Text = "Midi Channel";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxMidiChannel
			// 
			this.textBoxMidiChannel.Location = new System.Drawing.Point(524, 60);
			this.textBoxMidiChannel.Name = "textBoxMidiChannel";
			this.textBoxMidiChannel.Size = new System.Drawing.Size(121, 20);
			this.textBoxMidiChannel.TabIndex = 25;
			// 
			// textBoxCCNumber
			// 
			this.textBoxCCNumber.Location = new System.Drawing.Point(524, 86);
			this.textBoxCCNumber.Name = "textBoxCCNumber";
			this.textBoxCCNumber.Size = new System.Drawing.Size(121, 20);
			this.textBoxCCNumber.TabIndex = 27;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(421, 89);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 17);
			this.label4.TabIndex = 26;
			this.label4.Text = "Note / CC#";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(421, 115);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 17);
			this.label5.TabIndex = 28;
			this.label5.Text = "Note Trigger";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBoxIsNote
			// 
			this.checkBoxIsNote.AutoSize = true;
			this.checkBoxIsNote.Location = new System.Drawing.Point(524, 115);
			this.checkBoxIsNote.Name = "checkBoxIsNote";
			this.checkBoxIsNote.Size = new System.Drawing.Size(15, 14);
			this.checkBoxIsNote.TabIndex = 29;
			this.checkBoxIsNote.UseVisualStyleBackColor = true;
			// 
			// comboBoxFilterSignal
			// 
			this.comboBoxFilterSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFilterSignal.FormattingEnabled = true;
			this.comboBoxFilterSignal.Location = new System.Drawing.Point(524, 135);
			this.comboBoxFilterSignal.Name = "comboBoxFilterSignal";
			this.comboBoxFilterSignal.Size = new System.Drawing.Size(100, 21);
			this.comboBoxFilterSignal.TabIndex = 30;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(421, 139);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 17);
			this.label6.TabIndex = 31;
			this.label6.Text = "Filter";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBoxFilterEnabled
			// 
			this.checkBoxFilterEnabled.AutoSize = true;
			this.checkBoxFilterEnabled.Location = new System.Drawing.Point(630, 139);
			this.checkBoxFilterEnabled.Name = "checkBoxFilterEnabled";
			this.checkBoxFilterEnabled.Size = new System.Drawing.Size(15, 14);
			this.checkBoxFilterEnabled.TabIndex = 32;
			this.checkBoxFilterEnabled.UseVisualStyleBackColor = true;
			// 
			// textBoxFilterMax
			// 
			this.textBoxFilterMax.Location = new System.Drawing.Point(524, 188);
			this.textBoxFilterMax.Name = "textBoxFilterMax";
			this.textBoxFilterMax.Size = new System.Drawing.Size(121, 20);
			this.textBoxFilterMax.TabIndex = 36;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(421, 191);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 17);
			this.label7.TabIndex = 35;
			this.label7.Text = "Filter Maximum";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxFilterMin
			// 
			this.textBoxFilterMin.Location = new System.Drawing.Point(524, 162);
			this.textBoxFilterMin.Name = "textBoxFilterMin";
			this.textBoxFilterMin.Size = new System.Drawing.Size(121, 20);
			this.textBoxFilterMin.TabIndex = 34;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(421, 165);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 17);
			this.label8.TabIndex = 33;
			this.label8.Text = "Filter Minimum";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// velocityMapControl
			// 
			this.velocityMapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.velocityMapControl.Location = new System.Drawing.Point(524, 229);
			this.velocityMapControl.Map = null;
			this.velocityMapControl.Name = "velocityMapControl";
			this.velocityMapControl.Size = new System.Drawing.Size(237, 135);
			this.velocityMapControl.TabIndex = 37;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(524, 370);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(41, 22);
			this.buttonSave.TabIndex = 38;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(524, 34);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(121, 20);
			this.textBoxName.TabIndex = 40;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(421, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 17);
			this.label9.TabIndex = 39;
			this.label9.Text = "Output Name";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBoxTriggerOn
			// 
			this.checkBoxTriggerOn.AutoSize = true;
			this.checkBoxTriggerOn.Location = new System.Drawing.Point(362, 37);
			this.checkBoxTriggerOn.Name = "checkBoxTriggerOn";
			this.checkBoxTriggerOn.Size = new System.Drawing.Size(15, 14);
			this.checkBoxTriggerOn.TabIndex = 41;
			this.checkBoxTriggerOn.UseVisualStyleBackColor = true;
			// 
			// labelFilterValue
			// 
			this.labelFilterValue.AutoSize = true;
			this.labelFilterValue.Location = new System.Drawing.Point(651, 139);
			this.labelFilterValue.Name = "labelFilterValue";
			this.labelFilterValue.Size = new System.Drawing.Size(22, 13);
			this.labelFilterValue.TabIndex = 42;
			this.labelFilterValue.Text = "0.0";
			// 
			// OutputView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelFilterValue);
			this.Controls.Add(this.checkBoxTriggerOn);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.velocityMapControl);
			this.Controls.Add(this.textBoxFilterMax);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBoxFilterMin);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.checkBoxFilterEnabled);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.comboBoxFilterSignal);
			this.Controls.Add(this.checkBoxIsNote);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxCCNumber);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxMidiChannel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxCrosstalk);
			this.Controls.Add(this.comboBoxEvent);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxOutputs);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.panelCrosstalk);
			this.Controls.Add(this.buttonAddCrosstalk);
			this.Controls.Add(this.comboBoxSignal);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelSignal);
			this.Name = "OutputView";
			this.Size = new System.Drawing.Size(953, 479);
			this.VisibleChanged += new System.EventHandler(this.OutputView_VisibleChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelSignal;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ComboBox comboBoxSignal;
		private System.Windows.Forms.Button buttonAddCrosstalk;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Button buttonAdd;
		internal System.Windows.Forms.ListBox listBoxOutputs;
		internal System.Windows.Forms.ComboBox comboBoxEvent;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox comboBoxCrosstalk;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.ComboBox comboBoxFilterSignal;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox textBoxName;
		internal System.Windows.Forms.TextBox textBoxMidiChannel;
		internal System.Windows.Forms.TextBox textBoxCCNumber;
		internal System.Windows.Forms.CheckBox checkBoxIsNote;
		internal System.Windows.Forms.CheckBox checkBoxFilterEnabled;
		internal System.Windows.Forms.TextBox textBoxFilterMax;
		internal System.Windows.Forms.TextBox textBoxFilterMin;
		internal AudioLib.UI.VelocityMapControl velocityMapControl;
		internal System.Windows.Forms.CheckBox checkBoxTriggerOn;
		internal System.Windows.Forms.Panel panelCrosstalk;
		internal System.Windows.Forms.Label labelFilterValue;


	}
}
