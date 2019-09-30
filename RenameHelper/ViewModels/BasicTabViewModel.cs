using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.Models;
using RenameHelper.ViewModels.Validations;

namespace RenameHelper.ViewModels
{
    public class BasicTabViewModel : BaseValid
    {
        #region Fields
        private BasicRequestMode mode;
        #endregion

        #region Properties
        public BasicRequestMode Mode
        {
            get => mode;
            set
            {
                mode = value;
                RaisePropertyChanged();
            }
        }

        public BasicRequestData Data { get; }
        #endregion

        #region Dependencies
        private readonly ValidationFacade validations;
        #endregion

        #region Constructor
        public BasicTabViewModel(ValidationFacade validations)
        {
            /// Inject dependencies
            this.validations = validations;

            /// Initialize properties
            Data = new BasicRequestData("", 1, 1);
            Mode = new BasicRequestMode(false, true, IndexPlacement.Prefix);

            RegisterValidations();
        }

        /// Register validation for properties
        private void RegisterValidations()
        {
            Data.OnValidateProperty += this.validations.RequestData.Validation;
        }
        #endregion
    }
}
