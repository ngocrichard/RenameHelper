﻿using RenameHelper.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RenameHelper.BusinessLogics
{
    public interface IRenameService
    {
        CommittedChange Rename(string directory, ObservableCollection<MyFile> currentFiles, BasicRequestData data, BasicRequestMode mode);
    }
}