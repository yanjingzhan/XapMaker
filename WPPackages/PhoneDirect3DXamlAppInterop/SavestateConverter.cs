namespace PhoneDirect3DXamlAppInterop
{
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class SavestateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int) value;
            string manageSlotLabel = AppResources.ManageSlotLabel;
            if (num < 9)
            {
                return ("State  " + (num + 1).ToString());
            }
            return ("System Auto Save State");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

