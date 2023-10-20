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
    public class AdminPageViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;
        private string id;
        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string answer2;
        public string Answer2
        {
            get => answer2;
            set
            {
                answer2 = value;
                OnPropertyChanged(nameof(Answer2));
            }
        }
        private string answer1;
        public string Answer1
        {
            get => answer1;
            set
            {
                answer1 = value;
                OnPropertyChanged(nameof(Answer1));
            }
        }
        private string answer3;
        public string Answer3
        {
            get => answer3;
            set
            {
                answer3 = value;
                OnPropertyChanged(nameof(Answer3));
            }
        }
        private string answer4;
        public string Answer4
        {
            get => answer4;
            set
            {
                answer4 = value;
                OnPropertyChanged(nameof(Answer4));
            }
        }
        private string questionContext;
        public string QuestionContext
        {
            get => questionContext;
            set
            {
                questionContext = value;
                OnPropertyChanged(nameof(QuestionContext));
            }
        }
        public ICommand Back { get; set; }
        public ICommand Change { get; set; }
        public ICommand GetAnswers { get; set; }
        public AdminPageViewModel(NavigationStore navigationStore, IQuestionCreator questionCreator, IQuestionService questionService, IAnswerCreator answerCreator, IAnswerService answerService)
        {
            _navigationStore = navigationStore;
            _questionCreator = questionCreator;
            _questionService = questionService;
            _answerCreator = answerCreator;
            _answerService = answerService;
            Back = new AdminToMain(_navigationStore, createAdminPageViewModel);
            GetAnswers = new AdminToAnswer(_navigationStore, createAnswerPageViewModel);
            Change = new Create(this, _questionCreator);
        }

        private MainPageViewModel createAdminPageViewModel()
        {
            return new MainPageViewModel(_navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
        }
        private AnswerPageViewModel createAnswerPageViewModel()
        {
            return new AnswerPageViewModel(_answerService, _navigationStore,this,_questionService);
        }
    }
}
