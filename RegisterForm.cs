using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;


namespace LoginForm
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            btnCancle.BackColor = ColorTranslator.FromHtml("#005B9C"); // Blue
            btnSave.BackColor = ColorTranslator.FromHtml("#005B9C");
            guna2Panel2.BackColor = ColorTranslator.FromHtml("#E6F0F9");
            this.BackColor = ColorTranslator.FromHtml("#E0E0E0");
        }

        public string ConnectionString = "Server=localhost;Database=OEAMS;Uid=root;pwd=Hamed#51234";

        private bool ValidateForm()
{
    
    errorProvider1.Clear();

    bool isValid = true;

    
    if (string.IsNullOrWhiteSpace(txtbFirstName.Text))
    {
                MessageBox.Show("Please enter your first name");
                isValid = false;
    }

   
    if (string.IsNullOrWhiteSpace(txtbLastName.Text))
    {
                MessageBox.Show("Please enter your last name");
                isValid = false;
    }
 

   
    if (string.IsNullOrWhiteSpace(txb_phone_number.Text))
    {
                MessageBox.Show("Please enter your phone number");
                isValid = false;
    }
    else if (!Regex.IsMatch(txb_phone_number.Text, @"^\d{9}$"))
    {
                MessageBox.Show(" Phone number must contain nine digits");
                isValid = false;
    }
           
   
    if (string.IsNullOrWhiteSpace(txbPassword.Text))
    {
                MessageBox.Show("Please enter your password");
                isValid = false;
    }
    else if (txbPassword.Text.Length < 6)
    {
                MessageBox.Show("Password must be at least six characters long");
                isValid = false;
    }

    return isValid;
}

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {

            if (!ValidateForm())
            {
                MessageBox.Show("Please correct any error before proceeding", "data error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // insert data to database 
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseUtil.ConnectionString))
                {

                    using (MySqlCommand checkPass = new MySqlCommand("select count(phone_number) from student where phone_number = @phone_number", connection))
                    {
                        checkPass.Parameters.AddWithValue("@phone_number", txb_phone_number.Text);
                        connection.Open();
                        object result = checkPass.ExecuteScalar();
                        int numbers = Convert.ToInt32(result);
                        if(numbers > 0)
                        {
                            MessageBox.Show("This phone number already exists");

                        } else
                        {
                            using (MySqlCommand insertStd = new MySqlCommand("insert into student(first_name, last_name, phone_number, password) values(@first_name, @last_name, @phone_number, @password);", connection))
                            {
                                insertStd.Parameters.AddWithValue("@first_name", txtbFirstName.Text);
                                insertStd.Parameters.AddWithValue("@last_name", txtbLastName.Text);
                                insertStd.Parameters.AddWithValue("@phone_number", txb_phone_number.Text);
                                insertStd.Parameters.AddWithValue("@password", txbPassword.Text);
                                object studentstInserted = insertStd.ExecuteNonQuery();
                            }
                            MessageBox.Show("You are added successfully, now you can sign in");
                            StudentLogin loginForm = new StudentLogin();
                            loginForm.Show();
                            this.Hide();
                        }
                    }


                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            {

            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            guna2Panel2.Location = new Point(
(this.ClientSize.Width - guna2Panel2.Width) / 2,
(this.ClientSize.Height - guna2Panel2.Height) / 2
);
        }

        private void txb_phone_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbFirstName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
