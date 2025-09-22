using Microsoft.SqlServer.Server;
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

namespace LoginForm
{
    public partial class Dashboard : Form
    {
       
        public string ConnectionString = "Server=localhost;Database=OEAMS;Uid=root;pwd=1234";
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadData();
        }
            //to load the data from the database to the datagridview
        private void loadData()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                
            try
            {
                string query = @"SELECT 
     
    concat(student.first_name,' ', student.last_name) as Student_Name ,
    quiz.quiz_name as Quiz,
    final_mark,
    start_time,
    end_time,
    level.level_name
FROM examination 
INNER JOIN student  ON student_id = student.std_id 
inner join quiz on examination.quiz_id = quiz.quiz_id
inner join level on examination.level_id = level.level_id
";
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    {

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        FormatDataGridView();
                    }
                }


            } catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);

                }
        }
        private void FormatDataGridView()
        {

            if (dataGridView1.Columns.Count == 0) return;
            dataGridView1.ReadOnly = true;

            // Prevent adding new rows
            dataGridView1.AllowUserToAddRows = false;

            // Prevent deleting rows
            dataGridView1.AllowUserToDeleteRows = false;

            // Prevent row resizing
            dataGridView1.AllowUserToResizeRows = false;

            // Optional: Make it look like read-only
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.DefaultCellStyle.BackColor = SystemColors.ControlLight;

            // Auto-size columns for better display
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

           
            
            dataGridView1.Columns["Student_Name"].HeaderText = "Student Name";
            dataGridView1.Columns["Quiz"].HeaderText = "Quiz Name";  
            dataGridView1.Columns["final_mark"].HeaderText = "Final Mark";
            dataGridView1.Columns["start_time"].HeaderText = "Start Time";
            dataGridView1.Columns["end_time"].HeaderText = "End Time";
            dataGridView1.Columns["level_name"].HeaderText = "Level";

            // Format numeric column
            dataGridView1.Columns["final_mark"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            // Format date columns
            dataGridView1.Columns["start_time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dataGridView1.Columns["end_time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

            // Set column widths
           
            dataGridView1.Columns["final_mark"].Width = 70;
        }

      

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            loadData();
        }
    } 
}
