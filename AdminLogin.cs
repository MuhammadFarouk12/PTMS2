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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            guna2Panel2.BackColor = ColorTranslator.FromHtml("#E6F0F9");
        }

        


        private void AdminLogin_Load(object sender, EventArgs e)
        {
            guna2Panel2.Location = new Point(
            (this.ClientSize.Width - guna2Panel2.Width) / 2,
            (this.ClientSize.Height - guna2Panel2.Height) / 2
            );
        }

        private string PasswordFilePath => Application.StartupPath + "\\admin-pass.txt";
        string storedPass = PasswordStore.ReadPassword();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. GET THE EXACT PATH WE NEED
            string path = Path.Combine(Application.StartupPath, "admin-pass.txt");

            // 2. VERIFY THE PATH (SHOW IT TO YOU)
            MessageBox.Show($"🔍 READING FROM: {path}", "DEBUG",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. AUTO-CREATE IF MISSING
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "admin");
                MessageBox.Show("📁 Created default password file", "Setup",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 4. READ WITH STREAMREADER (CORRECTLY)
            string storedPass = "";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    storedPass = reader.ReadToEnd().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ READ ERROR: {ex.Message}");
                return;
            }

            // 5. VERIFY WHAT WE READ
            MessageBox.Show($"🔍 READ VALUE: '{storedPass}'", "DEBUG",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 6. CHECK PASSWORD
            if (txtPassword.Text == storedPass)
            {
                MessageBox.Show("✅ Login successful!");
                this.Hide();
                new NavForm().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ Incorrect password.");
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
