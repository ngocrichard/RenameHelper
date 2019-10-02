using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics.Internal.Resolver
{
    public class IndexResolver
    {
        public string ResolvePostfix(string extension, string fileNameNoExtension, string index)
        {
            return fileNameNoExtension + index + extension;
        }

        public string ResolvePrefix(string extension, string fileNameNoExtension, string index)
        {
            return index + fileNameNoExtension + extension;
        }
    }
}
