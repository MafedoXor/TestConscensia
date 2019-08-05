using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestConscensia.Common.UI.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool visible)
            {
                if (IsInverted)
                {
                    return visible ? Visibility.Collapsed : Visibility.Visible;
                }

                return visible ? Visibility.Visible : Visibility.Collapsed;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}