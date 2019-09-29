using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Helpers
{
    public class FileInfoService
    {
        public MyFile GetMyFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return new MyFile(fileInfo.Name);
        }
    }
}
