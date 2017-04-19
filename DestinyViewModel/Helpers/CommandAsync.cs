using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DestinyViewModel
{
    public abstract class CommandAsync : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract Task<Object> ExecuteAsync(object parameter);
        private Predicate<Object> _canExecute = null;
        private List<string> _changedProperty = new List<string>();

        public CommandAsync(
            System.ComponentModel.INotifyPropertyChanged changer,
            CommandPropertyList properties,
            Predicate<Object> canExecute
            )
        {
            _canExecute = canExecute;
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

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
    }
}