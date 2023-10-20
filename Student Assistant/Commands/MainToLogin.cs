using Student_Assistant.Stores;
using Student_Assistant.ViewModel;
using System;

namespace Student_Assistant.Commands
{
    public class MainToLogin:CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        public MainToLogin(NavigationStore navigationStore,Func<ViewModelBase> createVievModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createVievModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
