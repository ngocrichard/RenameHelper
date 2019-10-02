using RenameHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics
{
    public class RenameServiceFacade
    {
        private readonly IRenameService RenameService;
        public readonly IUndoService UndoService;

        public RenameServiceFacade(IRenameService renameService, IUndoService undoService)
        {
            RenameService = renameService;
            UndoService = undoService;
        }

        public CommittedChange Rename(string directory, ObservableCollection<MyFile> currentFiles,
            BasicRequestData data, BasicRequestMode mode)
        {
            return RenameService.Rename(directory, currentFiles, data, mode);
        }

        public void Undo(ObservableCollection<MyFile> currentFiles, CommittedChange request)
        {
            UndoService.Undo(currentFiles, request);
        }
    }
}
