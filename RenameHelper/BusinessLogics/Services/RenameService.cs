﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.BusinessLogics.Helpers;
using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Services
{
    public class RenameService : IRenameService
    {
        private readonly FileRenamer renamer;
        private readonly RequestResolver resolver;
        private readonly FileInfoService fileInfoService;

        public RenameService(FileRenamer renamer, RequestResolver resolver, FileInfoService fileInfoService)
        {
            this.renamer = renamer;
            this.resolver = resolver;
            this.fileInfoService = fileInfoService;
        }

        public CommittedChange Rename(string directory, ObservableCollection<MyFile> currentFiles,
            RequestData data, RequestMode mode)
        {
            var currentFileNames = currentFiles.Select(file => file.Name).ToList();
            // Process request
            var newFileNames = GetNewFileNames(directory, currentFiles, data, mode);
            // Perform rename
            renamer.Rename(directory, currentFiles.Select(file => file.Name), newFileNames);
            // Update current files
            currentFiles.Clear();
            foreach (var newFileName in newFileNames)
            {
                var newFile = fileInfoService.GetMyFile(Path.Combine(directory, newFileName));
                currentFiles.Add(newFile);
            }
            // Return committed change
            var change = new CommittedChange(directory, currentFileNames, newFileNames, data.GetCopy(), mode.GetCopy());
            return change;
        }

        public List<string> GetNewFileNames(string directory, ObservableCollection<MyFile> currentFiles,
            RequestData data, RequestMode mode)
        {
            var newFileNames = new List<string>();
            int idx = data.StartIndex;
            foreach (var file in currentFiles)
            {
                // Resolve new name
                string newFileName = resolver.GetNewName(file.Name, idx, data.Name, mode);
                // Add new file to collection
                newFileNames.Add(newFileName);
                idx += data.Step;
            }
            return newFileNames;
        }
    }
}
