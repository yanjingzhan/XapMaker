namespace PhoneDirect3DXamlAppInterop
{
    using CropControl;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;


    public partial class ImageCroppingPage : PhoneApplicationPage
    {
        public static WriteableBitmap wbSource;

        public ImageCroppingPage()
        {
            this.InitializeComponent();
            SystemTray.GetProgressIndicator(this).Text = (AppResources.ApplicationTitle2);
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            this.GoBack();
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            WriteableBitmap bmp = this.cropControl.CropImage();
            int height = 0x304;
            if (Application.Current.Host.Content.ScaleFactor == 150)
            {
                height = 0x339;
            }
            bmp = bmp.Resize((int)((((double)bmp.PixelWidth) / ((double)bmp.PixelHeight)) * height), height, WriteableBitmapExtensions.Interpolation.Bilinear);
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string path = "CustomBackground.jpg";
                if (file.FileExists(path))
                {
                    file.DeleteFile(path);
                }
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(path, FileMode.Create, FileAccess.Write, file))
                {
                    System.Windows.Media.Imaging.Extensions.SaveJpeg(bmp, stream, bmp.PixelWidth, bmp.PixelHeight, 0, 100);
                }
            }
            App.metroSettings.BackgroundUri = "CustomBackground.jpg";
            App.metroSettings.UseDefaultBackground = false;
            SettingsPage.shouldUpdateBackgroud = true;
            this.GoBack();
        }

        private void GoBack()
        {
            if (base.NavigationService.CanGoBack)
            {
                base.NavigationService.GoBack();
                wbSource = null;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.cropControl.Source = wbSource;
            base.OnNavigatedTo(e);
        }
    }
}

