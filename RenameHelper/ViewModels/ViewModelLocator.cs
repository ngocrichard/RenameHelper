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
        private readonly NinjectContainer container;
        private readonly MainViewModel mainViewModel;

        public ViewModelLocator()
        {
            container = new NinjectContainer();
            mainViewModel = container.Get<MainViewModel>();
        }

        public MainViewModel MainViewModel
        {
            get => mainViewModel;
        }

        public BasicTabViewModel BasicTabViewModel
        {
            get => mainViewModel.BasicTabViewModel;
        }

        public AdvancedTabViewModel AdvancedTabViewModel
        {
            get => mainViewModel.AdvancedTabViewModel;
        }
    }
}
