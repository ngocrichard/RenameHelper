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
    public class MainViewModel : BaseObservable
    {
        #region Fields
        private const string SUCCESS_CAPTION = "Congratulation!";
        private const string ERROR_CAPTION = "Error!";
        #endregion

        #region Properties
        public ObservableCollection<MyFile> CurrentFiles { get; set; }

        public string CurrentDirectory { get; set; }
        public Stack<CommittedChange> History { get; }
        #endregion

        #region Dependencies
        public BasicTabViewModel BasicTabViewModel { get; }
        public AdvancedTabViewModel AdvancedTabViewModel { get; }
        private readonly ClientServiceFacade clientServices;
        private readonly ValidationFacade validations;
        #endregion

        #region Constructor
        public MainViewModel(ClientServiceFacade clientServices, ValidationFacade validations,
            BasicTabViewModel basicTabViewModel, AdvancedTabViewModel advancedTabViewModel)
        {
            /// Inject dependencies
            this.BasicTabViewModel = basicTabViewModel;
            this.AdvancedTabViewModel = advancedTabViewModel;
            this.clientServices = clientServices;
            this.validations = validations;

            /// Initialize properties
            CurrentFiles = new ObservableCollection<MyFile>();
            History = new Stack<CommittedChange>();

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
            SelectFilesCmd = new RelayCommand<object>(SelectFilesExcute);
            RenameCmd = new RelayCommand<object>(RenameExcute);
            UndoCmd = new RelayCommand<object>(UndoExcute);
            CreditCmd = new RelayCommand<object>(ShowCreditExcute);
        }
        #endregion

        #region Commands
        public ICommand SelectFilesCmd { get; set; }
        public ICommand RenameCmd { get; set; }
        public ICommand UndoCmd { get; set; }
        public ICommand CreditCmd { get; set; }

        private void SelectFilesExcute(object obj)
        {
            string newDirectory = clientServices.SelectFiles.SelectFiles(CurrentFiles);
            if (!string.IsNullOrEmpty(newDirectory))
                CurrentDirectory = newDirectory;
        }

        private void RenameExcute(object obj)
        {
            try
            {
                var commitedChange = clientServices.Rename.Rename(CurrentDirectory, CurrentFiles,
                    BasicTabViewModel.Data, BasicTabViewModel.Mode);
                // Save request to history if successfully
                History.Push(commitedChange);
                // Update state
                clientServices.MessageBox.Show("All files were renamed successfully!", SUCCESS_CAPTION);
            }
            catch (RenameErrorException exception)
            {
                clientServices.MessageBox.Show(exception.Message, ERROR_CAPTION);
            }
            catch (Exception)
            {
                clientServices.MessageBox.Show("Something when wrong!", ERROR_CAPTION);
            }
            finally
            {
                RaisePropertyChanged("History");
            }
        }

        private void UndoExcute(object obj)
        {
            if (History.Count == 0)
                return;

            try
            {
                var lastChange = History.Pop();
                clientServices.Undo.Undo(CurrentFiles, lastChange);
                // Restore state if success
                CurrentDirectory = lastChange.Directory;
                BasicTabViewModel.Mode = lastChange.Mode;
                BasicTabViewModel.Data.SetCopy(lastChange.Data);
                clientServices.MessageBox.Show("Undo successfully!", SUCCESS_CAPTION);
            }
            catch (RenameErrorException exception)
            {
                clientServices.MessageBox.Show(exception.Message, ERROR_CAPTION);
            }
            catch (Exception)
            {
                clientServices.MessageBox.Show("Something when wrong!", ERROR_CAPTION);
                History.Clear();
            }
            finally
            {
                RaisePropertyChanged("History");
            }
        }

        private void ShowCreditExcute(object obj)
        {
            clientServices.Credit.ShowCredit();
        }
        #endregion
    }
}
