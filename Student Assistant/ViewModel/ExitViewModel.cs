using Student_Assistant.Commands;
using Student_Assistant.IServices;
using Student_Assistant.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Student_Assistant.ViewModel
{
    public class ExitViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;
        public ICommand BackCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ExitViewModel(NavigationStore navigationStore,IQuestionCreator questionCreator,IQuestionService questionService,IAnswerCreator answerCreator,IAnswerService answerService)
        {
            _navigationStore = navigationStore;
            _questionCreator = questionCreator;
            _questionService = questionService;
            _answerCreator = answerCreator;
            _answerService = answerService;
            BackCommand = new ExitToMain(_navigationStore, createAdminPageViewModel);
            ExitCommand = new ExitCommand(this);
        }
        private MainPageViewModel createAdminPageViewModel()
        {
            return new MainPageViewModel(_navigationStore, _questionCreator, _questionService, _answerCreator, _answerService);
        }
    }
}
