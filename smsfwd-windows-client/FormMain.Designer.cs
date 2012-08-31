namespace smsfwdClient
{
	partial class FormMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.dgvMessages = new System.Windows.Forms.DataGridView();
			this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReceivedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Body = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.ctxNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.checkForNewMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tmrCheckNew = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbConfigure = new System.Windows.Forms.ToolStripButton();
			this.tsbClear = new System.Windows.Forms.ToolStripButton();
			this.tsbAbout = new System.Windows.Forms.ToolStripButton();
			this.tsbQuit = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
			this.ctxNotifyIcon.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvMessages
			// 
			this.dgvMessages.AllowUserToAddRows = false;
			this.dgvMessages.AllowUserToDeleteRows = false;
			this.dgvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.From,
            this.ReceivedTime,
            this.Body});
			this.dgvMessages.Location = new System.Drawing.Point(12, 28);
			this.dgvMessages.Name = "dgvMessages";
			this.dgvMessages.ReadOnly = true;
			this.dgvMessages.Size = new System.Drawing.Size(485, 269);
			this.dgvMessages.TabIndex = 5;
			// 
			// From
			// 
			this.From.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.From.HeaderText = "From";
			this.From.Name = "From";
			this.From.ReadOnly = true;
			this.From.Width = 55;
			// 
			// ReceivedTime
			// 
			this.ReceivedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ReceivedTime.HeaderText = "Received";
			this.ReceivedTime.Name = "ReceivedTime";
			this.ReceivedTime.ReadOnly = true;
			this.ReceivedTime.Width = 78;
			// 
			// Body
			// 
			this.Body.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Body.HeaderText = "Body";
			this.Body.Name = "Body";
			this.Body.ReadOnly = true;
			this.Body.Width = 56;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.ctxNotifyIcon;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "smsfwd";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// ctxNotifyIcon
			// 
			this.ctxNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForNewMessagesToolStripMenuItem,
            this.viewMessagesToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.ctxNotifyIcon.Name = "ctxNotifyIcon";
			this.ctxNotifyIcon.Size = new System.Drawing.Size(205, 70);
			// 
			// checkForNewMessagesToolStripMenuItem
			// 
			this.checkForNewMessagesToolStripMenuItem.Checked = true;
			this.checkForNewMessagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkForNewMessagesToolStripMenuItem.Name = "checkForNewMessagesToolStripMenuItem";
			this.checkForNewMessagesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.checkForNewMessagesToolStripMenuItem.Text = "&Check for new messages";
			this.checkForNewMessagesToolStripMenuItem.Click += new System.EventHandler(this.checkForNewMessagesToolStripMenuItem_Click);
			// 
			// viewMessagesToolStripMenuItem
			// 
			this.viewMessagesToolStripMenuItem.Name = "viewMessagesToolStripMenuItem";
			this.viewMessagesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.viewMessagesToolStripMenuItem.Text = "&View messages";
			this.viewMessagesToolStripMenuItem.Click += new System.EventHandler(this.viewMessagesToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// tmrCheckNew
			// 
			this.tmrCheckNew.Interval = 15000;
			this.tmrCheckNew.Tick += new System.EventHandler(this.tmrCheckNew_Tick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConfigure,
            this.tsbClear,
            this.tsbAbout,
            this.tsbQuit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(509, 25);
			this.toolStrip1.TabIndex = 8;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbConfigure
			// 
			this.tsbConfigure.Image = global::smsfwdClient.Properties.Resources.gear;
			this.tsbConfigure.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbConfigure.Name = "tsbConfigure";
			this.tsbConfigure.Size = new System.Drawing.Size(80, 22);
			this.tsbConfigure.Text = "Configure";
			this.tsbConfigure.Click += new System.EventHandler(this.tsbConfigure_Click);
			// 
			// tsbClear
			// 
			this.tsbClear.Image = global::smsfwdClient.Properties.Resources.broom;
			this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbClear.Name = "tsbClear";
			this.tsbClear.Size = new System.Drawing.Size(54, 22);
			this.tsbClear.Text = "Clear";
			this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
			// 
			// tsbAbout
			// 
			this.tsbAbout.Image = global::smsfwdClient.Properties.Resources.information;
			this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAbout.Name = "tsbAbout";
			this.tsbAbout.Size = new System.Drawing.Size(60, 22);
			this.tsbAbout.Text = "About";
			this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
			// 
			// tsbQuit
			// 
			this.tsbQuit.Image = global::smsfwdClient.Properties.Resources.cross;
			this.tsbQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbQuit.Name = "tsbQuit";
			this.tsbQuit.Size = new System.Drawing.Size(50, 22);
			this.tsbQuit.Text = "Quit";
			this.tsbQuit.Click += new System.EventHandler(this.tsbQuit_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 309);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.dgvMessages);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "smsfwd";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.Activated += new System.EventHandler(this.FormMain_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
			this.ctxNotifyIcon.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvMessages;
		private System.Windows.Forms.DataGridViewTextBoxColumn From;
		private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn Body;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip ctxNotifyIcon;
		private System.Windows.Forms.ToolStripMenuItem checkForNewMessagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewMessagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Timer tmrCheckNew;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbConfigure;
		private System.Windows.Forms.ToolStripButton tsbClear;
		private System.Windows.Forms.ToolStripButton tsbQuit;
		private System.Windows.Forms.ToolStripButton tsbAbout;
	}
}

