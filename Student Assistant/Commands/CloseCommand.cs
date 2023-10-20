using Student_Assistant.Stores;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Commands
{
    class CloseCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        public CloseCommand(NavigationStore navigationStore, Func<ViewModelBase> createVievModel)
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
