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
    public class Create : AsyncCommandBase
    {
        private readonly AdminPageViewModel _adminPageViewModel;
        private readonly IQuestionCreator _questionCreator;
        public Create(AdminPageViewModel adminPageViewModel, IQuestionCreator questionCreator)
        {
            _adminPageViewModel = adminPageViewModel;
            _questionCreator = questionCreator;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
            Question question = new Question
            (
             int.Parse(_adminPageViewModel.Id),
            _adminPageViewModel.QuestionContext,
            _adminPageViewModel.Answer1,
            _adminPageViewModel.Answer2,
            _adminPageViewModel.Answer3,
            _adminPageViewModel.Answer4
            );
            await _questionCreator.CreateQuestion(question);
            MessageBox.Show("Successfuly");
            _adminPageViewModel.Answer1 = string.Empty;
            _adminPageViewModel.Answer2 = string.Empty;
            _adminPageViewModel.Answer3 = string.Empty;
            _adminPageViewModel.Answer4 = string.Empty;
            _adminPageViewModel.QuestionContext = string.Empty;
            _adminPageViewModel.Id = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
