using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper
{
    public class RenameErrorException : Exception
    {
        public readonly RenameErrorInfo ErrorInfo;

        public RenameErrorException(RenameErrorInfo renameErrorInfo)
        {
            ErrorInfo = renameErrorInfo;
        }

        public override string Message
        {
            get
            {
                switch (ErrorInfo)
                {
                    case RenameErrorInfo.AccessIsDenied:
                        return "Access is denied!";
                    case RenameErrorInfo.FileNameExists:
                        return "One of new file names is already exists!";
                    case RenameErrorInfo.OutOfRomanNumeralsRange:
                        return "Out of range of Roman numerals!";
                    default:
                        return null;
                }
            }
        }
    }
}
