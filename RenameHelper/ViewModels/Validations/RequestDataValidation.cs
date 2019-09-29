using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.Models;

namespace RenameHelper.ViewModels.Validations
{
    public class RequestDataValidation : BaseValidation
    {
        public override string Validation(object senderModel, string propertyName)
        {
            var model = senderModel as RequestData;
            switch (propertyName)
            {
                case "Name":
                    return ValidateName(model.Name);
                case "StartIndex":
                    return ValidateStartIndex(model.StartIndex);
                case "Step":
                    return ValidateStep(model.Step);
                default:
                    throw new Exception("Unexpected property: " + propertyName);
            }
        }

        public string ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            var invalidChars = Path.GetInvalidFileNameChars();
            if (name.IndexOfAny(invalidChars) != -1)
                return "A file name can't contain any of the following characters: < > | : * ? \\ /";
            return null;
        }

        public string ValidateStartIndex(int startIndex)
        {
            if (startIndex < 0)
                return "Invalid start index!";
            return null;
        }

        public string ValidateStep(int counter)
        {
            if (counter < 0)
                return "Invalid counter!";
            return null;
        }
    }
}
