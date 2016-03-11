using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Interops;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Microsoft.Phone.Tasks;
using PhoneDirect3DXamlAppInterop.Animation;
using PhoneDirect3DXamlAppInterop.Framework;
using PhoneDirect3DXamlAppInterop.Helper;
using Telerik.Windows.Controls;

namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Devices;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Database;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO.IsolatedStorage;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Navigation;


    public partial class EmulatorPage : PhoneApplicationPage
    {
        private ROMDatabase db;
        private bool buyPopupOpened;
        private static LoadROMParameter cache = null;
        private bool confirmPopupOpened;
        public static ROMDBEntry currentROMEntry;
        public static bool IsTombstoned = false;
        private Direct3DBackground m_d3dBackground;
        private string[] menuItemLabels;
        private ApplicationBarMenuItem[] menuItems;
        public Popup popupWindow;
        private bool RestoreSaveStateAfterTombstoned;
        public static bool ROMLoaded = false;
        private bool wasHalfPressed;
        private bool isInitPauseLayer;
        private GELayer menuLayer = new GELayer() { Width = 400, Height = 399 };
        private GELayer storeSelectLayer = new GELayer() { Width = 610, Height = 480 };
        private List<GridButton> storestateButtons = new List<GridButton>();
        private GEGridSprite storeSelectbg;
        private GEGridSprite selecttag;
        private bool isSelectLayerShow;

        private bool isMenuFullAd;
        private HelloKitty helloKitty;
        private bool isShowFullAd;

        public EmulatorPage()
        {
            this.InitializeComponent();
            //OrientationChanged += this.EmulatorPage_OrientationChanged;
            switch (EmulatorSettings.Current.Orientation)
            {
                case 0:
                    base.SupportedOrientations = (SupportedPageOrientation)(3);
                    return;

                case 1:
                    base.SupportedOrientations = (SupportedPageOrientation)(2);
                    return;

                case 2:
                    base.SupportedOrientations = (SupportedPageOrientation)(1);
                    return;
            }

          
        }

        private void CameraButtons_ShutterKeyHalfPressed(object sender, EventArgs e)
        {
            if (this.m_d3dBackground != null)
            {
                this.wasHalfPressed = true;
                if (EmulatorSettings.Current.CameraButtonAssignment == 0)
                {
                    EmulatorSettings.Current.UseTurbo = (true);
                }
                else
                {
                    this.m_d3dBackground.StartCameraPress();
                }
            }
        }

        private void CameraButtons_ShutterKeyPressed(object sender, EventArgs e)
        {
            if (EmulatorSettings.Current.CameraButtonAssignment == 0)
            {
                if (this.m_d3dBackground != null)
                {
                    EmulatorSettings.Current.UseTurbo = (!((bool)IsolatedStorageSettings.ApplicationSettings["UseTurboKey"]));
                    IsolatedStorageSettings.ApplicationSettings["UseTurboKey"] = EmulatorSettings.Current.UseTurbo;
                    this.wasHalfPressed = false;
                }
            }
            else if (EmulatorSettings.Current.FullPressStickABLR)
            {
                if (this.m_d3dBackground != null)
                {
                    if (!this.wasHalfPressed)
                    {
                        this.m_d3dBackground.ToggleCameraPress();
                    }
                    this.wasHalfPressed = false;
                }
            }
            else if (this.m_d3dBackground != null)
            {
                this.m_d3dBackground.StartCameraPress();
                this.wasHalfPressed = false;
            }
        }

        private void CameraButtons_ShutterKeyReleased(object sender, EventArgs e)
        {
            if (this.m_d3dBackground != null)
            {
                if (EmulatorSettings.Current.CameraButtonAssignment == 0)
                {
                    if (this.wasHalfPressed)
                    {
                        EmulatorSettings.Current.UseTurbo = (false);
                    }
                }
                else if (this.wasHalfPressed || !EmulatorSettings.Current.FullPressStickABLR)
                {
                    this.m_d3dBackground.StopCameraPress();
                }
                this.wasHalfPressed = false;
            }
        }

        private void ChangeAppBarVisibility(bool visible)
        {
            base.ApplicationBar.IsVisible = (visible);
            base.ApplicationBar.Mode = (ApplicationBarMode)(0);
            if (visible)
            {
                this.m_d3dBackground.PauseEmulation();
            }
            else
            {
                this.m_d3dBackground.UnpauseEmulation();
            }
        }

        private void cheatBlock_Tap()
        {
            PhoneApplicationService.Current.State["parameter"] = currentROMEntry;
            base.NavigationService.Navigate(new Uri("/CheatPage.xaml", UriKind.Relative));
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            base.ApplicationBar.IsVisible = (false);
            base.NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void ContinueEmulation()
        {
            if (base.ApplicationBar != null)
            {
                base.ApplicationBar.IsVisible = (false);
            }
        }

        private async void DrawingSurfaceBackground_Loaded(object sender, RoutedEventArgs e)
        {

            this.db = ROMDatabase.Current;
            if (this.m_d3dBackground == null)
            {
                this.m_d3dBackground = new Direct3DBackground();
                this.m_d3dBackground.SetContinueNotifier(new ContinueEmulationNotifier(this.ContinueEmulation));
                this.m_d3dBackground.SnapshotAvailable = (new SnapshotCallback(FileHandler.CaptureSnapshot));
                this.m_d3dBackground.SavestateCreated = (ss, ee) => { FileHandler.CreateSavestate(ss,ee); m_d3dBackground.PauseEmulation();};
                this.m_d3dBackground.SavestateSelected = (new SavestateSelectedCallback(this.savestateSelected));
                Direct3DBackground.WrongCheatVersion = (new WrongCheatVersionCallback(this.wrongCheatVersion));
                this.InitAppBar();
                this.m_d3dBackground.WindowBounds =
                    (new Windows.Foundation.Size((double)((float)Application.Current.Host.Content.ActualWidth),
                        (double)((float)Application.Current.Host.Content.ActualHeight)));
                this.m_d3dBackground.NativeResolution =
                    (new Windows.Foundation.Size((double)((float)Math.Floor((double)(((Application.Current.Host.Content.ActualWidth * Application.Current.Host.Content.ScaleFactor) / 100.0) + 0.5))),
                        (double)((float)Math.Floor((double)(((Application.Current.Host.Content.ActualHeight * Application.Current.Host.Content.ScaleFactor) / 100.0) + 0.5)))));
                this.m_d3dBackground.RenderResolution = (this.m_d3dBackground.NativeResolution);
                this.DrawingSurfaceBackground.SetBackgroundContentProvider(this.m_d3dBackground.CreateContentProvider());
                this.DrawingSurfaceBackground.SetBackgroundManipulationHandler(this.m_d3dBackground);
            }
            ROMDatabase current = ROMDatabase.Current;
            if (((cache != null) && (cache.file != null)) && (cache.folder != null))
            {
                if (ROMLoaded && this.m_d3dBackground.LoadadROMFile.Name.Equals(cache.file.Name))
                {
                    ROMDBEntry rOM = current.GetROM(this.m_d3dBackground.LoadadROMFile.Name);
                    List<CheatData> cheats = await FileHandler.LoadCheatCodes(rOM);
                    this.m_d3dBackground.LoadCheats(cheats);
                    if (cache.LoadState != -1)
                    {
                        m_d3dBackground.LoadState(cache.LoadState);
                        
                    }
                }
                else
                {
                    ROMDBEntry re = current.GetROM(cache.file.Name);
                    List<CheatData> cheats = await FileHandler.LoadCheatCodes(re);
                    this.m_d3dBackground.LoadCheatsOnROMLoad(cheats);
                    await this.m_d3dBackground.LoadROMAsync(cache.file, cache.folder);

                    if (cache.LoadState != -1)
                    {
                        m_d3dBackground.LoadState(cache.LoadState);
                    }
                    else
                    {
                        this.RestoreLastSavestate(cache.file.Name);
                    }
                   
                    ROMLoaded = true;
                }
                int asyncVariable0 = 0;
                switch (this.Orientation)
                {
                    case (PageOrientation)1:
                    case (PageOrientation)5:
                        asyncVariable0 = 2;
                        break;

                    case (PageOrientation)2:
                    case (PageOrientation)0x12:
                        asyncVariable0 = 0;
                        break;

                    case (PageOrientation)0x22:
                        asyncVariable0 = 1;
                        break;
                }
                this.m_d3dBackground.ChangeOrientation(asyncVariable0);
            }
            if (this.ApplicationBar != null)
            {
                this.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
                this.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            }

            if (!isInitPauseLayer)
            {
                isInitPauseLayer = true;
                GEGridSprite menubgSprite = new GEGridSprite("/Assets/pausebg.png");
                menubgSprite.Width = 400;
                menubgSprite.Height = 399;
                menuLayer.AddChild(menubgSprite);

                GridButton resumeButton = new GridButton("/Assets/resumegame.png");
                resumeButton.Width = 195;
                resumeButton.Height = 91;
                resumeButton.Tap += (ss, ee) =>
                {
                    if (m_d3dBackground != null)
                    {
                        m_d3dBackground.UnpauseEmulation();
                    }
                    GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0.2, 1, 0), GEAnimation.GEScaleY(menuLayer, 0.2, 1, 0) },
                        () =>
                        {
                            PauseLayer.Visibility = Visibility.Collapsed;

                        });
                };
                menuLayer.AddChild(resumeButton, 100, 63, 2);

                GridButton saveState = new GridButton("/Assets/savestate.png");
                saveState.Width = 195;
                saveState.Height = 91;
                saveState.Tap += (ss, ee) =>
                {
                    GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0.2, 1, 0), GEAnimation.GEScaleY(menuLayer, 0.2, 1, 0) }, () =>
                    {
                        isSelectLayerShow = true;
                        GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(storeSelectLayer, 0.2, 0, 1), GEAnimation.GEScaleY(storeSelectLayer, 0.2, 0, 1) });
                    });
                };
                menuLayer.AddChild(saveState, 100, 166, 2);

                GridButton backMainPage = new GridButton("/Assets/backmenu.png");
                backMainPage.Width = 195;
                backMainPage.Height = 91;
                backMainPage.Tap -= backToMainPageButton_Tap;
                backMainPage.Tap += backToMainPageButton_Tap;
                menuLayer.AddChild(backMainPage, 100, 272, 2);

                PauseLayer.AddChild(menuLayer, 200, 46, 3);

                menuLayer.RenderTransform = new CompositeTransform();
                menuLayer.RenderTransformOrigin = new Point(0.5, 0.5);

                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0, 1, 0), GEAnimation.GEScaleY(menuLayer, 0, 1, 0) });

                storeSelectbg = new GEGridSprite("/Assets/StorePlaces/storeprogressselectbg.png");
                storeSelectbg.Width = 610;
                storeSelectbg.Height = 480;
                storeSelectLayer.AddChild(storeSelectbg);

                var savestatesForROM = this.db.GetSavestatesForROM(currentROMEntry);

                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GridButton stateButton = new GridButton(string.Format("/Assets/StorePlaces/smallEmpty{0}.png", j * 5 + i + 1));
                        stateButton.Tag = j * 5 + i;
                        stateButton.IsEnableTapAnimation = false;
                        stateButton.Width = 101;
                        stateButton.Height = 94;
                        stateButton.Tap -= stateButton_Tap;
                        stateButton.Tap += stateButton_Tap;
                        storeSelectLayer.AddChild(stateButton, 34 + (101 + 9) * i, 133 + (94 + 9) * j, 1);
                        storestateButtons.Add(stateButton);
                    }
                }

                if (savestatesForROM != null)
                {
                    List<SavestateEntry> savestateEntries = savestatesForROM.ToList();

                    for (int i = 0; i < savestateEntries.Count; i++)
                    {
                        for (int j = 0; j < storestateButtons.Count; j++)
                        {
                            if (Int32.Parse(storestateButtons[j].Tag.ToString()) == savestateEntries[i].Slot)
                            {
                                storestateButtons[j].ChangeImage(string.Format("/Assets/StorePlaces/smallUse{0}.png", j + 1));
                                storeSelectLayer.ChangePosition(storestateButtons[j], Canvas.GetLeft(storestateButtons[j]), Canvas.GetTop(storestateButtons[j]));
                            }
                        }
                    }
                }

                selecttag = new GEGridSprite("/Assets/StorePlaces/selectedTag.png");
                selecttag.Width = 101;
                selecttag.Height = 94;
                selecttag.Opacity = 0;
                selecttag.IsHitTestVisible = false;
                storeSelectLayer.AddChild(selecttag, 0, 0, 3);

                if (m_d3dBackground != null && m_d3dBackground.GetCurrentSaveSlot() >= 0 && m_d3dBackground.GetCurrentSaveSlot() <= 9)
                {
                    double tagleft = Canvas.GetLeft(storestateButtons[m_d3dBackground.GetCurrentSaveSlot()]);
                    double tagtop = Canvas.GetTop(storestateButtons[m_d3dBackground.GetCurrentSaveSlot()]);
                    storeSelectLayer.ChangePosition(selecttag, tagleft+5, tagtop+5);
                    selecttag.Opacity = 1;
                }
                GridButton resumeGameButton = new GridButton("/Assets/StorePlaces/resumegame.png");
                resumeGameButton.Width = 157;
                resumeGameButton.Height = 84;
                resumeGameButton.Tap -= resumeGameButton_Tap;
                resumeGameButton.Tap += resumeGameButton_Tap;
                storeSelectLayer.AddChild(resumeGameButton, 40, 365, 1);

                GridButton saveprogressButton = new GridButton("/Assets/StorePlaces/saveprogress.png");
                saveprogressButton.Width = 157;
                saveprogressButton.Height = 84;
                saveprogressButton.Tap += saveprogressButton_Tap;
                storeSelectLayer.AddChild(saveprogressButton, 225, 365, 1);

                GridButton backToMainPageButton = new GridButton("/Assets/StorePlaces/backToMainPage.png");
                backToMainPageButton.Width = 157;
                backToMainPageButton.Height = 84;
                backToMainPageButton.Tap -= backToMainPageButton_Tap;
                backToMainPageButton.Tap += backToMainPageButton_Tap;
                storeSelectLayer.AddChild(backToMainPageButton, 406, 365, 1);

                PauseLayer.AddChild(storeSelectLayer, 100, 0, 2);

                storeSelectLayer.RenderTransform = new CompositeTransform();
                storeSelectLayer.RenderTransformOrigin = new Point(0.5, 0.5);

                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(storeSelectLayer, 0, 1, 0), GEAnimation.GEScaleY(storeSelectLayer, 0, 1, 0) });
            }

            GoogleAdContainer.Children.Clear();

            helloKitty=new HelloKitty() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top };
            GoogleAdContainer.Children.Add(helloKitty);

            //if (!isShowFullAd)
            //{
            //    isShowFullAd = true;

            //}
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New && e.Content != null)
            {

            }

           
            base.OnNavigatedFrom(e);
        }

        void backToMainPageButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            isMenuFullAd = true;
            //if (!GameService.Instance.IsRateGame)
            //{
            //    MessageBoxResult result= MessageBox.Show("Do you love this game and give me 5 stars?","Dear Player",MessageBoxButton.OKCancel);
            //    if (result == MessageBoxResult.OK)
            //    {
            //        GameService.Instance.IsRateGame = true;
            //        new MarketplaceReviewTask().Show();
            //    }
            //}

            DrawingSurfaceBackground.SetBackgroundContentProvider(null);

            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
            {
                MainPage.IsNeedToLoad = false;
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

            });
        }

        void saveprogressButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            isMenuFullAd = true;
            if (this.m_d3dBackground.GetCurrentSaveSlot() == 9)
            {
                MessageBox.Show("No. 10 state item is a auto save item create by game system,which cann’t be written manually.Please choose other item to save.");
                return;
            }
            //else if (EmulatorSettings.Current.HideConfirmationDialogs)
            //{
            //    this.m_d3dBackground.SaveState();
            //}
            //else
            //{
            //    this.ShowSaveDialog();
            //}

            this.m_d3dBackground.SaveState();
            int currentSlot = m_d3dBackground.GetCurrentSaveSlot();

            storestateButtons[currentSlot].ChangeImage(string.Format("/Assets/StorePlaces/smallUse{0}.png", currentSlot + 1));
            storeSelectLayer.ChangePosition(storestateButtons[currentSlot], Canvas.GetLeft(storestateButtons[currentSlot]), Canvas.GetTop(storestateButtons[currentSlot]));
        }

        void resumeGameButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            isMenuFullAd = true;

            isSelectLayerShow = false;
            if (m_d3dBackground != null)
            {
                m_d3dBackground.UnpauseEmulation();
            }
            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(storeSelectLayer, 0.2, 1, 0), GEAnimation.GEScaleY(storeSelectLayer, 0.2, 1, 0) },
                () =>
                {
                    PauseLayer.Visibility = Visibility.Collapsed;

                });
        }

        void stateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (m_d3dBackground != null)
            {
                int state = CommonHelper.ParseTag<int>(sender);
                m_d3dBackground.SelectSaveState(state);
            }
        }

        private void EmulatorPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.m_d3dBackground != null)
            {
                int num = 0;
                switch (e.Orientation)
                {
                    case (PageOrientation)1:
                    case (PageOrientation)5:
                        num = 2;
                        break;

                    case (PageOrientation)2:
                    case (PageOrientation)0x12:
                        num = 0;
                        break;

                    case (PageOrientation)0x22:
                        num = 1;
                        break;
                }
                this.m_d3dBackground.ChangeOrientation(num);
            }
        }

        private void InitAppBar()
        {
            EventHandler handler = null;
            base.ApplicationBar = (new ApplicationBar());
            base.ApplicationBar.IsVisible = (false);
            base.ApplicationBar.IsMenuEnabled = (true);
            base.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
            base.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            ApplicationBarMenuItem item = new ApplicationBarMenuItem(AppResources.ResetROMButton);
            item.Click += ((o, e) => this.resetButton_Click());
            ApplicationBarMenuItem item2 = new ApplicationBarMenuItem(AppResources.CheatMenuItemText);
            item2.Click += ((o, e) => this.cheatBlock_Tap());
            ApplicationBarMenuItem item3 = new ApplicationBarMenuItem(AppResources.SelectState0);
            item3.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(0));
            ApplicationBarMenuItem item4 = new ApplicationBarMenuItem(AppResources.SelectState1);
            item4.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(1));
            ApplicationBarMenuItem item5 = new ApplicationBarMenuItem(AppResources.SelectState2);
            item5.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(2));
            ApplicationBarMenuItem item6 = new ApplicationBarMenuItem(AppResources.SelectState3);
            item6.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(3));
            ApplicationBarMenuItem item7 = new ApplicationBarMenuItem(AppResources.SelectState4);
            item7.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(4));
            ApplicationBarMenuItem item8 = new ApplicationBarMenuItem(AppResources.SelectState5);
            item8.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(5));
            ApplicationBarMenuItem item9 = new ApplicationBarMenuItem(AppResources.SelectState6);
            item9.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(6));
            ApplicationBarMenuItem item10 = new ApplicationBarMenuItem(AppResources.SelectState7);
            item10.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(7));
            ApplicationBarMenuItem item11 = new ApplicationBarMenuItem(AppResources.SelectState8);
            item11.Click += ((o, e) =>
            {
                this.m_d3dBackground.SelectSaveState(8);
            });
            ApplicationBarMenuItem item12 = new ApplicationBarMenuItem(AppResources.SelectStateAuto);
            item12.Click += ((o, e) => this.m_d3dBackground.SelectSaveState(9));
            if (EmulatorSettings.Current.ManualSnapshots)
            {
                ApplicationBarMenuItem item13 = new ApplicationBarMenuItem(AppResources.CreateSnapshotMenuItem);
                if (handler == null)
                {
                    handler = (o, e) => this.m_d3dBackground.TriggerSnapshot();
                }
                item13.Click += (handler);
                this.menuItems = new ApplicationBarMenuItem[] { item, item2, item13, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12 };
                this.menuItemLabels = new string[] { AppResources.ResetROMButton, AppResources.CheatMenuItemText, AppResources.CreateSnapshotMenuItem, AppResources.SelectState0, AppResources.SelectState1, AppResources.SelectState2, AppResources.SelectState3, AppResources.SelectState4, AppResources.SelectState5, AppResources.SelectState6, AppResources.SelectState7, AppResources.SelectState8, AppResources.SelectStateAuto };
            }
            else
            {
                this.menuItems = new ApplicationBarMenuItem[] { item, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12 };
                this.menuItemLabels = new string[] { AppResources.ResetROMButton, AppResources.CheatMenuItemText, AppResources.SelectState0, AppResources.SelectState1, AppResources.SelectState2, AppResources.SelectState3, AppResources.SelectState4, AppResources.SelectState5, AppResources.SelectState6, AppResources.SelectState7, AppResources.SelectState8, AppResources.SelectStateAuto };
            }
            int num = EmulatorSettings.Current.ManualSnapshots ? 3 : 2;
            this.menuItems[this.m_d3dBackground.SelectedSavestateSlot + num].Text = (this.menuItemLabels[this.m_d3dBackground.SelectedSavestateSlot + num] + AppResources.ActiveSavestateText);
            foreach (ApplicationBarMenuItem item14 in this.menuItems)
            {
                base.ApplicationBar.MenuItems.Add(item14);
            }
            ApplicationBarIconButton button5 = new ApplicationBarIconButton(new Uri("/Assets/Icons/open.png", UriKind.Relative));
            button5.Text = (AppResources.LoadStateButton);
            ApplicationBarIconButton button = button5;
            button.Click += (this.loadstateButton_Click);
            base.ApplicationBar.Buttons.Add(button);
            ApplicationBarIconButton button6 = new ApplicationBarIconButton(new Uri("/Assets/Icons/appbar.link.png", UriKind.Relative));
            button6.Text = (AppResources.StartLinkText);
            ApplicationBarIconButton button2 = button6;
            button2.Click += this.linkButton_Click;
            base.ApplicationBar.Buttons.Add(button2);
            ApplicationBarIconButton button7 = new ApplicationBarIconButton(new Uri("/Assets/Icons/save.png", UriKind.Relative));
            button7.Text = (AppResources.SaveStateButton);
            ApplicationBarIconButton button3 = button7;
            button3.Click += (this.savestateButton_Click);
            base.ApplicationBar.Buttons.Add(button3);
            ApplicationBarIconButton button8 = new ApplicationBarIconButton(new Uri("/Assets/Icons/feature.settings.png", UriKind.Relative));
            button8.Text = (AppResources.SettingsButtonText);
            ApplicationBarIconButton button4 = button8;
            button4.Click += (this.configButton_Click);
            base.ApplicationBar.Buttons.Add(button4);
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            base.IsHitTestVisible = (false);
            base.ApplicationBar.IsVisible = (false);
            this.popupWindow = new Popup();
            StartLinkControl.m_d3dBackground = this.m_d3dBackground;
            this.popupWindow.Child = (new StartLinkControl());
            this.popupWindow.VerticalOffset = (0.0);
            this.popupWindow.HorizontalOffset = (0.0);
            this.popupWindow.IsOpen = (true);
            this.popupWindow.Closed += (delegate(object s1, EventArgs e1)
            {
                base.IsHitTestVisible = (true);
                base.ApplicationBar.IsVisible = (true);
            });
        }

        private void loadstateButton_Click(object sender, EventArgs e)
        {
            if (EmulatorSettings.Current.HideLoadConfirmationDialogs)
            {
                this.m_d3dBackground.LoadState(-1);
            }
            else
            {
                this.ShowLoadDialog();
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;

            if (!this.buyPopupOpened && !this.confirmPopupOpened)
            {
                if ((this.m_d3dBackground == null) || !this.m_d3dBackground.IsROMLoaded())
                {
                    e.Cancel = true;
                    return;
                }
                else if ((this.popupWindow != null) && this.popupWindow.IsOpen)
                {
                    this.popupWindow.IsOpen = (false);
                }
                else if (PauseLayer.Visibility == Visibility.Collapsed)
                {
                    PauseLayer.Visibility = Visibility.Visible;
                    GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0.2, 0, 1), GEAnimation.GEScaleY(menuLayer, 0.2, 0, 1) },
                        () =>
                        {
                            if (m_d3dBackground != null)
                            {
                                m_d3dBackground.PauseEmulation();
                            }
                        });
                }
                else if (PauseLayer.Visibility == Visibility.Visible)
                {
                    if (m_d3dBackground != null)
                    {
                        m_d3dBackground.UnpauseEmulation();
                    }
                    
                    if (isSelectLayerShow)
                    {
                        GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0, 0, 0), GEAnimation.GEScaleY(menuLayer, 0, 0, 0), GEAnimation.GEScaleX(storeSelectLayer, 0.2, 1, 0), GEAnimation.GEScaleY(storeSelectLayer, 0.2, 1, 0) },
    () =>
    {
        isSelectLayerShow = false;
        PauseLayer.Visibility = Visibility.Collapsed;

    });
                    }
                    GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0.2, 1, 0), GEAnimation.GEScaleY(menuLayer, 0.2, 1, 0), GEAnimation.GEScaleX(storeSelectLayer, 0, 0, 0), GEAnimation.GEScaleY(storeSelectLayer, 0, 0, 0) },
                        () =>
                        {
                            isSelectLayerShow = false;
                            PauseLayer.Visibility = Visibility.Collapsed;

                        });
                }
                //else if (!ApplicationBar.IsVisible)
                //{
                //    e.Cancel = true;
                //    if (m_d3dBackground != null)
                //    {
                //        m_d3dBackground.PauseEmulation();
                //    }
                //    PauseLayer.Visibility = Visibility.Visible;
                //    GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(menuLayer, 0.2, 0, 1), GEAnimation.GEScaleY(menuLayer, 0.2, 0, 1) });
                //    ChangeAppBarVisibility(true);
                //}
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
      
            PhoneApplicationService.Current.UserIdleDetectionMode = (IdleDetectionMode)(1);
            CameraButtons.ShutterKeyPressed += (this.CameraButtons_ShutterKeyPressed);
            CameraButtons.ShutterKeyHalfPressed += (this.CameraButtons_ShutterKeyHalfPressed);
            CameraButtons.ShutterKeyReleased += this.CameraButtons_ShutterKeyReleased;
            object param = null;
            PhoneApplicationService.Current.State.TryGetValue("parameter", out param);
            LoadROMParameter romInfo = param as LoadROMParameter;
            PhoneApplicationService.Current.State.Remove("parameter");
            ROMDatabase current = ROMDatabase.Current;
            if (romInfo == null)
            {
                if (IsTombstoned)
                {
                    romInfo = (LoadROMParameter)this.State["LoadROMParameter"];
                    romInfo = await FileHandler.GetROMFileToPlayAsync(romInfo.RomFileName);
                    cache = romInfo;
                    currentROMEntry = ROMDatabase.Current.GetROM(romInfo.RomFileName);
                    MainPage.LoadInitialSettings();
                    IsTombstoned = false;
                    this.RestoreSaveStateAfterTombstoned = true;
                }
            }
            else
            {
                cache = romInfo;
            }

            while (base.NavigationService.CanGoBack)
            {
                base.NavigationService.RemoveBackEntry();
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.State["LoadROMParameter"] = cache;

            //PhoneApplicationService.Current.UserIdleDetectionMode = (IdleDetectionMode)(0);
            //try
            //{
            //    CameraButtons.ShutterKeyHalfPressed -= (this.CameraButtons_ShutterKeyHalfPressed);
            //    CameraButtons.ShutterKeyPressed -= (this.CameraButtons_ShutterKeyPressed);
            //    CameraButtons.ShutterKeyReleased -= (this.CameraButtons_ShutterKeyReleased);
            //}
            //catch (Exception)
            //{
            //}
            //if (e.NavigationMode != (NavigationMode)1)
            //{
            //    base.State["LoadROMParameter"] = cache;
            //}
            //if ((this.m_d3dBackground == null) || (this.m_d3dBackground.LoadadROMFile == null))
            //{
            //    base.OnNavigatingFrom(e);
            //}
            //else
            //{
            //    ROMDatabase current = ROMDatabase.Current;
            //    ROMDBEntry rOM = current.GetROM(this.m_d3dBackground.LoadadROMFile.Name);
            //    if (rOM != null)
            //    {
            //        rOM.LastPlayed = DateTime.Now;
            //        current.CommitChanges();
            //        MainPage.shouldRefreshRecentROMList = true;
            //    }
            //    base.OnNavigatingFrom(e);
            //}
        }

        protected override void OnTap(System.Windows.Input.GestureEventArgs e)
        {
            if (base.ApplicationBar.IsVisible)
            {
                base.ApplicationBar.IsVisible = (false);
                this.m_d3dBackground.UnpauseEmulation();
                base.OnTap(e);
            }
        }

        private void resetButton_Click()
        {
            this.m_d3dBackground.Reset();
        }

        private void RestoreLastSavestate(string filename)
        {
            ROMDatabase current = ROMDatabase.Current;
            int lastSavestateSlotByFileNameExceptAuto = current.GetLastSavestateSlotByFileNameExceptAuto(filename);
            this.m_d3dBackground.SelectSaveState(lastSavestateSlotByFileNameExceptAuto);
            if (this.RestoreSaveStateAfterTombstoned)
            {
                this.m_d3dBackground.LoadState(9);
                this.RestoreSaveStateAfterTombstoned = false;
            }
            else if (!currentROMEntry.SuspendAutoLoadLastState)
            {
                if (EmulatorSettings.Current.AutoSaveLoad)
                {
                    lastSavestateSlotByFileNameExceptAuto = current.GetLastSavestateSlotByFileNameIncludingAuto(filename);
                    this.m_d3dBackground.LoadState(lastSavestateSlotByFileNameExceptAuto);
                }
            }
            else
            {
                currentROMEntry.SuspendAutoLoadLastState = false;
            }
        }

        private void savestateButton_Click(object sender, EventArgs e)
        {
            if (this.m_d3dBackground.GetCurrentSaveSlot() == 9)
            {
                MessageBox.Show(AppResources.SaveSlotReservedText);
            }
            else if (EmulatorSettings.Current.HideConfirmationDialogs)
            {
                this.m_d3dBackground.SaveState();
            }
            else
            {
                this.ShowSaveDialog();
            }
        }

        private void savestateSelected(int slot, int oldSlot)
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                int num = EmulatorSettings.Current.ManualSnapshots ? 3 : 2;
                this.menuItems[oldSlot + num].Text = (this.menuItemLabels[oldSlot + num]);
                this.menuItems[slot + num].Text = (this.menuItemLabels[slot + num] + AppResources.ActiveSavestateText);


                if (m_d3dBackground != null && slot >= 0 && slot <= 9)
                {
                    double tagleft = Canvas.GetLeft(storestateButtons[slot]);
                    double tagtop = Canvas.GetTop(storestateButtons[slot]);
                    storeSelectLayer.ChangePosition(selecttag, tagleft+5, tagtop+5);
                    selecttag.Opacity = 1;
                }
            });
        }

        private void ShowLoadDialog()
        {
            if (MessageBox.Show(AppResources.ConfirmLoadText, AppResources.InfoCaption, (MessageBoxButton)1) == (MessageBoxResult)1)
            {
                this.m_d3dBackground.LoadState(80);
            }
        }

        private void ShowSaveDialog()
        {
            if (MessageBox.Show(AppResources.ConfirmSaveText, AppResources.InfoCaption, (MessageBoxButton)1) == (MessageBoxResult)1)
            {
                this.m_d3dBackground.SaveState();
            }
        }

        private void wrongCheatVersion(string code, string cheatRomID, string currentRomID)
        {
            Deployment.Current.Dispatcher.BeginInvoke(
                () => MessageBox.Show(
                    string.Format(AppResources.CheatWrongVersionText, code, cheatRomID, currentRomID),
                    AppResources.CheatWrongVersionTitle, (MessageBoxButton)0));
        }

    }
}

