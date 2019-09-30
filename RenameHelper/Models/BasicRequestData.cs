using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class BasicRequestData : BaseValid, ISetCopy<BasicRequestData>, IGetCopy<BasicRequestData>
    {
        #region Properties
        public string Name { get; set; }

        public int StartIndex { get; set; }

        public int Step { get; set; }
        #endregion

        #region Constructor
        public BasicRequestData(string name, int startIndex, int counter)
        {
            Name = name;
            StartIndex = startIndex;
            Step = counter;
        }
        #endregion

        #region Implement IGetCopy and ISetCopy
        public BasicRequestData GetCopy()
        {
            return new BasicRequestData(Name, StartIndex, Step);
        }

        public void SetCopy(BasicRequestData source)
        {
            Name = source.Name;
            StartIndex = source.StartIndex;
            Step = source.Step;
        }
        #endregion
    }
}
