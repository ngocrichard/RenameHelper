using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using RenameHelper.BusinessLogics;
using RenameHelper.Models;
using RenameHelper.ViewModels.Validations;

namespace RenameHelper.ViewModels
{
    public class MainViewModel : BaseValid
    {
        #region Fields
        private const string SUCCESS_CAPTION = "Congratulation!";
        private const string ERROR_CAPTION = "Error!";
        #endregion

        #region Properties
        public RenameStatus Status { get; set; }
        public string CurrentDirectory { get; set; }
        public Stack<CommittedChange> History { get; }
        #endregion

        #region Dependencies
        public BasicTabViewModel BasicTabViewModel { get; }
        public AdvancedTabViewModel AdvancedTabViewModel { get; }
        public FilesViewModel FilesViewModel { get; }
        private readonly MainServiceFacade clientServices;
        private readonly ValidationFacade validations;
        #endregion

        #region Constructor
        public MainViewModel(MainServiceFacade clientServices, ValidationFacade validations,
            BasicTabViewModel basicTabViewModel, AdvancedTabViewModel advancedTabViewModel,
            FilesViewModel filesViewModel)
        {
            /// Inject dependencies
            this.BasicTabViewModel = basicTabViewModel;
            this.AdvancedTabViewModel = advancedTabViewModel;
            this.FilesViewModel = filesViewModel;
            this.clientServices = clientServices;
            this.validations = validations;

            /// Initialize properties
            Status = basicTabViewModel.Status;
            History = new Stack<CommittedChange>();

            RegisterValidations();
            ImplementsCommands();
            HandleChildEvents();
        }

        /// Register validation for properties
        private void RegisterValidations()
        {
            
        }

        /// Implement commands for binding
        private void ImplementsCommands()
        {
            SelectFilesCmd = new RelayCommand<object>(SelectFilesExcute);
            RenameCmd = new RelayCommand<object>(RenameExcute, CanRename);
            UndoCmd = new RelayCommand<object>(UndoExcute, obj => History.Count > 0);
            CreditCmd = new RelayCommand<object>(CreditExcute);
        }

        private void HandleChildEvents()
        {
            FilesViewModel.GetDirectory += (obj, e) => CurrentDirectory;
            FilesViewModel.ThrowException += (obj, message) =>
                clientServices.MessageBoxService.Show(message, ERROR_CAPTION);
        }
        #endregion

        #region Commands

        #region Interfaces
        public ICommand SelectFilesCmd { get; set; }
        public ICommand RenameCmd { get; set; }
        public ICommand UndoCmd { get; set; }
        public ICommand CreditCmd { get; set; }
        #endregion

        #region Select files command
        private void SelectFilesExcute(object obj)
        {
            string newDirectory = clientServices.SelectFilesService.SelectFiles(FilesViewModel.CurrentFiles);
            if (!string.IsNullOrEmpty(newDirectory))
                CurrentDirectory = newDirectory;
        }
        #endregion

        #region Rename command
        private void RenameExcute(object obj)
        {
            try
            {
                var commitedChange = clientServices.RenameServices.Rename(CurrentDirectory, FilesViewModel.CurrentFiles,
                    BasicTabViewModel.Data, BasicTabViewModel.Mode);
                // Save request to history if successfully
                History.Push(commitedChange);
                // Update state
                clientServices.MessageBoxService.Show("All files were renamed successfully!", SUCCESS_CAPTION);
            }
            catch (RenameErrorException exception)
            {
                clientServices.MessageBoxService.Show(exception.Message, ERROR_CAPTION);
            }
            catch (Exception)
            {
                clientServices.MessageBoxService.Show("Something when wrong!", ERROR_CAPTION);
            }
            finally
            {
                RaisePropertyChanged("History");
            }
        }

        private bool CanRename(object obj)
        {
            return !string.IsNullOrEmpty(CurrentDirectory) && Status.CanRename;
        }
        #endregion

        #region Undo command
        private void UndoExcute(object obj)
        {
            if (History.Count == 0)
                return;

            try
            {
                var lastChange = History.Pop();
                clientServices.RenameServices.Undo(FilesViewModel.CurrentFiles, lastChange);
                // Restore state if success
                CurrentDirectory = lastChange.Directory;
                BasicTabViewModel.Mode = lastChange.Mode;
                BasicTabViewModel.Data = lastChange.Data;
                clientServices.MessageBoxService.Show("Undo successfully!", SUCCESS_CAPTION);
            }
            catch (RenameErrorException exception)
            {
                clientServices.MessageBoxService.Show(exception.Message, ERROR_CAPTION);
            }
            catch (Exception)
            {
                clientServices.MessageBoxService.Show("Something when wrong!", ERROR_CAPTION);
                History.Clear();
            }
            finally
            {
                RaisePropertyChanged("History");
            }
        }
        #endregion

        #region Credit command
        private void CreditExcute(object obj)
        {
            clientServices.CreditService.ShowCredit();
        }
        #endregion

        #endregion
    }
}
