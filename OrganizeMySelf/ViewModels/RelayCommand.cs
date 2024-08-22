using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrganizeMySelf.ViewModels
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> executeMethod;
        private Predicate<object> CanExecuteMethod;

        public RelayCommand(Action<object> Excecute, Predicate<object> CanExecute)
        {
            this.executeMethod = Excecute;
            this.CanExecuteMethod = CanExecute;
        }

        public RelayCommand(Action<object> Excecute) : this(Excecute, null) { }

        public bool CanExecute(object parameter)
        {
            return (CanExecuteMethod == null) ? true : CanExecuteMethod.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}

