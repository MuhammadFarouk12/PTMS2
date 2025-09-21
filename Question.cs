using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class Question
    {
        public int question_id { get; set; }
        public string question_text { get; set; }
        public int choosen_answer_id { get; set; }
        public int true_answer_id { get; set; }
        public List<Answer> answers { get; set; } = new List<Answer>();

        public Question(int questionId, string questionText)
        {
            question_id = questionId;
            question_text = questionText;
            //choosen_answer_id = choosenAnswerId;
            //true_answer_id = trueAnswerId;
            //answers = answers;
        }
    }
}
