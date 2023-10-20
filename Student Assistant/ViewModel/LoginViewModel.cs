using Student_Assistant.Commands;
using Student_Assistant.IServices;
using Student_Assistant.Stores;
using System.Windows.Input;

namespace Student_Assistant.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;
        public ICommand BackCommand { get; set; }
        public ICommand Login { get; set; }

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
        public LoginViewModel(NavigationStore navigationStore, IQuestionCreator questionCreator, IQuestionService questionService, IAnswerCreator answerCreator, IAnswerService answerService)
        {
            _navigationStore = navigationStore;
            _questionCreator = questionCreator;
            _questionService = questionService;
            _answerCreator = answerCreator;
            _answerService = answerService;
            BackCommand = new MainToLogin(_navigationStore, CreatreMainPageViewModel);
            Login = new Login(this, navigationStore, CreateAdminPageViewModel);
        }
        private MainPageViewModel CreatreMainPageViewModel()
        {
            return new MainPageViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
        private AdminPageViewModel CreateAdminPageViewModel()
        {
            return new AdminPageViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
    }
}
