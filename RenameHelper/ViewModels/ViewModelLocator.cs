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
        private static ViewModelLocator instance;
        #endregion

        #region Properties
        public static ViewModelLocator Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewModelLocator();
                return instance;
            }
        }
        #endregion

        #region Constructors
        private ViewModelLocator()
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

        public FilesViewModel FilesViewModel
        {
            get => mainViewModel.FilesViewModel;
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
