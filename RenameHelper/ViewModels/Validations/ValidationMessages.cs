using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.ViewModels.Validations
{
    public abstract class ValidationMessages
    {
        public static string NULL_MESSAGE => "Please enter a value!";
        public static string EXCEPTION_MESSAGE => "Invalid value!";
    }
}
