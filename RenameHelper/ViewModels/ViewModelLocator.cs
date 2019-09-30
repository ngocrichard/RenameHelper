using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.Core;

namespace RenameHelper.ViewModels
{
    public class ViewModelLocator
    {
        #region Fields
        private readonly NinjectContainer container;
        private MainViewModel mainViewModel;
        #endregion

        #region Constructors
        public ViewModelLocator()
        {
            container = new NinjectContainer();
        }
        #endregion

        #region Locate ViewModels
        public MainViewModel MainViewModel
        {
            get
            {
                if (mainViewModel == null)
                    mainViewModel = container.Get<MainViewModel>();
                return mainViewModel;
            }
        }

        public BasicTabViewModel BasicTabViewModel
        {
            get => mainViewModel.BasicTabViewModel;
        }

        public AdvancedTabViewModel AdvancedTabViewModel
        {
            get => mainViewModel.AdvancedTabViewModel;
        }
        #endregion
    }
}
