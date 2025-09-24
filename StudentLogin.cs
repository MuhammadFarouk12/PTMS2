﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Tls;
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
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
            btnLogin.BackColor = ColorTranslator.FromHtml("#005B9C"); // Blue
            btnCancle.BackColor = ColorTranslator.FromHtml("#005B9C");
            btnRegister.BackColor = ColorTranslator.FromHtml("#005B9C");
            guna2Panel2.BackColor = ColorTranslator.FromHtml("#E6F0F9");
            this.BackColor = ColorTranslator.FromHtml("#E0E0E0");

        }

<<<<<<< HEAD
        public string ConnectionString =  "Server=localhost;Database=OEAMS;Uid=root;pwd=himo7723**";        
=======
>>>>>>> 7344819d6b053c95c8ffcdeb8f608bc91862007c

        private void LoginForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Login Form!");
 
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txb_phone_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtbLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            guna2Panel2.Location = new Point(
            (this.ClientSize.Width - guna2Panel2.Width) / 2,
            (this.ClientSize.Height - guna2Panel2.Height) / 2
            );
        }

        private void btnCancle_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSignUP_Click_1(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseUtil.ConnectionString))
                {
                    using (MySqlCommand checkPass = new MySqlCommand("select * from student where phone_number = @phone_number", connection))
                    {
                        checkPass.Parameters.AddWithValue("@phone_number", txb_phone_number.Text);
                        connection.Open();
                        MySqlDataReader result = checkPass.ExecuteReader();
                        //User user = new User();
                        result.Read();
                        User.Id = result.GetInt32("std_id");
                        User.First_Name = result.GetString("first_name");
                        User.Last_Name = result.GetString("last_name");
                        User.Phone_Number = result.GetString("phone_number");
                        User.Password  = result.GetString("password");

                        if(txtbPassword.Text == User.Password)
                        {
                            Test test = new Test();
                            test.Show();
                            this.Hide();
                        } else
                        {
                            MessageBox.Show("Your Password Is Incorrect");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect Phone Number");
            }

        }

        private void txb_phone_number_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
