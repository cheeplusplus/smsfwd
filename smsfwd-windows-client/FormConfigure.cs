using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using smsfwdClient.Properties;

namespace smsfwdClient
{
	public partial class FormConfigure : Form
	{
		public FormConfigure()
		{
			InitializeComponent();
		}

		private void FormConfigure_Load(object sender, EventArgs e)
		{
			txtPhone.Text = Settings.Default.Phone;
			txtKey.Text = Settings.Default.EncKey;
			chkPlaySound.Checked = Settings.Default.PlaySound;
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if ((txtPhone.Text.Length < 10) || (txtPhone.Text.Length > 11))
			{
				MessageBox.Show("Phone number must be 10 or 11 digits. Ex. 15551234567", "Phone number invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			if (txtKey.Text.Length < 1)
			{
				MessageBox.Show("Encryption key cannot be empty.", "Encryption key invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			Settings.Default.Phone = txtPhone.Text;
			Settings.Default.EncKey = txtKey.Text;
			Settings.Default.PlaySound = chkPlaySound.Checked;
			Settings.Default.Save();

			this.Close();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
