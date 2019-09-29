using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.ViewModels.Validations
{
    public abstract class BaseValidation
    {
        /// Validate model in this method
        public abstract string Validation(object model, string propertyName);
    }
}
