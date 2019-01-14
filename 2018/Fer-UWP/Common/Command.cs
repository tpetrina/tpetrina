using System;
using System.Windows.Input;

namespace Common
{
    internal class Command : ICommand
    {
        private Action<object> incImpl;

        public event EventHandler CanExecuteChanged;

        public Command(Action<object> incImpl) => this.incImpl = incImpl;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => incImpl?.Invoke(parameter);
    }
}