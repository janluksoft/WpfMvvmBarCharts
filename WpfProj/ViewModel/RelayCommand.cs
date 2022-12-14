using System;
using System.Windows.Input;

namespace WpfProj.ViewModel
{
    internal class RelayCommand : ICommand
    {
        // Two delegats:
        // 1 delegat) Action
        // 2 delegat) Predicate

        private readonly Action<object> command;
        private readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> command) : this(command, null)
        {
        }

        public RelayCommand(Action<object> command, Predicate<object> canExecute)
        {
            this.command = command ?? throw new ArgumentNullException(nameof(command));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            command.Invoke(parameter);
        }
    }
}
