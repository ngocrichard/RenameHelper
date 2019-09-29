using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RenameHelper.BusinessLogics.Helpers.Renamer;
using RenameHelper.Models;

namespace RenameHelper.BusinessLogics.Helpers
{
    public class FileRenamer
    {
        public DirectoryNameGenerator DirectoryGenerator { get; }
        public RequestChecker Checker { get; }

        public FileRenamer(DirectoryNameGenerator directoryGenerator, RequestChecker checker)
        {
            DirectoryGenerator = directoryGenerator;
            Checker = checker;
        }

        public void Rename(string directory, IEnumerable<string> currentFileName, IEnumerable<string> newFileNames)
        {
            // Check if can rename
            if (!Checker.Check(directory, currentFileName, newFileNames))
                throw new RenameErrorException(RenameErrorInfo.FileNameExists);

            try
            {
                // Create temp directory
                string tempDirectory = DirectoryGenerator.Generate(directory);
                Directory.CreateDirectory(tempDirectory);
                // Perform rename
                PerformRename(directory, tempDirectory, currentFileName, newFileNames);
                // Delete temp directory
                Directory.Delete(tempDirectory);
            }
            catch (Exception)
            {
                throw new RenameErrorException(RenameErrorInfo.AccessIsDenied);
            }
        }

        public void PerformRename(string directory, string tempDirectory, IEnumerable<string> currentFileNames,
            IEnumerable<string> newFileNames)
        {
            var currentFileNamesEnum = currentFileNames.GetEnumerator();
            var newFileNamesEnum = newFileNames.GetEnumerator();

            // Rename and move to temp directory
            string source, destination;
            while (currentFileNamesEnum.MoveNext())
            {
                newFileNamesEnum.MoveNext();
                source = Path.Combine(directory, currentFileNamesEnum.Current);
                destination = Path.Combine(tempDirectory, newFileNamesEnum.Current);
                File.Move(source, destination);
            }

            // Move back to directory
            newFileNamesEnum = newFileNames.GetEnumerator();
            while (newFileNamesEnum.MoveNext())
            {
                source = Path.Combine(tempDirectory, newFileNamesEnum.Current);
                destination = Path.Combine(directory, newFileNamesEnum.Current);
                File.Move(source, destination);
            }
        }
    }
}
