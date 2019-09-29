using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RenameHelper
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields
        private readonly Action<T> excute;
        private readonly Predicate<T> canExcute;
        #endregion

        #region Constructors
        public RelayCommand(Action<T> excute, Predicate<T> canExcute)
        {
            this.excute = excute ?? throw new ArgumentNullException();
            this.canExcute = canExcute;
        }

        public RelayCommand(Action<T> excute) : this(excute, null) { }
        #endregion

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            return canExcute == null ? true : canExcute((T)parameter);
        }

        public void Execute(object parameter)
        {
            excute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
    }
}
