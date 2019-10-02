using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class RenameStatus : BaseObservable
    {
        public bool CanRename { get; set; }
        
        public RenameStatus() { }
        public RenameStatus(bool canRename)
        {
            CanRename = canRename;
        }
    }
}
