using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.ViewModels.Validations
{
    public class StringToIntValidation
    {
        public string StringToInt(string intStr, out int value)
        {
            value = 0;
            if (string.IsNullOrEmpty(intStr))
                return ValidationMessages.NULL_MESSAGE;

            string message = ValidationMessages.EXCEPTION_MESSAGE;
            if (!int.TryParse(intStr, out value))
                return message;
            return null;
        }
    }
}
