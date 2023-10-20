using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Assistant.Commands
{
    public class ExitCommand : CommandBase
    {
        private readonly ExitViewModel _exitViewModel;
        public ExitCommand(ExitViewModel exitViewModel)
        {
            _exitViewModel = exitViewModel;
        }
        public override void Execute(object parameter)
        {
            if (!string.IsNullOrEmpty(_exitViewModel.Password) && !string.IsNullOrEmpty(_exitViewModel.Password))
            {

                if (_exitViewModel.Password == "turin" && _exitViewModel.UserName == "turin")
                {
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("password or username is incorrect, try again !!");
                }
            }
            else
            {
                MessageBox.Show("Enter the password or username!!");
            }
        }
    }
}
