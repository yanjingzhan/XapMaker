namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return FileHandler.getBitmapImage((string) value, FileHandler.DEFAULT_BACKGROUND_IMAGE);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

