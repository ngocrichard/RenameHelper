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
        private BasicRequestData data;
        #endregion

        #region Properties
        public RenameStatus Status;
        public string Name { get; set; }
        public string StartIndexStr { get; set; }
        public string StepStr { get; set; }
        public BasicRequestMode Mode { get; set; }
        public BasicRequestData Data
        {
            get
            {
                try
                {
                    data.Name = Name;
                    data.StartIndex = int.Parse(StartIndexStr);
                    data.Step = int.Parse(StepStr);
                }
                catch (Exception) { }
                return data;
            }
            set
            {
                data = value;
                Name = data.Name;
                StartIndexStr = data.StartIndex.ToString();
                StepStr = data.Step.ToString();
            }
        }
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
            Status = new RenameStatus();
            Data = new BasicRequestData("", 1, 1);
            Mode = new BasicRequestMode(false, true, IndexPlacement.Prefix);

            RegisterValidations();
        }

        /// Register validation for properties
        private void RegisterValidations()
        {
            OnValidateProperty += this.validations.RequestData.Validation;
        }
        #endregion
    }
}
