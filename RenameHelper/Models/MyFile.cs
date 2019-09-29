using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class MyFile
    {
        #region Properties
        public string Name { get; set; }
        #endregion

        #region Constructors
        public MyFile(string name)
        {
            Name = name;
        }
        #endregion
    }
}
