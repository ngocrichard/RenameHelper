using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Core
{
    public interface IContainer
    {
        T Get<T>();
    }
}
