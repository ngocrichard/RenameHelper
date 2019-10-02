using RenameHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics
{
    public interface IListFilesService
    {
        void MoveUp(ObservableCollection<MyFile> currentFiles);
        void MoveDown(ObservableCollection<MyFile> currentFiles);
        void Remove(ObservableCollection<MyFile> currentFiles);
    }
}
