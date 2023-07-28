using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace AniNote2.Base
{
    /// <summary>
    /// Bool to visibility converter for UI bindings
    /// </summary>
    class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool boolValue = (bool)value;
            boolValue = (parameter != null) ? !boolValue : boolValue;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    class BoolVisibilityInverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool boolValue = (bool)value;
            boolValue = (parameter != null) ? !boolValue : boolValue;
            return boolValue ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }
}
