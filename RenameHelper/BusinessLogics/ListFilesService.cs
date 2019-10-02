using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.BusinessLogics.Internal;
using RenameHelper.Models;

namespace RenameHelper.BusinessLogics
{
    public class ListFilesService : IListFilesService
    {
        public const string ERROR_MESSAGE = "Please select consecutive files";

        private readonly SelectedFileInfoService selectedFileInfoService;

        public ListFilesService(SelectedFileInfoService selectedFileInfoService)
        {
            this.selectedFileInfoService = selectedFileInfoService;
        }

        public void MoveUp(ObservableCollection<MyFile> currentFiles)
        {
            var info = selectedFileInfoService.GetInfo(currentFiles);
            // If not selected any file
            if (info == null)
                return;
            if (!info.Consecutive)
                throw new Exception(ERROR_MESSAGE);
            // If selected first file
            if (info.FirstIndex == 0)
                return;

            var temp = currentFiles.ElementAt(info.FirstIndex - 1);
            currentFiles.Remove(temp);
            int newIndex = info.FirstIndex + info.Length - 1;
            currentFiles.Insert(newIndex, temp);
        }

        public void MoveDown(ObservableCollection<MyFile> currentFiles)
        {
            var info = selectedFileInfoService.GetInfo(currentFiles);
            // If not selected any file
            if (info == null)
                return;
            if (!info.Consecutive)
                throw new Exception(ERROR_MESSAGE);
            // If selected last file
            if (info.FirstIndex + info.Length == currentFiles.Count)
                return;

            var temp = currentFiles.ElementAt(info.FirstIndex + info.Length);
            currentFiles.Remove(temp);
            currentFiles.Insert(info.FirstIndex, temp);

        }

        public void Remove(ObservableCollection<MyFile> currentFiles)
        {
            var selectedFiles = selectedFileInfoService.GetAll(currentFiles);
            foreach (var file in selectedFiles)
            {
                currentFiles.Remove(file);
            }
        }
    }
}
