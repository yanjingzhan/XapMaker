using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interops;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using PhoneDirect3DXamlAppInterop.Animation;
using PhoneDirect3DXamlAppInterop.Entity;
using PhoneDirect3DXamlAppInterop.Helper;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace PhoneDirect3DXamlAppInterop
{
    public partial class RecommandPage : BaseView
    {


        public RecommandPage()
        {
            InitializeComponent();
            this.BackKeyPress += RecommandPage_BackKeyPress;
            HelloKitty.ShowGoogleFullScreenAd();
            this.Loaded += RecommandPage_Loaded;
        }

        void RecommandPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (base.NavigationService.CanGoBack)
            {
                base.NavigationService.RemoveBackEntry();
            }
            base.OnNavigatedTo(e);
        }

        void RecommandPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
            {
                MainPage.IsNeedToLoad = false;
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

            });
        }




        private void UIElement_OnTap(object sender, GestureEventArgs e)
        {
            AppRecommandEntity entity = CommonHelper.ParseTag<AppRecommandEntity>(sender);
            new MarketplaceDetailTask { ContentIdentifier = entity.ProductID }.Show();

        }
    }
}