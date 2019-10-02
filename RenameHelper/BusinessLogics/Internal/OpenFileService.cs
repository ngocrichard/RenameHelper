using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RenameHelper.BusinessLogics.Internal
{
    public class OpenFileService
    {
        public string OpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            // Return file name if client click OK
            if (dialog.ShowDialog().GetValueOrDefault())
                return dialog.FileName;
            return null;
        }

        public string[] OpenFiles()
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            // Return file name if client click OK
            if (dialog.ShowDialog().GetValueOrDefault())
                return dialog.FileNames;
            return null;
        }
    }
}
