namespace CropControl
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class AspectRatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (AspectRatios) Enum.Parse(typeof(AspectRatios), value as string, true);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

