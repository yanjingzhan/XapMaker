using System.Windows.Interops;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using PhoneDirect3DXamlAppInterop.Animation;
using PhoneDirect3DXamlAppInterop.Framework;

namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppInterop.Database;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class ManageSavestatePage : BaseView
    {
        private ROMDatabase db;
        private ROMDBEntry romEntry;
        private GridButton deleteGridButton;
        private GridButton loadGridButton;

        public ManageSavestatePage()
        {
            object obj2;
            this.InitializeComponent();

            this.db = ROMDatabase.Current;
            PhoneApplicationService.Current.State.TryGetValue("parameter", out obj2);
            this.romEntry = obj2 as ROMDBEntry;
            PhoneApplicationService.Current.State.Remove("parameter");
            this.CreateAppBar();
            IEnumerable<SavestateEntry> savestatesForROM = this.db.GetSavestatesForROM(this.romEntry);
            this.stateList.ItemsSource = (savestatesForROM);
            this.BackKeyPress += ManageSavestatePage_BackKeyPress;


            //GESprite popbgSprite = new GESprite("/Assets/storepopbg.png");
            //popbgSprite.Width = 480;
            //popbgSprite.Height = 800;
            //PopLayer.AddChild(popbgSprite,0,0,1);

            deleteGridButton = new GridButton("/Assets/storedelet.png");
            deleteGridButton.Width = 250;
            deleteGridButton.Height = 107;
            deleteGridButton.Tap += deleteGridButton_Tap;
            deleteGridButton.RenderTransform = new CompositeTransform();
            deleteGridButton.RenderTransformOrigin = new Point(0.5, 0.5);
            PopLayer.AddChild(deleteGridButton, 108, 300, 2);

            loadGridButton = new GridButton("/Assets/storeload.png");
            loadGridButton.Width = 250;
            loadGridButton.Height = 107;
            loadGridButton.Tap += loadGridButton_Tap;
            loadGridButton.RenderTransform = new CompositeTransform();
            loadGridButton.RenderTransformOrigin = new Point(0.5, 0.5);
            PopLayer.AddChild(loadGridButton, 108, 423, 2);
            HelloKitty.ShowGoogleFullScreenAd();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (base.NavigationService.CanGoBack)
            {
                base.NavigationService.RemoveBackEntry();
            }
            base.OnNavigatedTo(e);
        }

        async void loadGridButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.stateList.SelectedItem != null)
            {
                if (romEntry.SuspendAutoLoadLastState)
                {
                    EmulatorPage.ROMLoaded = false;
                }
                EmulatorPage.currentROMEntry = romEntry;
                LoadROMParameter param = await FileHandler.GetROMFileToPlayAsync(romEntry.FileName);
                param.LoadState = (stateList.SelectedItem as SavestateEntry).Slot;

                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleX(loadGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(loadGridButton, 0.2, 1, 0) },
() =>
{
    PopLayer.Visibility = Visibility.Collapsed;
    PhoneApplicationService.Current.State["parameter"] = param;
    GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
    {
        this.NavigationService.Navigate(new Uri("/EmulatorPage.xaml", UriKind.Relative));
    });
});

            }
            else
            {
                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleX(loadGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(loadGridButton, 0.2, 1, 0) },
() =>
{
    PopLayer.Visibility = Visibility.Collapsed;
});
            }


        }

        async void deleteGridButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleX(loadGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(loadGridButton, 0.2, 1, 0) },
    () =>
    {
        PopLayer.Visibility = Visibility.Collapsed;
    });

            if (this.stateList.SelectedItem == null)
            {
                MessageBox.Show(AppResources.RemoveStateNoSelection, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else if (!await FileHandler.DeleteSaveState(this.stateList.SelectedItem as SavestateEntry))
            {
                MessageBox.Show(AppResources.ManageDeleteUnknownError, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else
            {
                this.stateList.ItemsSource = (null);
                this.stateList.ItemsSource = (this.db.GetSavestatesForROM(this.romEntry));
            }
        }

        void ManageSavestatePage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            if (PopLayer.Visibility == Visibility.Visible)
            {

                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(deleteGridButton, 0.2, 1, 0), GEAnimation.GEScaleX(loadGridButton, 0.2, 1, 0), GEAnimation.GEScaleY(loadGridButton, 0.2, 1, 0) },
                    () =>
                    {
                        PopLayer.Visibility = Visibility.Collapsed;
                    });
                return;
            }

            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
            {
                MainPage.IsNeedToLoad = false;
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

            });
        }

        private void CreateAppBar()
        {
            base.ApplicationBar = (new ApplicationBar());
            base.ApplicationBar.IsVisible = (false);
            base.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
            base.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            ApplicationBarIconButton button2 = new ApplicationBarIconButton(new Uri("/Assets/Icons/delete.png", UriKind.Relative));
            button2.Text = (AppResources.ManageRemoveState);
            ApplicationBarIconButton button = button2;
            button.Click += this.removeButton_Click;
            base.ApplicationBar.Buttons.Add(button);
            ApplicationBar.IsVisible = false;
        }

        private async void removeButton_Click(object sender, EventArgs e)
        {
            if (this.stateList.SelectedItem == null)
            {
                MessageBox.Show(AppResources.RemoveStateNoSelection, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else if (!await FileHandler.DeleteSaveState(this.stateList.SelectedItem as SavestateEntry))
            {
                MessageBox.Show(AppResources.ManageDeleteUnknownError, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else
            {
                this.stateList.ItemsSource = (null);
                this.stateList.ItemsSource = (this.db.GetSavestatesForROM(this.romEntry));
            }
        }

        private async void UIElement_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.stateList.SelectedItem == null)
            {
                MessageBox.Show(AppResources.RemoveStateNoSelection, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else if (!await FileHandler.DeleteSaveState(this.stateList.SelectedItem as SavestateEntry))
            {
                MessageBox.Show(AppResources.ManageDeleteUnknownError, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else
            {
                this.stateList.ItemsSource = (null);
                this.stateList.ItemsSource = (this.db.GetSavestatesForROM(this.romEntry));
            }
        }

        private void StateList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stateList.SelectedItem != null && PopLayer.Visibility == System.Windows.Visibility.Collapsed)
            {
                PopLayer.Visibility = Visibility.Visible;
                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(deleteGridButton, 0.2, 0, 1), GEAnimation.GEScaleY(deleteGridButton, 0.2, 0, 1), GEAnimation.GEScaleX(loadGridButton, 0.2, 0, 1), GEAnimation.GEScaleY(loadGridButton, 0.2, 0, 1) });
            }
        }
    }
}

