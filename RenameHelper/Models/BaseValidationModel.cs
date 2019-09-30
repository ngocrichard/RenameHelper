using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

namespace RenameHelper.Models
{
    public delegate string ValidatePropertyHandler(object senderModel, string propertyName);

    public abstract class BaseValidationModel : INotifyPropertyChanged, IDataErrorInfo
    {
        /// Use this event to register validation
        public event ValidatePropertyHandler OnValidateProperty;

        #region Implement IDataErrorInfo
        [DoNotNotify]
        public string Error { get; protected set; }

        public string this[string propertyName]
        {
            get
            {
                Error = Validate(propertyName);
                return Error;
            }
        }

        public string Validate(string propertyName)
        {
            return OnValidateProperty?.Invoke(this, propertyName);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
