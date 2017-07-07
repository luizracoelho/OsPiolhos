using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Piolhos.App.Core.Converters
{
    public class TelephoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;

            var input = ((string)value).Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            if (input.Length > 11)
                input = input.Substring(0, input.Length - 1);

            var pattern = @"^([0-9]{2})([0-9]{4,5})([0-9]{4})$";
            var replacement = @"($1) $2-$3";
            var rgx = new Regex(pattern);

            return rgx.Replace(input, replacement);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
