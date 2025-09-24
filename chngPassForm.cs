using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LoginForm
{
    public partial class chngPassForm : Form
    {
        public chngPassForm()
        {
            InitializeComponent();
            chngPassPanel.BackColor = ColorTranslator.FromHtml("#E6F0F9");
        }
        // the path to the password file
        private string PasswordFilePath => Application.StartupPath + "\\admin-pass.txt";
        private void chngPassForm_Load(object sender, EventArgs e)
        {
            txtCurrent.Clear();
            txtNew.Clear();
            txtConfirm.Clear();
            txtCurrent.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // DEBUG: Show path (keep this for verification)
            MessageBox.Show("SAVING TO: " + PasswordFilePath, "DEBUG",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            string currentPass = txtCurrent.Text;
            string newPass = txtNew.Text;
            string confirmPass = txtConfirm.Text;

            // VALIDATE INPUTS
            if (string.IsNullOrWhiteSpace(currentPass))
            {
                MessageBox.Show("Please enter current password.");
                txtCurrent.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 4)
            {
                MessageBox.Show("New password must be at least 4 characters.");
                txtNew.Clear();
                txtConfirm.Clear();
                txtNew.Focus();
                return;
            }
            if (newPass != confirmPass)
            {
                MessageBox.Show("New passwords don't match.");
                txtNew.Clear();
                txtConfirm.Clear();
                txtNew.Focus();
                return;
            }

            try
            {
                // VERIFY CURRENT PASSWORD (USING SAFE READ)
                string storedPass = FileHelper.SafeReadAllText(PasswordFilePath);
                if (currentPass != storedPass)
                {
                    MessageBox.Show("Current password is incorrect.");
                    txtCurrent.Clear();
                    txtCurrent.Focus();
                    return;
                }
                // SAVE NEW PASSWORD (USING SAFE WRITE)
                FileHelper.SafeWriteAllText(PasswordFilePath, newPass);

                // VERIFY IMMEDIATELY (USING SAFE READ)
                string verification = FileHelper.SafeReadAllText(PasswordFilePath);
                if (verification != newPass)
                {
                    MessageBox.Show("Write failed! Contact developer.");
                    return;
                }

                MessageBox.Show("Password changed successfully!", "Success",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
