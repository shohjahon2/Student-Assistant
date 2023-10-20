using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Model
{
    public class Question
    {
        public int Id { get; }
        public string QuestionContext { get;}
        public string Answer1 { get; }
        public string Answer2 { get; }
        public string Answer3 { get; }
        public string Answer4 { get; }

        public Question(int id,string questionContexxt,string answer1, string answer2,string answer3,string answer4)
        {
            Id = id;
            QuestionContext = questionContexxt;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
        }
    }
}
