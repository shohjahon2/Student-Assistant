using Student_Assistant.IServices;
using Student_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Commands
{
    public class Answer2 : AsyncCommandBase
    {
       

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked; 
        }
        private string questionContext;
        public string QuestionContext
        {
            get => questionContext;
        }  
        private string answer;
        public string Answer
        {
            get => answer;
        }
        public async override Task ExecuteAsync(object parameter)
        {
            object[] vs =  (object[])parameter;
            isChecked = (bool)vs[0];
            questionContext  = (string)vs[1];
            answer = (string)vs[2];
         
        }
    }
}
