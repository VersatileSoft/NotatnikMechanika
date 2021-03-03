using System;
using System.Globalization;
using System.Windows.Data;

namespace NotatnikMechanika.WPF.Converters
{
    public class DateOffsetConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var startDate = (DateTime)values[0];
            var endDate = (DateTime)values[1];
            return (endDate - startDate).ToString(parameter.ToString());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
