using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.BusinessLogics.Services;

namespace RenameHelper.BusinessLogics
{
    public class ClientServiceFacade
    {
        #region Client services
        public ISelectFilesService SelectFiles { get; }
        public IRenameService Rename { get; }
        public IUndoService Undo { get; }
        public ICreditService Credit { get; }
        public IMessageBoxService MessageBox { get; }
        #endregion

        #region Constructor
        public ClientServiceFacade(ISelectFilesService selectFilesService, IRenameService renameService,
            IUndoService undoService, ICreditService creditService, IMessageBoxService messageBoxService)
        {
            SelectFiles = selectFilesService;
            Rename = renameService;
            Undo = undoService;
            Credit = creditService;
            MessageBox = messageBoxService;
        }
        #endregion
    }
}
