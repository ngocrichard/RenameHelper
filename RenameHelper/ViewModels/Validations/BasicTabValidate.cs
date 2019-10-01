using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.Models;

namespace RenameHelper.ViewModels.Validations
{
    public class BasicTabValidate : BasePropertyValidation
    {
        private BasicTabViewModel obj;
        private readonly StringToIntValidation stringToIntValidation;

        public BasicTabValidate(StringToIntValidation stringToIntValidation)
        {
            this.stringToIntValidation = stringToIntValidation;
        }

        public override string Validation(object senderModel, string propertyName)
        {
            obj = senderModel as BasicTabViewModel;
            obj.Status.CanRename = false;

            string error = null;
            switch (propertyName)
            {
                case "Name":
                    error = ValidateName(obj.Name);
                    break;
                case "StartIndexStr":
                    error = ValidateStartIndex(obj.StartIndexStr);
                    break;
                case "StepStr":
                    error = ValidateStep(obj.StepStr);
                    break;
                default:
                    throw new Exception("Unexpected property: " + propertyName);
            }

            if (string.IsNullOrEmpty(error))
                obj.Status.CanRename = true;
            return error;
        }

        public string ValidateName(string name)
        {
            // Check current mode
            if (obj.Mode.KeepCurrentName == true)
                return null;

            if (string.IsNullOrEmpty(name))
                return null;

            var invalidChars = Path.GetInvalidFileNameChars();
            if (name.IndexOfAny(invalidChars) != -1)
                return "A file name can't contain any of the following characters: < > | : * ? \\ /";
            return null;
        }

        public string ValidateStartIndex(string startIndex)
        {
            int value;
            string message = stringToIntValidation.StringToInt(startIndex, out value);
            if (!string.IsNullOrEmpty(message))
                return message;
            return null;
        }

        public string ValidateStep(string counter)
        {
            int value;
            string message = stringToIntValidation.StringToInt(counter, out value);
            if (!string.IsNullOrEmpty(message))
                return message;
            return null;
        }
    }
}
