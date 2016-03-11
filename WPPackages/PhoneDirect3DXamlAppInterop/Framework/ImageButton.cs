using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class ImageButton : Button
    {
        public readonly static DependencyProperty NormalImageProperty;

        public readonly static DependencyProperty DownFrameProperty;

        public readonly static DependencyProperty DisabledFrameProperty;
        
        public ImageSource DisabledFrame
        {
            get
            {
                return (ImageSource)base.GetValue(ImageButton.DisabledFrameProperty);
            }
            set
            {
                base.SetValue(ImageButton.DisabledFrameProperty, (object)value);
            }
        }

        public ImageSource DownFrame
        {
            get
            {
                return (ImageSource)base.GetValue(ImageButton.DownFrameProperty);
            }
            set
            {
                base.SetValue(ImageButton.DownFrameProperty, (object)value);
            }
        }

        public ImageSource NormalImage
        {
            get
            {
                return (ImageSource)base.GetValue(ImageButton.NormalImageProperty);
            }
            set
            {
                base.SetValue(ImageButton.NormalImageProperty, (object)value);
            }
        }

        static ImageButton()
        {
            ImageButton.NormalImageProperty = DependencyProperty.Register("NormalImage", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(new PropertyChangedCallback(ImageButton.NormalImageChange)));
            ImageButton.DownFrameProperty = DependencyProperty.Register("DownFrame", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));
            ImageButton.DisabledFrameProperty = DependencyProperty.Register("DisabledFrame", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));
        }

        public ImageButton()
        {
            base.DefaultStyleKey = typeof(ImageButton);
            this.RenderTransformOrigin=new Point(0.5,0.5);
            this.MouseLeftButtonUp += ImageButton_MouseLeftButtonUp;
            this.MouseLeftButtonDown += ImageButton_MouseLeftButtonDown;
            
        }

        void ImageButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.RenderTransform = new CompositeTransform() { ScaleX = 0.8, ScaleY = 0.8 };
        }

        void ImageButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.RenderTransform = new CompositeTransform() { ScaleX = 1, ScaleY = 1 };
        }

        public void ChangeImage(string normal, string down)
        {
            this.NormalImage = new BitmapImage(new Uri(normal, UriKind.Relative));
            this.DownFrame = new BitmapImage(new Uri(down, UriKind.Relative));
            this.DisabledFrame = new BitmapImage(new Uri(normal, UriKind.Relative));
        }

        private static void NormalImageChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        //protected override void OnClick()
        //{
        //    this.RenderTransform = new CompositeTransform() { ScaleX = 0.8, ScaleY = 0.8 };
        //    base.OnClick();
        //}

        //protected override void OnTap(GestureEventArgs e)
        //{
        //    this.RenderTransform=new CompositeTransform(){ScaleX = 0.8,ScaleY = 0.8};

        //    base.OnTap(e);
        //}
    }
}
