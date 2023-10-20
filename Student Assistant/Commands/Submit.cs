using Student_Assistant.IServices;
using Student_Assistant.Model;
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
    class Submit : AsyncCommandBase
    {
        private readonly QuesitonViewModel _questionViewModel;
        private readonly IAnswerCreator _answerCreator;
        private readonly NavigationStore _navigationStore;
        private readonly MainPageViewModel _mainPageViewModel;
        public Submit(QuesitonViewModel questionViewModel, IAnswerCreator answerCreator, NavigationStore navigationStore, MainPageViewModel mainPageViewModel)
        {
            _questionViewModel = questionViewModel;
            _answerCreator = answerCreator;
            _navigationStore = navigationStore;
            _mainPageViewModel = mainPageViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            foreach (var item in _questionViewModel.Answers)
            {
                await _answerCreator.CreateAnswer(item);
            }
            _questionViewModel.Answers.Clear();
            MessageBox.Show("Muvaffaaqiyatli yuklandi");
            _navigationStore.CurrentViewModel = _mainPageViewModel;
        }
    }
}
