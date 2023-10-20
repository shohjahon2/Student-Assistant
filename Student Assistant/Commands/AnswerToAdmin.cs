using Student_Assistant.Stores;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Commands
{
    public class AnswerToAdmin : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelBase _adminPage;
        public AnswerToAdmin(NavigationStore navigationStore, ViewModelBase adminPage)
        {
            _navigationStore = navigationStore;
            _adminPage = adminPage;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _adminPage;
        }
    }
}
