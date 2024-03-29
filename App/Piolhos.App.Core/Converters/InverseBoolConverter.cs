﻿using System;
using Xamarin.Forms;

namespace Piolhos.App.Core.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => !(bool)value;
    }
}
