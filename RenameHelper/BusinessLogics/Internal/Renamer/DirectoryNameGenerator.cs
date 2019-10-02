using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics.Internal.Renamer
{
    public class DirectoryNameGenerator
    {
        public string Generate(string parentPath)
        {
            string newDirectory;
            do
            {
                newDirectory = Path.Combine(parentPath, Guid.NewGuid().ToString());
            } while (Directory.Exists(newDirectory));
            return newDirectory;
        }
    }
}
