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
    public partial class AddTest : Form
    {

        public AddTest()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Server=localhost;Database=OEAMS;Uid=root;pwd=himo7723**";

        private void AddTest_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Get the question
            string question = txtQuestion.Text.Trim();
            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("Please enter a question.", "Missing Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Get all options
            string[] options = new string[]
            {
        txtOption1.Text.Trim(),
        txtOption2.Text.Trim(),
        txtOption3.Text.Trim(),
        txtOption4.Text.Trim()
            };
            // 3. Validate all options are filled
            foreach (string opt in options)
            {
                if (string.IsNullOrEmpty(opt))
                {
                    MessageBox.Show("All four answer options are required.", "Incomplete Options",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 4. Check which radio button is selected (correct answer)
            int correctIndex = -1;
            if (rdo1.Checked) correctIndex = 0;
            else if (rdo2.Checked) correctIndex = 1;
            else if (rdo3.Checked) correctIndex = 2;
            else if (rdo4.Checked) correctIndex = 3;
            if (correctIndex == -1)
            {
                MessageBox.Show("Please select the correct answer.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Build display text with ✔️ next to correct answer
            string displayOptions = "";
            for (int i = 0; i < options.Length; i++)
            {
                displayOptions += options[i];
                if (i == correctIndex)
                    displayOptions += " ✔️";  // Add checkmark only to correct one
                if (i < 3)  // Add comma between items
                    displayOptions += ", ";
            }
            // 6. Add to DataGridView
            dgvQuestions.Rows.Add(question, displayOptions);

            // 8. Focus back to question field
            txtQuestion.Focus();
        }

        private (string[] Options, string CorrectAnswer) ParseOptions(string input)
        {
            if (string.IsNullOrEmpty(input))
                return (new string[4], "");

            string[] rawParts = input.Split(',');
            List<string> options = new List<string>();
            string correctAnswer = "";

            foreach (string part in rawParts)
            {
                string cleaned = part.Trim();
                if (cleaned.EndsWith(" ✔️"))
                {
                    string correct = cleaned.Replace(" ✔️", "").Trim();
                    options.Add(correct);
                    correctAnswer = correct;
                }
                else
                {
                    options.Add(cleaned);
                }
            }

            // Ensure we have exactly 4 options
            while (options.Count < 4)
                options.Add("");

            return (options.ToArray(), correctAnswer);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuestion.Clear();
            txtOption1.Clear();
            txtOption2.Clear();
            txtOption3.Clear();
            txtOption4.Clear();

            rdo1.Checked = false;
            rdo2.Checked = false;
            rdo3.Checked = false;
            rdo4.Checked = false;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.Rows.Count == 0)
            {
                MessageBox.Show("No questions to save.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // You need to assign a quiz_id — either user selects it or you set default
            int quiz_id = 1; // ← Change this based on selected quiz

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    MySqlTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        foreach (DataGridViewRow row in dgvQuestions.Rows)
                        {
                            if (row.IsNewRow) continue;
                            object questionObj = row.Cells["Question"].Value;
                            if (questionObj == null || string.IsNullOrEmpty(questionObj.ToString()))
                            {
                                MessageBox.Show("Question text is missing.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            string questionText = questionObj.ToString();

                            object optionsObj = row.Cells["Options"].Value;
                            if (optionsObj == null || string.IsNullOrEmpty(optionsObj.ToString()))
                            {
                                MessageBox.Show("Answer options are missing.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            string optionsDisplay = optionsObj.ToString();

                            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(optionsDisplay))
                                continue;

                            // Parse options and find correct answer
                            var (options, correctAnswer) = ParseOptions(optionsDisplay);

                            if (options.Length != 4)
                            {
                                MessageBox.Show($"Skipping '{questionText}' — needs exactly 4 options.");
                                continue;
                            }

                            // Step 1: Insert Question
                            cmd.CommandText = @"INSERT INTO Question (text, quiz_id) VALUES (@text, @quiz_id); SELECT LAST_INSERT_ID();";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@text", questionText);
                            cmd.Parameters.AddWithValue("@quiz_id", quiz_id);

                            object result = cmd.ExecuteScalar();
                            if (result == null || !int.TryParse(result.ToString(), out int ques_id))
                            {
                                MessageBox.Show("Failed to get question ID.");
                                return;
                            } // Get auto-generated ques_id

                            // Step 2: Insert 4 Choices
                            cmd.CommandText = @"INSERT INTO Choice (text, is_true, ques_id) VALUES (@text, @is_true, @ques_id)";

                            MessageBox.Show($"Row: {row.Index}, Question: {row.Cells["Question"].Value}, Options: {row.Cells["Options"].Value}");

                            for (int i = 0; i < 4; i++)
                            {
                                bool isCorrect = options[i] == correctAnswer;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@text", options[i]);
                                cmd.Parameters.AddWithValue("@is_true", isCorrect ? 1 : 0);
                                cmd.Parameters.AddWithValue("@ques_id", ques_id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Commit all changes
                        transaction.Commit();
                        MessageBox.Show($"All questions saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optional: Clear grid after save
                        dgvQuestions.Rows.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving data:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }
    }
}
