using Student_Assistant.Commands;
using Student_Assistant.IServices;
using Student_Assistant.Model;
using Student_Assistant.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Student_Assistant.ViewModel
{
    public class QuesitonViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;
        private readonly MainPageViewModel _mainPageViewModel;
        public readonly ObservableCollection<Answer> Answers;
        public ICommand BackCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ICommand NextCommand { get; set; }
        private Visibility visibility4;
        public Visibility Visibility4
        {
            get => visibility4; 
            set 
            {
                visibility4 = value;
                OnPropertyChanged(nameof(Visibility4));
            }
        }
        private Visibility visibility3;
        public Visibility Visibility3 
        {
            get => visibility3; 
            set 
            {
                visibility3 = value;
                OnPropertyChanged(nameof(Visibility3));
            }
        }
        private bool isAnswer2Checked;
        public bool IsAnswer2Checked
        {
            get => isAnswer2Checked;
            set
            {
                isAnswer2Checked = value;
                OnPropertyChanged(nameof(IsAnswer2Checked));
            }
        }
        private bool isAnswer1Checked;
        public bool IsAnswer1Checked
        {
            get => isAnswer1Checked;
            set
            {
                isAnswer1Checked = value;
                OnPropertyChanged(nameof(IsAnswer1Checked));
            }
        }
        private bool isAnswer3Checked;
        public bool IsAnswer3Checked
        {
            get => isAnswer3Checked;
            set
            {
                isAnswer3Checked = value;
                OnPropertyChanged(nameof(IsAnswer3Checked));
            }
        }
        private bool isAnswer4Checked;
        public bool IsAnswer4Checked
        {
            get => isAnswer4Checked;
            set
            {
                isAnswer4Checked = value;
                OnPropertyChanged(nameof(IsAnswer4Checked));
            }
        }
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
        public QuesitonViewModel(NavigationStore navigationStore, IQuestionCreator questionCreator, IQuestionService questionService, MainPageViewModel mainPageViewModel, IAnswerCreator answerCreator, IAnswerService answerService)
        {
           
            _navigationStore = navigationStore;
            _questionCreator = questionCreator;
            _questionService = questionService;
            _mainPageViewModel = mainPageViewModel;
            _answerCreator = answerCreator;
            _answerService = answerService;
            SubmitCommand = new Submit( this, _answerCreator,_navigationStore,_mainPageViewModel);
            BackCommand = new MainToQuestion(_navigationStore, _mainPageViewModel, _questionService, this);
            NextCommand = new Next(_questionService,this,_answerService);
            Answers = new ObservableCollection<Answer>();
        }


    }
}
