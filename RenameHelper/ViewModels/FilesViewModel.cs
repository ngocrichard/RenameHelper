using RenameHelper.BusinessLogics;
using RenameHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RenameHelper.ViewModels
{
    public class FilesViewModel : BaseObservable
    {
        #region Fields

        #endregion

        #region Properties
        public ObservableCollection<MyFile> CurrentFiles { get; set; }
        #endregion

        #region Dependencies
        private readonly IListFilesService listViewFileService;
        #endregion

        #region Constructor
        public FilesViewModel(IListFilesService listViewFileService)
        {
            /// Inject dependencies
            this.listViewFileService = listViewFileService;

            /// Initialize properties
            CurrentFiles = new ObservableCollection<MyFile>();

            RegisterValidations();
            ImplementsCommands();
        }

        /// Register validation for properties
        private void RegisterValidations()
        {

        }

        /// Implement commands for binding
        private void ImplementsCommands()
        {
            MoveFileUpCmd = new RelayCommand<object>(MoveFileUpExcute);
            MoveFileDownCmd = new RelayCommand<object>(MoveFileDownExcute);
            RemoveFileCmd = new RelayCommand<object>(RemoveFileExcute);
        }
        #endregion

        #region Event
        public event GetPropertyFromChildHandler GetDirectory;
        public event ThrowExceptionHandler ThrowException;
        #endregion

        #region Command

        #region Interfaces
        public ICommand MoveFileUpCmd { get; set; }
        public ICommand MoveFileDownCmd { get; set; }
        public ICommand RemoveFileCmd { get; set; }
        #endregion

        #region Move file up command
        private void MoveFileUpExcute(object obj)
        {
            try
            {
                listViewFileService.MoveUp(CurrentFiles);
            }
            catch (Exception e)
            {
                ThrowException?.Invoke(this, e.Message);
            }
        }
        #endregion

        #region Move file down command
        private void MoveFileDownExcute(object obj)
        {
            try
            {
                listViewFileService.MoveDown(CurrentFiles);
            }
            catch (Exception e)
            {
                ThrowException?.Invoke(this, e.Message);
            }
        }
        #endregion

        #region Remove file command
        private void RemoveFileExcute(object obj)
        {
            try
            {
                listViewFileService.Remove(CurrentFiles);
            }
            catch (Exception e)
            {
                ThrowException?.Invoke(this, e.Message);
            }
        }

        #endregion

        #endregion
    }
}
