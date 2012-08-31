// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using smsfwdClient.Properties;
using System.Reflection;

namespace smsfwdClient
{
	public partial class FormMain : Form
	{
		private bool _enabled = true;
		private bool _closeForReal = false;
		private int _unreadMessageCount = 0;
		private System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.F1_New_SMS);

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(Settings.Default.Phone) && !String.IsNullOrEmpty(Settings.Default.EncKey))
			{
				this.Visible = false;
			}
			else
			{
				ShowConfiguration();
			}

			tmrCheckNew.Interval = Settings.Default.UpdateTime * 1000;
			tmrCheckNew.Enabled = true;
		}

		private void FormMain_Activated(object sender, EventArgs e)
		{
			_unreadMessageCount = 0;
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_closeForReal)
			{
				e.Cancel = true;
				this.Visible = false;
			}
		}

		private void tmrCheckNew_Tick(object sender, EventArgs e)
		{
			if (!_enabled)
				return;

			System.Threading.ThreadPool.QueueUserWorkItem(q =>
			{
				IEnumerable<SmsMessage> messages;
				List<SmsMessage> messageList;

				try
				{
					messages = SmsFwdComm.CheckMessages(Settings.Default.Phone);
					messageList = messages.Reverse().ToList();
				}
				catch (Exception ex)
				{
					notifyIcon1.ShowBalloonTip(30000, "smsfwd error", "Error: " + ex.Message, ToolTipIcon.Error);
					return;
				}

				Crypto c = new Crypto(Settings.Default.EncKey + "//" + Settings.Default.Phone);

				_unreadMessageCount += messageList.Count;

				foreach (var message in messageList)
				{
					string body;
					try
					{
						body = c.DecryptFromBase64(message.Body);
					}
					catch (CryptographicException ex)
					{
						body = "(Decrypt error: " + ex.Message + ")";
					}

					this.Invoke(new Action(() =>
					{
						dgvMessages.Rows.Add(message.From, message.Time, body);

						if (_unreadMessageCount == 1)
						{
							// Show message
							notifyIcon1.ShowBalloonTip(30000, "New SMS from " + message.From + " at " + message.Time.ToShortTimeString(), body, ToolTipIcon.Info);
						}
					}));
				}

				if (_unreadMessageCount > 1)
				{
					this.Invoke(new Action(() =>
					{
						notifyIcon1.ShowBalloonTip(30000, "New SMS messages", "You have " + _unreadMessageCount + " new messages.", ToolTipIcon.Info);
					}));
				}

				// Play notification sound if there's (new) new messages
				if ((messageList.Count > 0) && (Settings.Default.PlaySound))
					player.Play();
			});
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			MakeVisible();
		}

		private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
		{
			MakeVisible();
		}

		private void checkForNewMessagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			checkForNewMessagesToolStripMenuItem.Checked = !checkForNewMessagesToolStripMenuItem.Checked;
			_enabled = checkForNewMessagesToolStripMenuItem.Checked;
		}

		private void viewMessagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MakeVisible();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseForReal();
		}
		
		private void tsbConfigure_Click(object sender, EventArgs e)
		{
			ShowConfiguration();
		}

		private void tsbClear_Click(object sender, EventArgs e)
		{
			dgvMessages.Rows.Clear();
		}

		private void tsbAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("smsfwdClient " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " by Andrew Koester\r\n\r\nApplication icon originally by Google\r\nToolbar icons by http://pinvoke.com/", "About", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
		}

		private void tsbQuit_Click(object sender, EventArgs e)
		{
			CloseForReal();
		}

		private void ShowConfiguration()
		{
			using (FormConfigure conf = new FormConfigure())
			{
				_enabled = false;
				conf.ShowDialog();

				if (String.IsNullOrEmpty(Settings.Default.Phone) || String.IsNullOrEmpty(Settings.Default.EncKey))
				{
					// Nothing set
					MessageBox.Show("Configuration must be set. Application will now close.", "No configuration settings", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					CloseForReal();
					return;
				}

				_enabled = true;
			}
		}

		private void MakeVisible()
		{
			this.Visible = true;
			this.BringToFront();
		}

		private void CloseForReal()
		{
			_closeForReal = true;
			this.Close();
		}
	}
}
