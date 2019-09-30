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
    public class NinjectContainer : IContainer
    {
        #region Properties
        private IKernel kernel { get; }
        #endregion

        #region Constructor
        public NinjectContainer()
        {
            kernel = new StandardKernel();
            Binding();
        }
        #endregion

        #region Implement IContainer
        public T Get<T>()
        {
            return kernel.Get<T>();
        }
        #endregion

        #region Binding dependencies
        private void Binding()
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
    }
}
