using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper
{
    public interface ISetCopy<T>
    {
        /// Set deep copy from source to this object
        void SetCopy(T source);
    }
}
