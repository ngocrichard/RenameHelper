using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.ViewModels.Validations
{
    public class ValidationFacade
    {
        #region Validations
        public BasicTabValidate RequestData { get; }
        #endregion

        #region Constructor
        public ValidationFacade(BasicTabValidate requestData)
        {
            RequestData = requestData;
        }
        #endregion
    }
}
