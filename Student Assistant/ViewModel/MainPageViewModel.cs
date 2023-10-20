using Student_Assistant.Commands;
using Student_Assistant.IServices;
using Student_Assistant.Stores;
using System.Windows.Input;

namespace Student_Assistant.ViewModel
{
    public  class MainPageViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;
        private readonly QuesitonViewModel _quesitonViewModel;
        public ICommand AdminCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MapCommand { get; set; }
        public ICommand FeedBackCommand { get; set; }
        public MainPageViewModel(NavigationStore navigationStore, IQuestionCreator questionCreator, IQuestionService questionService, IAnswerCreator answerCreator, IAnswerService answerService)
        {
            _navigationStore = navigationStore;
            _questionCreator = questionCreator;
            _questionService = questionService;
            _answerCreator = answerCreator;
            _answerService = answerService;
            _quesitonViewModel = new QuesitonViewModel(navigationStore, _questionCreator, _questionService, this, _answerCreator,_answerService);
            AdminCommand = new MainToLogin(_navigationStore, CreatreLoginViewModel);
            FeedBackCommand = new MainToQuestion(_navigationStore, _quesitonViewModel, _questionService, _quesitonViewModel);
            MapCommand = new MainToMap(_navigationStore, CreateRoomPageViewModel);
            CloseCommand = new CloseCommand(_navigationStore, CreateRoomExitViewModel);
        }
        private LoginViewModel CreatreLoginViewModel()
        {
            return new LoginViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
      
        private RoomPageViewModel CreateRoomPageViewModel()
        {
            return new RoomPageViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
        private ExitViewModel CreateRoomExitViewModel()
        {
            return new ExitViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
    }
}
