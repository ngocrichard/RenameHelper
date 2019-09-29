using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.BusinessLogics.Helpers.Resolver;
using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Helpers
{
    public class RequestResolver
    {
        private readonly IndexResolver indexResolver;
        private readonly RomanNumeral romanNumeral;

        public RequestResolver(IndexResolver indexResolver, RomanNumeral romanNumeral)
        {
            this.indexResolver = indexResolver;
            this.romanNumeral = romanNumeral;
        }

        public string GetNewName(string oldName, int index, string newNameNotResolved, RequestMode mode)
        {
            // Resolve Roman numeral index
            string idxStr = mode.IsRomanNumeral ? romanNumeral.GetValue(index) : index.ToString();
            // Resolve keep current name mode
            if (mode.KeepCurrentName == true)
            {
                return GetNameFromCurrentName(oldName, idxStr, mode.IndexMode);
            }
            else
            {
                string extension = Path.GetExtension(oldName);
                return GetNameFromNewName(extension, newNameNotResolved, idxStr, mode.IndexMode);
            }
        }

        public string GetNameFromCurrentName(string currentName, string index, IndexPlacement idxMode)
        {
            string extension = Path.GetExtension(currentName);
            string oldNameNoExtension = Path.GetFileNameWithoutExtension(currentName);
            switch (idxMode)
            {
                case IndexPlacement.Postfix:
                    return indexResolver.ResolvePostfix(extension, oldNameNoExtension, index);
                case IndexPlacement.Prefix:
                    return indexResolver.ResolvePrefix(extension, oldNameNoExtension, index);
                default:
                    return null;
            }
        }

        public string GetNameFromNewName(string extension, string name, string index, IndexPlacement idxMode)
        {
            switch (idxMode)
            {
                case IndexPlacement.Postfix:
                    return indexResolver.ResolvePostfix(extension, name, index);
                case IndexPlacement.Prefix:
                    return indexResolver.ResolvePrefix(extension, name, index);
                default:
                    return null;
            }
        }
    }
}
