using Student_Assistant.Stores;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Commands
{
    public class AdminToAnswer : CommandBase
    {
        private readonly NavigationStore _navigationstore;
        private readonly Func<ViewModelBase> _answerPageViewModel;
        public AdminToAnswer(NavigationStore navigationstore, Func<ViewModelBase> answerPageViewModel)
        {
            _navigationstore = navigationstore;
            _answerPageViewModel = answerPageViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationstore.CurrentViewModel = _answerPageViewModel();
        }
    }
}
