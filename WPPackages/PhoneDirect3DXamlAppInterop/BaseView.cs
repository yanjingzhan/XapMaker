using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneDirect3DXamlAppInterop.Animation;
using Telerik.Windows.Controls;


namespace PhoneDirect3DXamlAppInterop
{
    public  class BaseView : PhoneApplicationPage
    {
        private bool isShowCompleted;

        public  void Dobusy(Action action)
        {

            new Thread(() => Deployment.Current.Dispatcher.BeginInvoke(action)).Start();
        }



        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

            if (e.NavigationMode == NavigationMode.New && e.Content != null)
            {
                StopAnimation();
            }

            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 0, 1) },
                () =>
                {
                    if (!isShowCompleted)
                    {
                        isShowCompleted = true;
                        ShowPageCompleted();
                    }
                    

                });

            base.OnNavigatedTo(e);
        }

        public virtual void StopAnimation()
        {
            
        }

        public virtual void InitViewData()
        {
            
        }

        public virtual void ShowPageCompleted()
        {
            
        }

        
    }
}