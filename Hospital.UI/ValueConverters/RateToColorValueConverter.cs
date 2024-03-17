using System.Globalization;

namespace Hospital.UI.ValueConverters
{
    internal class RateToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if ((double)value > 37.0)
                return Colors.Red;

        return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}