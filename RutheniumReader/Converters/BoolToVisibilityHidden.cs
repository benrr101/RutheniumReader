using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RutheniumReader.Converters
{
    public class BoolToVisibilityHidden : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
            {
                throw new ArgumentException("Can only convert to Visibility types");
            } 

            // Get a boolean from the object that was passed in
            bool boolValue;
            if (value is bool)
            {
                boolValue = (bool) value;
            }
            else
            {
                throw new ArgumentException("Value must be a boolean type");
            }
            return boolValue ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility) value == Visibility.Visible;
        }
    }
}
