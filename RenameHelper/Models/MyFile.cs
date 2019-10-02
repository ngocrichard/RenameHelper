using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class MyFile
    {
        #region Properties
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public string SizeInKb { get; set; }
        public Icon Icon { get; set; }
        #endregion

        #region Constructors
        public MyFile(string name, string sizeInKb, Icon icon)
        {
            Name = name;
            SizeInKb = sizeInKb;
            Icon = icon;
            IsSelected = false;
        }
        #endregion
    }
}
