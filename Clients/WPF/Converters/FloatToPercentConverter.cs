using System;
using System.Globalization;
using System.Windows.Data;

namespace NotatnikMechanika.WPF.Converters
{
    public class FloatToPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float f)
                return (int)(f * 100);
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
