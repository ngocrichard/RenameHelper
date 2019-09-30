using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.Models
{
    public class BasicRequestMode : BaseObservable, IGetCopy<BasicRequestMode>
    {
        #region Properties
        public bool IsRomanNumeral { get; set; }

        public bool KeepCurrentName { get; set; }

        public IndexPlacement IndexMode { get; set; }
        #endregion

        #region Constructor
        public BasicRequestMode(bool isRomanNumeral, bool keepCurrentName, IndexPlacement idxMode)
        {
            IsRomanNumeral = isRomanNumeral;
            KeepCurrentName = keepCurrentName;
            IndexMode = idxMode;
        }
        #endregion

        #region Implement IGetCopy
        public BasicRequestMode GetCopy()
        {
            return new BasicRequestMode(IsRomanNumeral, KeepCurrentName, IndexMode);
        }
        #endregion
    }
}
