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
    public class UndoService : IUndoService
    {
        private readonly FileRenamer fileRenamer;
        private readonly FileInfoService fileInfoService;

        public UndoService(FileRenamer fileRenamer, FileInfoService fileInfoService)
        {
            this.fileRenamer = fileRenamer;
            this.fileInfoService = fileInfoService;
        }

        public void Undo(ObservableCollection<MyFile> currentFiles, CommittedChange request)
        {
            // Perform rename
            fileRenamer.Rename(request.Directory, request.NewFileNames, request.OldFileNames);
            // Update current files
            currentFiles.Clear();
            foreach (var oldFileName in request.OldFileNames)
            {
                var oldFile = fileInfoService.GetMyFile(Path.Combine(request.Directory, oldFileName));
                currentFiles.Add(oldFile);
            }
        }
    }
}
