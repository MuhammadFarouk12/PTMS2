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
    public partial class Test : Form
    {
        public List<int> quizesId = new List<int>();
        public static List<Question> questions = new List<Question>();
        public static int randomQuiz = 0;
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            helloTestLbael.Text = "Hello " + User.First_Name + " " + User.Last_Name + ", Answer all questions";
        }

        private void btn_startExam_Click(object sender, EventArgs e)
        {
            Examination.start_time = DateTime.Now.ToString("yy:MM:dd HH:mm:ss");
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseUtil.ConnectionString))
                {
                    // Gathering all quizes and choosing a random quiz;
                    using (MySqlCommand getQuizes = new MySqlCommand("select quiz_id from quiz", connection))
                    {
                        connection.Open();
                        MySqlDataReader result = getQuizes.ExecuteReader();
                        while (result.Read())
                        {
                            quizesId.Add(result.GetInt32("quiz_id"));
                        }
                        Random rnd = new Random();
                        // edit later
                        // randomQuiz = rnd.Next(1, quizesId.Count + 1);
                        randomQuiz = 1;
                        MessageBox.Show(randomQuiz.ToString());
                        connection.Close();
                    }

                using (MySqlConnection connection2 = new MySqlConnection(DatabaseUtil.ConnectionString))
                    {
                        using (MySqlCommand getQuestions = new MySqlCommand("select * from question where quiz_id = @quiz_id", connection2))
                        {
                            connection2.Open();
                            getQuestions.Parameters.AddWithValue("@quiz_id", randomQuiz);
                            MySqlDataReader result = getQuestions.ExecuteReader();
                            int questionscounter = 0;
                            while (result.Read())
                            {
                                Question question = new Question(result.GetInt32("ques_id"), result.GetString("text"));
                                questions.Add(question);
                                using (MySqlConnection connection3 = new MySqlConnection(DatabaseUtil.ConnectionString))
                                    {
                                        using (MySqlCommand getAnswers = new MySqlCommand("select * from choice where ques_id = @question_id", connection3))
                                        {
                                            connection3.Open();
                                            getAnswers.Parameters.AddWithValue("@question_id", question.question_id);
                                            MySqlDataReader resultAnswers = getAnswers.ExecuteReader();
                                            while (resultAnswers.Read())
                                            {
                                            Answer answer = new Answer(resultAnswers.GetInt32("choice_id"), resultAnswers.GetInt32("is_true") == 1, resultAnswers.GetString("text"));
                                                question.answers.Add(answer);
                                                //MessageBox.Show(answer.answer_text);
                                            }
                                        }
                                    }
                            }
                            this.Hide();
                            new PopQuestion().Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // MessageBox.Show("Incorrect Phone Number");
            }
        }
    }
}
