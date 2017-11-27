using System;

namespace Util
{
    public class BuilderCommand : System.Windows.Input.ICommand
    {
        private Action action { get; set; }
        private Action<object> parametrizedAction { get; set; }
        private Predicate<object> canExecute { get; set; }

        public BuilderCommand(Action<object> parametrizedAction, Predicate<object> canExecute = null)
        {
            this.parametrizedAction = parametrizedAction;
            this.canExecute = canExecute;
        }

        public BuilderCommand(Action action, Predicate<object> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { System.Windows.Input.CommandManager.RequerySuggested += value; }
            remove { System.Windows.Input.CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null && canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (parametrizedAction != null)
            {
                parametrizedAction(parameter);
            }
            else if (action != null)
            {
                action();
            }
        }
    }
}
