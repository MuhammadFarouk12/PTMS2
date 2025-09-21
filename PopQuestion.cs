using System;
using MySql.Data.MySqlClient;
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
    public partial class PopQuestion : Form
    {
        public static int questionNumber = 0; 
        Question quest = Test.questions[questionNumber];
        public PopQuestion()
        {
            InitializeComponent();

            grb_radio.Text = quest.question_text;
            lbl_answer_1.Text = quest.answers[0].answer_text;
            lbl_answer_2.Text = quest.answers[1].answer_text;
            lbl_answer_3.Text = quest.answers[2].answer_text;
            lbl_answer_4.Text = quest.answers[3].answer_text;
        }

        private void PopQuestion_Load(object sender, EventArgs e)
        {

        }

        private void btn_submitQuestion_Click(object sender, EventArgs e)
        {

            if (rd_answer_1.Checked && quest.answers[0].is_true)
            {
                Examination.final_mark++;
                // MessageBox.Show("Good");
            }
            else if (rd_answer_2.Checked && quest.answers[1].is_true)
            {
                Examination.final_mark++;
                // MessageBox.Show("Good");
            }
            else if (rd_answer_3.Checked && quest.answers[2].is_true)
            {
                Examination.final_mark++;
                // MessageBox.Show("Good");
            }
            else if (rd_answer_4.Checked && quest.answers[3].is_true)
            {
                Examination.final_mark++;
                // MessageBox.Show("Good");
            }
            else
            {
                // MessageBox.Show("This is not correct");
            }


            this.Hide();
            if(questionNumber < Test.questions.Count - 1)
            {
                questionNumber++;
                new PopQuestion().Show();
            } else
            {
                Examination.end_time = DateTime.Now.ToString("yy:MM:dd HH:mm:ss");
                MessageBox.Show("You have finsihed the exam successfully");
              try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseUtil.ConnectionString))
                {
                    using (MySqlCommand insertExamData = new MySqlCommand("insert into examination(student_id, quiz_id, final_mark, start_time, end_time, level_id) values(@student_id, @quiz_id, @final_mark, @start_time, @end_time, @level_id);", connection))
                    {
                        insertExamData.Parameters.AddWithValue("@student_id", User.Id);
                        insertExamData.Parameters.AddWithValue("@quiz_id", Test.randomQuiz);
                        insertExamData.Parameters.AddWithValue("@final_mark", Examination.final_mark);
                        insertExamData.Parameters.AddWithValue("@start_time", Examination.start_time);
                        insertExamData.Parameters.AddWithValue("@end_time", Examination.end_time);
                        int questionsNumber = Test.questions.Count;
                        // coorectAnswers / (number of questions / 6)
                        double final_level = Examination.final_mark / Math.Ceiling((questionsNumber) / 6.0);
                        insertExamData.Parameters.AddWithValue("@level_id", final_level == 0 ? 1 : final_level);
                        connection.Open();
                        object result = insertExamData.ExecuteNonQuery();
                        
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }
    }
}
