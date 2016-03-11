namespace PhoneDirect3DXamlAppInterop
{
    using Coding4Fun.Toolkit.Controls;
    using PhoneDirect3DXamlAppComponent;
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;

    public partial class ColorChooserControl : UserControl
    {

        public ColorChooserControl()
        {
            this.InitializeComponent();
            Color color = new Color();
            color.R = ((byte)EmulatorSettings.Current.BgcolorR);
            color.G = ((byte)EmulatorSettings.Current.BgcolorG);
            color.B = ((byte)EmulatorSettings.Current.BgcolorB);
            color.A = (0xff);
            this.tileColorPicker.Color = color;
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.ClosePopup();
        }

        private void ClosePopup()
        {
            (base.Parent as Popup).IsOpen = (false);
        }


        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            EmulatorSettings.Current.BgcolorR = (this.tileColorPicker.Color.R);
            EmulatorSettings.Current.BgcolorG = (this.tileColorPicker.Color.G);
            EmulatorSettings.Current.BgcolorB = (this.tileColorPicker.Color.B);
            this.ClosePopup();
        }
    }
}

