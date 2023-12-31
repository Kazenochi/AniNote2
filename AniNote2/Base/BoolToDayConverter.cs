﻿using Microsoft.UI.Xaml.Data;
using System;

namespace AniNote2.Base
{
    internal class BoolToDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string dayOfWeek = ((DayOfWeek)value).ToString();
            if(dayOfWeek == (string)parameter)
                return true;
            else 
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return parameter;
        }
    }
}
