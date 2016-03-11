namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class VisibilityConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if ((value != null) && ((bool) value))
                {
                    return (Visibility) 0;
                }
                return (Visibility) 1;
            }
            catch (Exception)
            {
                return (Visibility) 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

