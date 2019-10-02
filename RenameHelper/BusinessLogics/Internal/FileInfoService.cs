using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Internal
{
    public class FileInfoService
    {
        public MyFile GetMyFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var sizeInKb = $"{GetSizeInKb(fileInfo.Length):N0} KB";
            var icon = Icon.ExtractAssociatedIcon(filePath);
            return new MyFile(fileInfo.Name, sizeInKb, icon);
        }

        public long GetSizeInKb(long numOfBytes)
        {
            return numOfBytes / 1024;
        }
    }
}
