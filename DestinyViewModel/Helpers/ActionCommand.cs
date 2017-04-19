using System;
using System.Windows.Input;

namespace DestinyViewModel
{
    public class ActionCommand : ICommand
    {
        private Action _action;
        private Func<bool> _condition;

        public ActionCommand()
        {
            _action = delegate { };
            _condition = () => true;
        }
        public ActionCommand(Action action)
        {
            _action = action;
            _condition = () => true;
        }

        public ActionCommand(Action action, Func<bool> condition)
        {
            _action = action;
            _condition = condition;
        }


        public event EventHandler CanExecuteChanged = delegate { };
        public void RaiseExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }
        public bool CanExecute(object parameter)
        {
            return _condition();
        }
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
