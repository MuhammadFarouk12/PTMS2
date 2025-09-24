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
            / 1.GET THE EXACT PATH WE NEED
    string path = Path.Combine(Application.StartupPath, "admin-pass.txt");

            // 2. VERIFY THE PATH (SHOW IT TO YOU)
            MessageBox.Show($"🔍 SAVING TO: {path}", "DEBUG",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. READ CURRENT PASSWORD
            string currentPass = "";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    currentPass = reader.ReadToEnd().Trim();
                }
            }
            catch
            {
                MessageBox.Show("❌ Could not read current password");
                return;
            }

            // 4. VALIDATE
            if (txtCurrent.Text != currentPass)
            {
                MessageBox.Show("❌ Current password is wrong");
                return;
            }

            if (txtNew.Text.Length < 4)
            {
                MessageBox.Show("❌ Password must be 4+ characters");
                return;
            }
            if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("❌ Passwords don't match");
                return;
            }

            // 5. WRITE WITH STREAMWRITER (CORRECTLY)
            try
            {
                // FIRST: DELETE OLD FILE (bypasses caching)
                if (File.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }

                // SECOND: WRITE NEW CONTENT
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(txtNew.Text);
                }

                // THIRD: VERIFY IMMEDIATELY
                string verification = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    verification = reader.ReadToEnd().Trim();
                }

                if (verification != txtNew.Text)
                {
                    MessageBox.Show("❌ WRITE FAILED!\n" +
                                   $"EXPECTED: '{txtNew.Text}'\n" +
                                   $"ACTUAL: '{verification}'");
                    return;
                }
                MessageBox.Show("✅ Password changed successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ SAVE ERROR: {ex.Message}");
            }
        }


        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
