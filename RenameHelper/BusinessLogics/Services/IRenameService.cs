using RenameHelper.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RenameHelper.BusinessLogics.Services
{
    public interface IRenameService
    {
        CommittedChange Rename(string directory, ObservableCollection<MyFile> currentFiles, RequestData data, RequestMode mode);
    }
}