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
        }

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddTest addTest = new AddTest();
            addTest.Show();
        }
        private string PasswordFilePath = "admin-pass.txt";
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            guna2Panel2.Location = new Point(
            (this.ClientSize.Width - guna2Panel2.Width) / 2,
            (this.ClientSize.Height - guna2Panel2.Height) / 2
            );
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!File.Exists(PasswordFilePath))
            {
                MessageBox.Show("Password file missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enteredPass = txtPassword.Text;

            try
            {
                string storedPass = File.ReadAllText(PasswordFilePath).Trim();

                if (enteredPass == storedPass)
                {
                    MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    NavForm navForm = new NavForm();
                    navForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect password.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading password:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
