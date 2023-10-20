using Student_Assistant.Commands;
using Student_Assistant.IServices;
using Student_Assistant.Model;
using Student_Assistant.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Student_Assistant.ViewModel
{
    public class AnswerPageViewModel:ViewModelBase
    {
       
        private readonly NavigationStore _navigationStore;
        private readonly AdminPageViewModel _adminPageViewModel;
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        public ObservableCollection<Answer> answers;
        public ObservableCollection<Question> questions;
        public IEnumerable<Answer> Answers => answers;
        public IEnumerable<Question> Questions => questions;
        public ICommand Get { get; set; }
        public ICommand GetQuestions { get; set; }
        public ICommand Back { get; set; }

        public AnswerPageViewModel(IAnswerService answerService, NavigationStore navigationStore, AdminPageViewModel adminPageViewModel, IQuestionService questionService)
        {
            answers = new ObservableCollection<Answer>();
            questions = new ObservableCollection<Question>();
            _answerService = answerService;
            _navigationStore = navigationStore;
            _adminPageViewModel = adminPageViewModel;
            _questionService = questionService;
            Get = new GetAnswers(this, _answerService);
            GetQuestions = new GetQuestions(this, _questionService);
            Back = new AnswerToAdmin(_navigationStore, _adminPageViewModel);
        }

    }
}
