using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class NavForm : Form
    {
        public NavForm()
        {
            InitializeComponent();
            panelLogo.BackColor = ColorTranslator.FromHtml("#E6F0F9");
            panelIcons.BackColor = ColorTranslator.FromHtml("#E6F0F9");
        }
        private void LoadFormIntoPanel(Form form)
        {
            // Remove any existing controls
            panelContent.Controls.Clear();

            // Configure the form to be embedded
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.AutoSize = false;

            // Add to panel
            panelContent.Controls.Add(form);

            // Show the form
            form.Show();
            form.BringToFront();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddTest addTest = new AddTest();
            LoadFormIntoPanel(addTest);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            TestView viewTests = new TestView();
            viewTests.Show();
            this.Hide();
        }
    }
}
