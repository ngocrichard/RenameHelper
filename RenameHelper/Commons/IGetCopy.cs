using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper
{
    public interface IGetCopy<T>
    {
        /// Get deep copy of object
        T GetCopy();
    }
}
