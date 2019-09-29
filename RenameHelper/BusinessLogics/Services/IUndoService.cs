using RenameHelper.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RenameHelper.BusinessLogics.Services
{
    public interface IUndoService
    {
        void Undo(ObservableCollection<MyFile> currentFiles, CommittedChange request);
    }
}