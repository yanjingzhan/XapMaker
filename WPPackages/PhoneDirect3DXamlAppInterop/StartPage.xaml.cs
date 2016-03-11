using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneDirect3DXamlAppInterop.Animation;
using PhoneDirect3DXamlAppInterop.Framework;
using PhoneDirect3DXamlAppInterop.Helper;

namespace OnlyThisOne
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
            var background = new GEGridSprite("/Assets/startimage.png");
            GameLayer.AddChild(background, 0, 0, 0);
            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 2, 1, 0,2) },
                () =>
                {
                    CommonHelper.Navigate("/MainPage.xaml");
                });
        }


    }
}