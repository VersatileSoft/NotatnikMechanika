using System;
using System.Globalization;
using System.Windows.Data;

namespace NotatnikMechanika.WPF.Converters
{
    public class FloatToPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is float f ? f * 100 : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
