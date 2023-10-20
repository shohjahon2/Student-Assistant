using Student_Assistant.IServices;
using Student_Assistant.Model;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Assistant.Commands
{
    public class GetAnswers : AsyncCommandBase
    {
        private readonly AnswerPageViewModel _answerPageViewModel;
        private readonly IAnswerService _answerService;
        public GetAnswers(AnswerPageViewModel answerPageViewModel, IAnswerService answerService)
        {
            _answerService = answerService;
            _answerPageViewModel = answerPageViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var answers = await _answerService.GetAnswers();
            if (answers.Count()>0)
            {
                foreach (var item in answers)
                {
                    _answerPageViewModel.answers.Add(item);
                }
            }
            else
            {
                MessageBox.Show("None answers");
            }

        }
    }
}
