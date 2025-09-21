using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class Answer
    {
        public int answer_id { get; set; }
        public bool is_true { get; set; }
        public string answer_text { get; set; }

        public Answer(int answerId, bool isTrue, string answerText)
        {
            answer_id = answerId;
            is_true = isTrue;
            answer_text = answerText;
        }
    }
}
