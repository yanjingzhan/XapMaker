namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class IsoImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                string str = (string) value;
                if (str.Equals("Assets/no_snapshot_gbc.png") || str.Equals("Assets/no_snapshot.png"))
                {
                    return str;
                }
                if (!string.IsNullOrEmpty(str))
                {
                    using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream stream = file.OpenFile(str, FileMode.Open, FileAccess.Read))
                        {
                            image.SetSource(stream);
                        }
                    }
                }
                return image;
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

