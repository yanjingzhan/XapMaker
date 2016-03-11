namespace PhoneDirect3DXamlAppInterop
{
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class LastPlayedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime time = (DateTime) value;
            if (time == FileHandler.DEFAULT_DATETIME)
            {
                return AppResources.NeverPlayedText;
            }
            return time.ToString(DateTimeFormatInfo.CurrentInfo.FullDateTimePattern);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

