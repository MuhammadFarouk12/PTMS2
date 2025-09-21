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
    public partial class TestView : Form
    {
        public TestView()
        {
            InitializeComponent();
        }

        private void TestView_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseUtil.ConnectionString))
            {
                con.Open();
                string query = "SELECT  quiz_id , quiz_name FROM Quiz";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox_SelectTest.Items.Add(new
                    {
                        Text = dr["quiz_name"].ToString(),
                        Value = dr["quiz_id"].ToString()
                    });
                }
            }

            comboBox_SelectTest.DisplayMember = "Text";
            comboBox_SelectTest.ValueMember = "Value";
        }

        private void button_ShowTest_Click(object sender, EventArgs e)
        {
            var selectedQuiz = comboBox_SelectTest.SelectedItem as dynamic;
            int quizId = int.Parse(selectedQuiz.Value);

            using (MySqlConnection con = new MySqlConnection(DatabaseUtil.ConnectionString))
            {
                con.Open();
                string query = @"SELECT q.text AS Question, c.text AS Choice, c.is_true AS Correct
                         FROM Question q
                         INNER JOIN Choice c ON q.ques_id = c.ques_id
                         WHERE q.quiz_id = @quizId";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@quizId", quizId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataGridView_ShowTest.DataSource = dt;
            }
        }

        private void DataGridView_ShowTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
