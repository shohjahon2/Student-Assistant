using Student_Assistant.IServices;
using Student_Assistant.Model;
using Student_Assistant.View;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Assistant.Commands
{
    public class Next : CommandBase
    {
        
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly QuesitonViewModel _questionViewModel;
        private int id = 0;
        private int count = 1;
        public Next(IQuestionService questionService, QuesitonViewModel questionViewModel, IAnswerService answerService)
        {
            _questionService = questionService;
            _questionViewModel = questionViewModel;
            _answerService = answerService;
            _questionViewModel.PropertyChanged += _questionViewModel_PropertyChanged;
        }



        public override bool CanExecute(object parameter)
        {
            return _questionViewModel.IsAnswer1Checked || _questionViewModel.IsAnswer2Checked || _questionViewModel.IsAnswer3Checked || _questionViewModel.IsAnswer4Checked && base.CanExecute(parameter);  
        }


        public async override void Execute(object parameter)
        {
            IEnumerable<Answer> answers  = await  _answerService.GetAnswers();

            if (answers.Count()!=0)
            {
             var answer1 = answers.Last<Answer>();
             id = answer1.Id;
            }
            else
            {
                id = 0;
            }
            IEnumerable<Question> questions = await _questionService.GetQuestion();
           //getting answers 
            if (_questionViewModel.IsAnswer1Checked == true)
            {
                // _questionViewModel.Answers.Clear();
                Answer answer = new Answer
                (
                 id+1,
                 _questionViewModel.QuestionContext,
                 _questionViewModel.Answer1
                );
                _questionViewModel.Answers.Add(answer);
            }
            else if (_questionViewModel.IsAnswer2Checked == true)
            {
                // _questionViewModel.Answers.Clear();
                Answer answer = new Answer
                 (
                  id+1,
                  _questionViewModel.QuestionContext,
                  _questionViewModel.Answer2
                 );
                _questionViewModel.Answers.Add(answer);
            }
            else if (_questionViewModel.IsAnswer3Checked == true)
            {
                // _questionViewModel.Answers.Clear();
                Answer answer = new Answer
                 (
                  id+1,
                  _questionViewModel.QuestionContext,
                  _questionViewModel.Answer3
                 );
                _questionViewModel.Answers.Add(answer);
            }
            else if (_questionViewModel.IsAnswer4Checked == true)
            {
                // _questionViewModel.Answers.Clear();
                Answer answer = new Answer
                 (
                  id+1,
                  _questionViewModel.QuestionContext,
                  _questionViewModel.Answer4
                 );
                _questionViewModel.Answers.Add(answer);
            }

           //preparing to next step
            _questionViewModel.IsAnswer1Checked = false;
            _questionViewModel.IsAnswer2Checked = false;
            _questionViewModel.IsAnswer3Checked = false;
            _questionViewModel.IsAnswer4Checked = false;

            id = Convert.ToInt32(parameter);
            count = questions.Count();

           
         
            if (id==count)
            {
                id = 0;
                MessageBox.Show("Savollar qolmadi");
                _questionViewModel.Id = string.Empty;
                _questionViewModel.QuestionContext = string.Empty;
                _questionViewModel.Answer1 = string.Empty;
                _questionViewModel.Answer2 = string.Empty;
                _questionViewModel.Answer3 = string.Empty;
                _questionViewModel.Answer4 = string.Empty;
            }
            else
            {
                foreach (var item in questions.Where(q=>q.Id.Equals(id+1)))
                {
                  _questionViewModel.Id = item.Id.ToString();
                  _questionViewModel.QuestionContext = item.QuestionContext;
                  _questionViewModel.Answer1 = item.Answer1;
                  _questionViewModel.Answer2 =item.Answer2; 
                    if (string.IsNullOrEmpty(item.Answer3) && string.IsNullOrEmpty(item.Answer4))
                    {
                        _questionViewModel.Visibility3 = Visibility.Hidden;
                        _questionViewModel.Visibility4 = Visibility.Hidden;
                    }
                    else if (!string.IsNullOrEmpty(item.Answer3) && !string.IsNullOrEmpty(item.Answer4))
                    {
                        _questionViewModel.Visibility3 = Visibility.Visible;
                        _questionViewModel.Visibility4 = Visibility.Visible;
                        _questionViewModel.Answer3 = item.Answer3;
                        _questionViewModel.Answer4 = item.Answer4;
                    }
                    else if (string.IsNullOrEmpty(item.Answer3) && !string.IsNullOrEmpty(item.Answer4))
                    {
                        _questionViewModel.Visibility4 = Visibility.Visible;
                        _questionViewModel.Visibility3 = Visibility.Hidden;
                        _questionViewModel.Answer4 = item.Answer4;
                    }
                    else if(!string.IsNullOrEmpty(item.Answer3) &&   string.IsNullOrEmpty(item.Answer4))
                    {
                        _questionViewModel.Visibility4 = Visibility.Hidden;
                        _questionViewModel.Visibility3 = Visibility.Visible;
                        _questionViewModel.Answer3 = item.Answer3;
                    }

                }
                
            }

  }
        private void _questionViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(QuesitonViewModel.IsAnswer1Checked) || e.PropertyName == nameof(QuesitonViewModel.IsAnswer2Checked) || e.PropertyName == nameof(QuesitonViewModel.IsAnswer3Checked) || e.PropertyName == nameof(QuesitonViewModel.IsAnswer4Checked))
            {
                OnCanExecuteChanged();
            }
        }


    }
}
