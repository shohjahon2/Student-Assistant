using Student_Assistant.Commands;
using Student_Assistant.IServices;
using Student_Assistant.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Student_Assistant.ViewModel
{
    public class RoomPageViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;
      
        public ICommand BackCommand { get; set; }
        public RoomPageViewModel(NavigationStore navigationStore, IQuestionCreator questionCreator, IQuestionService questionService, IAnswerCreator answerCreator, IAnswerService answerService)
        {
            _navigationStore = navigationStore;
            _questionCreator = questionCreator;
            _questionService = questionService;
            _answerCreator = answerCreator;
            _answerService = answerService;
            BackCommand = new MainToMap(_navigationStore, CreatreMainPageViewModel);
        }
        private MainPageViewModel CreatreMainPageViewModel()
        {
            return new MainPageViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
    }
}
