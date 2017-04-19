using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DestinyViewModel
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Predicate<Object> _canExecute = null;
        private Action<Object> _executeAction = null;
        private List<string> _changedProperty = new List<string>();

        public Command(
            System.ComponentModel.INotifyPropertyChanged changer,
            CommandPropertyList properties,
            Predicate<object> canExecute,
            Action<object> executeAction
            )
        {
            _canExecute = canExecute;
            _executeAction = executeAction;
            _changedProperty = properties;
            changer.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(changer_PropertyChanged);
        }


        private void changer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            foreach (string _s in _changedProperty)
            {
                if (e.PropertyName == _s)
                {
                    UpdateCanExecuteState();
                    return;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public void UpdateCanExecuteState()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            if (_executeAction != null)
                _executeAction(parameter);
        }
    }
}