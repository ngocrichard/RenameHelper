using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class RequestMode : BaseObservable, IGetCopy<RequestMode>
    {
        #region Fields
        private bool isRomanNumeral;
        private bool keepCurrentName;
        private IndexPlacement indexMode;
        #endregion

        #region Properties
        public bool IsRomanNumeral
        {
            get => isRomanNumeral;
            set
            {
                isRomanNumeral = value;
                RaisePropertyChanged();
            }
        }

        public bool KeepCurrentName
        {
            get => keepCurrentName;
            set
            {
                keepCurrentName = value;
                RaisePropertyChanged();
            }
        }

        public IndexPlacement IndexMode
        {
            get => indexMode;
            set
            {
                indexMode = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public RequestMode(bool isRomanNumeral, bool keepCurrentName, IndexPlacement idxMode)
        {
            IsRomanNumeral = isRomanNumeral;
            KeepCurrentName = keepCurrentName;
            IndexMode = idxMode;
        }
        #endregion

        #region Implement IGetCopy
        public RequestMode GetCopy()
        {
            return new RequestMode(IsRomanNumeral, KeepCurrentName, IndexMode);
        }
        #endregion
    }
}
