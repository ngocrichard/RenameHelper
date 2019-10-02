using RenameHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics.Internal
{
    public class SelectedFileInfo
    {
        public int FirstIndex { get; set; }
        public int Length { get; set; }
        public bool Consecutive { get; set; }

        public SelectedFileInfo(int firstIndex, int length, bool consecutive)
        {
            FirstIndex = firstIndex;
            Length = length;
            Consecutive = consecutive;
        }
    }

    public class SelectedFileInfoService
    {
        public List<MyFile> GetAll(ObservableCollection<MyFile> currentFiles)
        {
            return currentFiles.Where(c => c.IsSelected).ToList();
        }

        public SelectedFileInfo GetInfo(ObservableCollection<MyFile> currentFiles)
        {
            // Iterate the collection
            var listSelectedIndex = new List<int>();
            int index = 0;
            foreach (var file in currentFiles)
            {
                if (file.IsSelected)
                    listSelectedIndex.Add(index);
                index++;
            }

            // If not selected any file
            if (listSelectedIndex.Count == 0)
                return null;

            int firstIndex = listSelectedIndex.First();
            int length = listSelectedIndex.Count;
            int lastIndex = listSelectedIndex.Last();
            // If not consecutive
            if (firstIndex + length - 1 != lastIndex)
                return new SelectedFileInfo(0, 0, false);

            return new SelectedFileInfo(firstIndex, length, true);
        }
    }
}
