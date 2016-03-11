namespace PhoneDirect3DXamlAppInterop
{
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class LastPlayedShortConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime time = (DateTime) value;
            if (time == FileHandler.DEFAULT_DATETIME)
            {
                return AppResources.NeverPlayedText;
            }
            return time.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + " " + DateTimeFormatInfo.CurrentInfo.ShortTimePattern);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

