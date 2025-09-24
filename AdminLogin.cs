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

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddTest addTest = new AddTest();
            addTest.Show();
        }
        
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            guna2Panel2.Location = new Point(
            (this.ClientSize.Width - guna2Panel2.Width) / 2,
            (this.ClientSize.Height - guna2Panel2.Height) / 2
            );
        }

        private string PasswordFilePath => Application.StartupPath + "\\admin-pass.txt";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // DEBUG: Show path (keep this for verification)
            MessageBox.Show("USING: " + PasswordFilePath, "DEBUG",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            // AUTO-CREATE FILE IF MISSING (USING SAFE WRITE)
            if (!File.Exists(PasswordFilePath))
            {
                FileHelper.SafeWriteAllText(PasswordFilePath, "admin");
                MessageBox.Show("AUTO-CREATED FILE WITH DEFAULT PASSWORD 'admin'");
            }

            string enteredPass = txtPassword.Text;

            // READ PASSWORD (USING SAFE READ)
            string storedPass = FileHelper.SafeReadAllText(PasswordFilePath);

            if (enteredPass == storedPass)
            {
                MessageBox.Show("Login successful!", "Welcome",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                NavForm navForm = new NavForm();
                navForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password.", "Try Again",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
