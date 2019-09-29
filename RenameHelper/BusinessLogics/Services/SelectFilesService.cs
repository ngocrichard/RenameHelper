using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.BusinessLogics.Helpers;
using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Services
{
    public class SelectFilesService : ISelectFilesService
    {
        private readonly OpenFileService openFileService;
        private readonly FileInfoService fileInfoService;

        public SelectFilesService(OpenFileService openFileService, FileInfoService fileInfoService)
        {
            this.openFileService = openFileService;
            this.fileInfoService = fileInfoService;
        }

        public string SelectFiles(ObservableCollection<MyFile> listFiles)
        {
            // Get file paths
            var filePaths = openFileService.OpenFiles();

            // Check if any file opened
            if (filePaths == null) return string.Empty;

            // Extract directory from first selected file
            string directory = Path.GetDirectoryName(filePaths.First());
            listFiles.Clear();
            foreach (var filePath in filePaths)
            {
                listFiles.Add(fileInfoService.GetMyFile(filePath));
            }
            return directory;
        }
    }
}
