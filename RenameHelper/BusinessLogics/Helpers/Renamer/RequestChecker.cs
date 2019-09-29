using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Helpers.Renamer
{
    public class RequestChecker
    {
        public bool Check(string directory, IEnumerable<string> currentFileNames, IEnumerable<string> newFileNames)
        {
            foreach (var newFileName in newFileNames)
            {
                // Check if new file name is valid, first exclude old names
                bool inValid = !currentFileNames.Contains(newFileName);
                // Now check remaining files in directory
                inValid = inValid && File.Exists(Path.Combine(directory, newFileName));
                if (inValid) return false;
            }
            return true;
        }
    }
}
