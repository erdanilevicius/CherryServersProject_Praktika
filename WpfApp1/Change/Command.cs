using System;
using System.Windows.Input;

namespace WpfApp1.Change
{
    class Command : ICommand
    {
        private Action<Object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter) {
            return this.canExecute == null || this.canExecute(parameter);
        
        }
        public void Execute(object parameter)
        {

            this.execute(parameter);
        }


    }
}
