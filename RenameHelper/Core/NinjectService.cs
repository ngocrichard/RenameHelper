using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.ViewModels;
using RenameHelper.BusinessLogics.Services;

namespace RenameHelper.Core
{
    public class NinjectService
    {
        #region Kernel
        private readonly IKernel kernel;
        #endregion

        #region Constructor
        public NinjectService()
        {
            kernel = new StandardKernel();
            Binding();
        }
        #endregion

        #region Binding dependencies
        void Binding()
        {
            /* 
             * Binding dependencies here.
             * For example: kernel.Bind<IModule>().To<Module>();
             */

            kernel.Bind<ISelectFilesService>().To<SelectFilesService>();
            kernel.Bind<IRenameService>().To<RenameService>();
            kernel.Bind<IUndoService>().To<UndoService>();
            kernel.Bind<ICreditService>().To<CreditService>();
            kernel.Bind<IMessageBoxService>().To<MessageBoxService>();
        }
        #endregion

        #region Create property for ViewModels
        public MainViewModel MainViewModel
        {
            get => kernel.Get<MainViewModel>();
        }
        #endregion
    }
}
