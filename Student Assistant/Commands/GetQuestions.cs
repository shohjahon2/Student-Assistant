using Student_Assistant.IServices;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Assistant.Commands
{
    public class GetQuestions : AsyncCommandBase
    {
        private readonly AnswerPageViewModel _answerPageViewModel;
        private readonly IQuestionService _questionService;
        public GetQuestions(AnswerPageViewModel answerPageViewModel, IQuestionService questionService)
        {
            _questionService = questionService;
            _answerPageViewModel = answerPageViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var questions = await _questionService.GetQuestion();
            if (questions.Count() > 0)
            {
                foreach (var item in questions)
                {
                    _answerPageViewModel.questions.Add(item);
                }
            }
            else
            {
                MessageBox.Show("None questions");
            }

        }
    }
}
