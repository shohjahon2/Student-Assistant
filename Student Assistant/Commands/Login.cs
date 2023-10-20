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
    public class Login : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        public Login(LoginViewModel loginViewModel, NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _loginViewModel = loginViewModel;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            if (!string.IsNullOrEmpty(_loginViewModel.Password) && !string.IsNullOrEmpty(_loginViewModel.UserName))
            {


                if (_loginViewModel.Password == "turin" && _loginViewModel.UserName == "turin")
                {
                    _navigationStore.CurrentViewModel = _createViewModel();
                }
                else
                {
                    MessageBox.Show("Password or username is incorrect, try again !!");
                }
            }
            else
            {
                MessageBox.Show("Enter the password or username !!");
            }
        }
    }
}
