using Microsoft.UI.Xaml.Data;
using System;

namespace AniNote2.Base
{
    /// <summary>
    /// Bool inverter for UI bindings
    /// </summary>
    class BoolInverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
