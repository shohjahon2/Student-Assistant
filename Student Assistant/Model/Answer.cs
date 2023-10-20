using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Model
{
    public class Answer
    {
        public int Id { get;}
        public string QuestionContext { get;}
        public string Answered { get;}
        public Answer(int id,string context,string answer)
        {
            Id = id;
            QuestionContext = context;
            Answered = answer;
        }
    }
}
