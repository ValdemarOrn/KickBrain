namespace KickBrain.Views
{
	partial class SignalView
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
			this.listBoxSignals = new System.Windows.Forms.ListBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.textBoxSignalName = new System.Windows.Forms.TextBox();
			this.comboBoxMode = new System.Windows.Forms.ComboBox();
			this.comboBoxA = new System.Windows.Forms.ComboBox();
			this.comboBoxB = new System.Windows.Forms.ComboBox();
			this.comboBoxEvent = new System.Windows.Forms.ComboBox();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxTriggerOn = new System.Windows.Forms.CheckBox();
			this.velocityMapControl = new AudioLib.UI.VelocityMapControl();
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelSigAOutput = new System.Windows.Forms.Label();
			this.labelSigBOutput = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBoxSignals
			// 
			this.listBoxSignals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxSignals.FormattingEnabled = true;
			this.listBoxSignals.Location = new System.Drawing.Point(3, 3);
			this.listBoxSignals.Name = "listBoxSignals";
			this.listBoxSignals.Size = new System.Drawing.Size(161, 433);
			this.listBoxSignals.TabIndex = 1;
			this.listBoxSignals.SelectedIndexChanged += new System.EventHandler(this.listBoxSignals_SelectedIndexChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAdd.Location = new System.Drawing.Point(3, 443);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRemove.Location = new System.Drawing.Point(89, 442);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonRemove.TabIndex = 3;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// textBoxSignalName
			// 
			this.textBoxSignalName.Location = new System.Drawing.Point(307, 35);
			this.textBoxSignalName.Name = "textBoxSignalName";
			this.textBoxSignalName.Size = new System.Drawing.Size(176, 20);
			this.textBoxSignalName.TabIndex = 4;
			// 
			// comboBoxMode
			// 
			this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMode.FormattingEnabled = true;
			this.comboBoxMode.Location = new System.Drawing.Point(307, 61);
			this.comboBoxMode.Name = "comboBoxMode";
			this.comboBoxMode.Size = new System.Drawing.Size(121, 21);
			this.comboBoxMode.TabIndex = 5;
			// 
			// comboBoxA
			// 
			this.comboBoxA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxA.FormattingEnabled = true;
			this.comboBoxA.Location = new System.Drawing.Point(307, 88);
			this.comboBoxA.Name = "comboBoxA";
			this.comboBoxA.Size = new System.Drawing.Size(121, 21);
			this.comboBoxA.TabIndex = 6;
			// 
			// comboBoxB
			// 
			this.comboBoxB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxB.FormattingEnabled = true;
			this.comboBoxB.Location = new System.Drawing.Point(307, 115);
			this.comboBoxB.Name = "comboBoxB";
			this.comboBoxB.Size = new System.Drawing.Size(121, 21);
			this.comboBoxB.TabIndex = 7;
			// 
			// comboBoxEvent
			// 
			this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEvent.FormattingEnabled = true;
			this.comboBoxEvent.Location = new System.Drawing.Point(307, 142);
			this.comboBoxEvent.Name = "comboBoxEvent";
			this.comboBoxEvent.Size = new System.Drawing.Size(121, 21);
			this.comboBoxEvent.TabIndex = 8;
			this.comboBoxEvent.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrigger_SelectedIndexChanged);
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Location = new System.Drawing.Point(307, 190);
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.Size = new System.Drawing.Size(61, 20);
			this.textBoxOutput.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(212, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Signal Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(212, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Mode";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(212, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Input A";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(212, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Input B";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(212, 145);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Trigger";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(212, 193);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Output";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBoxTriggerOn
			// 
			this.checkBoxTriggerOn.AutoSize = true;
			this.checkBoxTriggerOn.Location = new System.Drawing.Point(434, 144);
			this.checkBoxTriggerOn.Name = "checkBoxTriggerOn";
			this.checkBoxTriggerOn.Size = new System.Drawing.Size(15, 14);
			this.checkBoxTriggerOn.TabIndex = 16;
			this.checkBoxTriggerOn.UseVisualStyleBackColor = true;
			// 
			// velocityMapControl
			// 
			this.velocityMapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.velocityMapControl.Location = new System.Drawing.Point(307, 235);
			this.velocityMapControl.Map = null;
			this.velocityMapControl.Name = "velocityMapControl";
			this.velocityMapControl.Size = new System.Drawing.Size(241, 150);
			this.velocityMapControl.TabIndex = 17;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(307, 442);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 18;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// labelSigAOutput
			// 
			this.labelSigAOutput.AutoSize = true;
			this.labelSigAOutput.Location = new System.Drawing.Point(434, 91);
			this.labelSigAOutput.Name = "labelSigAOutput";
			this.labelSigAOutput.Size = new System.Drawing.Size(13, 13);
			this.labelSigAOutput.TabIndex = 19;
			this.labelSigAOutput.Text = "0";
			// 
			// labelSigBOutput
			// 
			this.labelSigBOutput.AutoSize = true;
			this.labelSigBOutput.Location = new System.Drawing.Point(434, 118);
			this.labelSigBOutput.Name = "labelSigBOutput";
			this.labelSigBOutput.Size = new System.Drawing.Size(13, 13);
			this.labelSigBOutput.TabIndex = 20;
			this.labelSigBOutput.Text = "0";
			// 
			// SignalView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelSigBOutput);
			this.Controls.Add(this.labelSigAOutput);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.velocityMapControl);
			this.Controls.Add(this.checkBoxTriggerOn);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.comboBoxEvent);
			this.Controls.Add(this.comboBoxB);
			this.Controls.Add(this.comboBoxA);
			this.Controls.Add(this.comboBoxMode);
			this.Controls.Add(this.textBoxSignalName);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.listBoxSignals);
			this.Name = "SignalView";
			this.Size = new System.Drawing.Size(778, 479);
			this.VisibleChanged += new System.EventHandler(this.SignalView_VisibleChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ListBox listBoxSignals;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox textBoxSignalName;
		internal System.Windows.Forms.ComboBox comboBoxMode;
		internal System.Windows.Forms.ComboBox comboBoxA;
		internal System.Windows.Forms.ComboBox comboBoxB;
		internal System.Windows.Forms.ComboBox comboBoxEvent;
		internal System.Windows.Forms.TextBox textBoxOutput;
		internal System.Windows.Forms.CheckBox checkBoxTriggerOn;
		internal AudioLib.UI.VelocityMapControl velocityMapControl;
		private System.Windows.Forms.Button buttonSave;
		internal System.Windows.Forms.Label labelSigAOutput;
		internal System.Windows.Forms.Label labelSigBOutput;

	}
}
