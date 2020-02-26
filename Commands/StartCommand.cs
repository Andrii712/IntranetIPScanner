using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace IntranetIPScanner.Commands
{
    class StartCommand : ICommand
    {
        #region ICommand Members
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
