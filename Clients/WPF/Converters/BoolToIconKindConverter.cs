using MaterialDesignThemes.Wpf;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NotatnikMechanika.WPF.Converters
{
    public class BoolToIconKindConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value ? PackIconKind.Add : PackIconKind.Remove;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}