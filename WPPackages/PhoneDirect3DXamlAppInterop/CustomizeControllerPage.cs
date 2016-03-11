namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppComponent;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO.IsolatedStorage;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using Windows.Foundation;

    public partial class CustomizeControllerPage : PhoneApplicationPage
    {
        private CPositionDirect3DBackground m_d3dBackground = new CPositionDirect3DBackground();
        private int orientation;

        public CustomizeControllerPage()
        {
            this.InitializeComponent();
            base.BackKeyPress += this.CustomizeControllerPage_BackKeyPress;
            this.InitAppBar();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (base.NavigationService.CanGoBack)
            {
                base.NavigationService.GoBack();
            }
        }

        private void CustomizeControllerPage_BackKeyPress(object sender, CancelEventArgs e)
        {
            if (base.ApplicationBar.Mode == (ApplicationBarMode)1)
            {
                e.Cancel = true;
                base.ApplicationBar.Mode = (ApplicationBarMode)(0);
            }
        }

        private void DrawingSurfaceBackground_Loaded(object sender, RoutedEventArgs e)
        {
            this.m_d3dBackground.WindowBounds = (new Windows.Foundation.Size((double)((float)Application.Current.Host.Content.ActualWidth), (double)((float)Application.Current.Host.Content.ActualHeight)));
            this.m_d3dBackground.NativeResolution = (new Windows.Foundation.Size((double)((float)Math.Floor((double)(((Application.Current.Host.Content.ActualWidth * Application.Current.Host.Content.ScaleFactor) / 100.0) + 0.5))), (double)((float)Math.Floor((double)(((Application.Current.Host.Content.ActualHeight * Application.Current.Host.Content.ScaleFactor) / 100.0) + 0.5)))));
            this.m_d3dBackground.RenderResolution = (this.m_d3dBackground.NativeResolution);
            this.DrawingSurfaceBackground.SetBackgroundContentProvider(this.m_d3dBackground.CreateContentProvider());
            this.DrawingSurfaceBackground.SetBackgroundManipulationHandler(this.m_d3dBackground);
            string str = null;
            base.NavigationContext.QueryString.TryGetValue("orientation", out str);
            this.orientation = int.Parse(str);
            if (str != null)
            {
                this.m_d3dBackground.ChangeOrientation(this.orientation);
            }
        }

        public static int[] GetDefaultControllerPosition()
        {
            int num = (int)(((Application.Current.Host.Content.ActualWidth * Application.Current.Host.Content.ScaleFactor) / 100.0) + 0.5);
            int num2 = (int)(((Application.Current.Host.Content.ActualHeight * Application.Current.Host.Content.ScaleFactor) / 100.0) + 0.5);
            return new int[] { 
                ((int) (num * 0.25f)), ((int) (num2 * 0.7f)), ((int) (num * 0.75f)), ((int) (num2 * 0.6f)), ((int) (num * 0.55f)), ((int) (num2 * 0.72f)), ((int) (num * 0.53f)), ((int) (num2 * 0.93f)), ((int) (num * 0.47f)), ((int) (num2 * 0.93f)), 0, ((int) (num2 * 0.87f)), num, ((int) (num2 * 0.87f)), ((int) (num2 * 0.17f)), ((int) (num * 0.75f)), 
                ((int) (num2 * 0.85f)), ((int) (num * 0.45f)), ((int) (num2 * 0.75f)), ((int) (num * 0.7f)), ((int) (num2 * 0.53f)), ((int) (num * 0.9f)), ((int) (num2 * 0.47f)), ((int) (num * 0.9f)), 0, ((int) (num * 0.3f)), num2, ((int) (num * 0.3f))
             };
        }

        private void InitAppBar()
        {
            base.ApplicationBar = (new ApplicationBar());
            base.ApplicationBar.IsVisible = (true);
            base.ApplicationBar.Opacity = (0.3);
            base.ApplicationBar.Mode = (ApplicationBarMode)(1);
            base.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
            base.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            ApplicationBarIconButton button4 = new ApplicationBarIconButton(new Uri("/Assets/Icons/check.png", UriKind.Relative));
            button4.Text = ("ok");
            ApplicationBarIconButton button = button4;
            button.Click += this.okButton_click;
            ApplicationBarIconButton button5 = new ApplicationBarIconButton(new Uri("/Assets/Icons/cancel.png", UriKind.Relative));
            button5.Text = ("cancel");
            ApplicationBarIconButton button2 = button5;
            button2.Click += this.cancelButton_Click;
            ApplicationBarIconButton button6 = new ApplicationBarIconButton(new Uri("/Assets/Icons/refresh.png", UriKind.Relative));
            button6.Text = ("reset");
            ApplicationBarIconButton button3 = button6;
            button3.Click += this.resetButton_Click;
            base.ApplicationBar.Buttons.Add(button);
            base.ApplicationBar.Buttons.Add(button2);
            base.ApplicationBar.Buttons.Add(button3);
        }


        private void okButton_click(object sender, EventArgs e)
        {
            int[] numArray = new int[14];
            this.m_d3dBackground.GetControllerPosition(numArray);
            if (this.orientation == 2)
            {
                EmulatorSettings.Current.PadCenterXP = (numArray[0]);
                EmulatorSettings.Current.PadCenterYP = (numArray[1]);
                EmulatorSettings.Current.ALeftP = (numArray[2]);
                EmulatorSettings.Current.ATopP = (numArray[3]);
                EmulatorSettings.Current.BLeftP = (numArray[4]);
                EmulatorSettings.Current.BTopP = (numArray[5]);
                EmulatorSettings.Current.StartLeftP = (numArray[6]);
                EmulatorSettings.Current.StartTopP = (numArray[7]);
                EmulatorSettings.Current.SelectRightP = (numArray[8]);
                EmulatorSettings.Current.SelectTopP = (numArray[9]);
                EmulatorSettings.Current.LLeftP = (numArray[10]);
                EmulatorSettings.Current.LTopP = (numArray[11]);
                EmulatorSettings.Current.RRightP = (numArray[12]);
                EmulatorSettings.Current.RTopP = (numArray[13]);
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                EmulatorSettings arg_E6_0 = EmulatorSettings.Current;
                settings["PadCenterXPKey"] = (numArray[0]);
                settings["PadCenterYPKey"] = (numArray[1]);
                settings["ALeftPKey"] = (numArray[2]);
                settings["ATopPKey"] = (numArray[3]);
                settings["BLeftPKey"] = (numArray[4]);
                settings["BTopPKey"] = (numArray[5]);
                settings["StartLeftPKey"] = (numArray[6]);
                settings["StartTopPKey"] = (numArray[7]);
                settings["SelectRightPKey"] = (numArray[8]);
                settings["SelectTopPKey"] = (numArray[9]);
                settings["LLeftPKey"] = (numArray[10]);
                settings["LTopPKey"] = (numArray[11]);
                settings["RRightPKey"] = (numArray[12]);
                settings["RTopPKey"] = (numArray[13]);
                settings.Save();
            }
            else
            {
                EmulatorSettings.Current.PadCenterXL=(numArray[0]);
                EmulatorSettings.Current.PadCenterYL=(numArray[1]);
                EmulatorSettings.Current.ALeftL=(numArray[2]);
                EmulatorSettings.Current.ATopL=(numArray[3]);
                EmulatorSettings.Current.BLeftL=(numArray[4]);
                EmulatorSettings.Current.BTopL=(numArray[5]);
                EmulatorSettings.Current.StartLeftL=(numArray[6]);
                EmulatorSettings.Current.StartTopL=(numArray[7]);
                EmulatorSettings.Current.SelectRightL=(numArray[8]);
                EmulatorSettings.Current.SelectTopL=(numArray[9]);
                EmulatorSettings.Current.LLeftL=(numArray[10]);
                EmulatorSettings.Current.LTopL=(numArray[11]);
                EmulatorSettings.Current.RRightL=(numArray[12]);
                EmulatorSettings.Current.RTopL=(numArray[13]);
                IsolatedStorageSettings settings2 = IsolatedStorageSettings.ApplicationSettings;
                EmulatorSettings arg_2C7_0 = EmulatorSettings.Current;
                settings2["PadCenterXLKey"] = ( numArray[0]);
                settings2["PadCenterYLKey"] = ( numArray[1]);
                settings2["ALeftLKey"] = ( numArray[2]);
                settings2["ATopLKey"] = ( numArray[3]);
                settings2["BLeftLKey"] = ( numArray[4]);
                settings2["BTopLKey"] = ( numArray[5]);
                settings2["StartLeftLKey"] = ( numArray[6]);
                settings2["StartTopLKey"] = ( numArray[7]);
                settings2["SelectRightLKey"] = ( numArray[8]);
                settings2["SelectTopLKey"] = ( numArray[9]);
                settings2["LLeftLKey"] = ( numArray[10]);
                settings2["LTopLKey"] = ( numArray[11]);
                settings2["RRightLKey"] = ( numArray[12]);
                settings2["RTopLKey"] = ( numArray[13]);
                settings2.Save();
            }
            if (base.NavigationService.CanGoBack)
            {
                base.NavigationService.GoBack();
            }
        }

        protected override void OnTap(System.Windows.Input.GestureEventArgs e)
        {
            if (base.ApplicationBar.Mode != (ApplicationBarMode)1)
            {
                base.ApplicationBar.Mode = (ApplicationBarMode)(1);
            }
            base.OnTap(e);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //int[] defaultControllerPosition = GetDefaultControllerPosition();
            //if (this.orientation == 2)
            //{
            //    this.m_d3dBackground.SetControllerPosition(defaultControllerPosition.Slice<int>(0, 14));
            //}
            //else
            //{
            //    this.m_d3dBackground.SetControllerPosition(defaultControllerPosition.Slice<int>(14, 0x1c));
            //}
        }
    }
}

