using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RenameHelper.Views.Converters
{
    [ValueConversion(typeof(bool), typeof(IndexPlacement))]
    public class IndexPlacementToBoolean : IValueConverter
    {
        Dictionary<string, IndexPlacement> keyValues;

        public IndexPlacementToBoolean()
        {
            keyValues = new Dictionary<string, IndexPlacement>();
            keyValues.Add("Postfix", IndexPlacement.Postfix);
            keyValues.Add("Prefix", IndexPlacement.Prefix);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = parameter.ToString();
            var mode = (IndexPlacement)value;
            foreach (var pairs in keyValues)
            {
                if (key == pairs.Key && mode == pairs.Value)
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            if (!isChecked)
                return DependencyProperty.UnsetValue;
            return keyValues[parameter.ToString()];
        }
    }
}
