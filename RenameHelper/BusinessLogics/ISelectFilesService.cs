using RenameHelper.Models;
using System.Collections.ObjectModel;

namespace RenameHelper.BusinessLogics
{
    public interface ISelectFilesService
    {
        string SelectFiles(ObservableCollection<MyFile> listFiles);
    }
}