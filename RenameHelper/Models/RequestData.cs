using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class RequestData : BaseValidationModel, ISetCopy<RequestData>, IGetCopy<RequestData>
    {
        #region Fields
        private string name;
        private int startIndex;
        private int step;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public int StartIndex
        {
            get => startIndex;
            set
            {
                startIndex = value;
                RaisePropertyChanged();
            }
        }

        public int Step
        {
            get => step;
            set
            {
                step = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public RequestData(string name, int startIndex, int counter)
        {
            Name = name;
            StartIndex = startIndex;
            Step = counter;
        }
        #endregion

        #region Implement IGetCopy and ISetCopy
        public RequestData GetCopy()
        {
            return new RequestData(Name, StartIndex, Step);
        }

        public void SetCopy(RequestData source)
        {
            Name = source.Name;
            StartIndex = source.StartIndex;
            Step = source.Step;
        }
        #endregion
    }
}
