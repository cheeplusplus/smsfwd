namespace smsfwdClient
{
	partial class FormConfigure
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.chkPlaySound = new System.Windows.Forms.CheckBox();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Encryption key:";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(98, 41);
			this.txtPhone.MaxLength = 11;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(141, 20);
			this.txtPhone.TabIndex = 1;
			// 
			// txtKey
			// 
			this.txtKey.Location = new System.Drawing.Point(98, 67);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(141, 20);
			this.txtKey.TabIndex = 3;
			this.txtKey.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Phone number:";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCancel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(257, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbSave
			// 
			this.tsbSave.Image = global::smsfwdClient.Properties.Resources.disk_black;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(51, 22);
			this.tsbSave.Text = "&Save";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// tsbCancel
			// 
			this.tsbCancel.Image = global::smsfwdClient.Properties.Resources.cross_circle;
			this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCancel.Name = "tsbCancel";
			this.tsbCancel.Size = new System.Drawing.Size(63, 22);
			this.tsbCancel.Text = "&Cancel";
			this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// chkPlaySound
			// 
			this.chkPlaySound.AutoSize = true;
			this.chkPlaySound.Location = new System.Drawing.Point(15, 101);
			this.chkPlaySound.Name = "chkPlaySound";
			this.chkPlaySound.Size = new System.Drawing.Size(123, 17);
			this.chkPlaySound.TabIndex = 6;
			this.chkPlaySound.Text = "Play incoming sound";
			this.chkPlaySound.UseVisualStyleBackColor = true;
			// 
			// FormConfigure
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(257, 130);
			this.ControlBox = false;
			this.Controls.Add(this.chkPlaySound);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormConfigure";
			this.Text = "Configure smsfwd";
			this.Load += new System.EventHandler(this.FormConfigure_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbSave;
		private System.Windows.Forms.ToolStripButton tsbCancel;
		private System.Windows.Forms.CheckBox chkPlaySound;
	}
}