using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper
{
    /*
     * Extend this class instead of directly implementing INotifyPropertyChanged.
     * Even with the help from package, sometimes we have to raise the event ourselves.
     */
    public abstract class BaseObservable : INotifyPropertyChanged
    {
        /// Use this method to notify property changed
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
