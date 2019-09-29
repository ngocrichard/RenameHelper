using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class CommittedChange
    {
        #region Properties
        public string Directory { get; set; }
        public List<string> OldFileNames { get; set; }
        public List<string> NewFileNames { get; set; }
        public RequestData Data { get; set; }
        public RequestMode Mode { get; set; }
        #endregion

        #region Constructors
        public CommittedChange(string directory, List<string> oldFileNames, List<string> newFileNames,
            RequestData data, RequestMode mode)
        {
            Directory = directory;
            OldFileNames = oldFileNames;
            NewFileNames = newFileNames;
            Data = data;
            Mode = mode;
        }
        #endregion
    }
}
