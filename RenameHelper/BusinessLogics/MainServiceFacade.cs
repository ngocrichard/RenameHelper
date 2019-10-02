using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics
{
    public class MainServiceFacade
    {
        #region Main services
        public ISelectFilesService SelectFilesService { get; }
        public ICreditService CreditService { get; }
        public IMessageBoxService MessageBoxService { get; }
        public RenameServiceFacade RenameServices { get; }
        #endregion

        #region Constructor
        public MainServiceFacade(ISelectFilesService selectFilesService, ICreditService creditService,
            IMessageBoxService messageBoxService, RenameServiceFacade renameServiceFacade)
        {
            SelectFilesService = selectFilesService;
            CreditService = creditService;
            MessageBoxService = messageBoxService;
            RenameServices = renameServiceFacade;
        }
        #endregion
    }
}
