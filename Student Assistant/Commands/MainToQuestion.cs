using Student_Assistant.DTOs;
using Student_Assistant.IServices;
using Student_Assistant.Model;
using Student_Assistant.Services;
using Student_Assistant.Stores;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Assistant.Commands
{
    public class MainToQuestion : AsyncCommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelBase _createViewModel;
        private readonly IQuestionService _questionService;
        private readonly QuesitonViewModel _quesitonViewModel;
        public MainToQuestion(NavigationStore navigationStore,ViewModelBase createVievModel, IQuestionService questionService, QuesitonViewModel quesitonViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createVievModel;
            _questionService = questionService;
            _quesitonViewModel = quesitonViewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
           
            IEnumerable<Question> questions = await _questionService.GetQuestion();

            if (questions.Count()!=0)
            {
            foreach (var item in questions.Where(q => q.Id.Equals(1)))
            {
                _quesitonViewModel.Id= item.Id.ToString();
                _quesitonViewModel.QuestionContext = item.QuestionContext;
                _quesitonViewModel.Answer1 = item.Answer1;
                _quesitonViewModel.Answer2 = item.Answer2;
                if (item.Answer3==null && item.Answer4==null)
                {
                _quesitonViewModel.Visibility3 = Visibility.Hidden;
                _quesitonViewModel.Visibility4 = Visibility.Hidden;
                }
                else if(item.Answer3 != null && item.Answer4 == null)
                {
                    _quesitonViewModel.Answer3 = item.Answer3;
                    _quesitonViewModel.Visibility4 = Visibility.Hidden;
                }
                else if(item.Answer3 == null && item.Answer4 != null)
                {
                    _quesitonViewModel.Visibility3 = Visibility.Hidden;
                    _quesitonViewModel.Answer4 = item.Answer4;
                }
                else
                {
                    _quesitonViewModel.Answer3 = item.Answer3;
                    _quesitonViewModel.Answer4 = item.Answer4;
                }
            }
            _navigationStore.CurrentViewModel = _createViewModel;
            }
            else
            {
                MessageBox.Show("None questions");
            }

        }
    }
}
