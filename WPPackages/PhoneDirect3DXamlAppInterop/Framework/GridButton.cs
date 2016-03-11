using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class GridButton : Grid
    {
        private Image _image = new Image() { };
        public bool IsEnableTapAnimation=true;

        public GridButton(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = (new Uri(imagePath, UriKind.RelativeOrAbsolute));
            this._image.Source = (bitmapImage);
            base.Children.Add(this._image);
            base.RenderTransform=(new CompositeTransform());
            base.RenderTransformOrigin=(new Point(0.5, 0.5));
            this._image.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            this._image.MouseLeave += OnMouseLeave;
            this._image.MouseLeftButtonUp += OnMouseLeftButtonUp;  
        }

        protected void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsEnableTapAnimation)
            {
                CompositeTransform renderTransform = (CompositeTransform)base.RenderTransform;
                renderTransform.ScaleX = (0.85);
                renderTransform.ScaleY = (0.85);
            }
        }

        protected void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (IsEnableTapAnimation)
            {
                CompositeTransform renderTransform = (CompositeTransform)base.RenderTransform;
                renderTransform.ScaleX = (1);
                renderTransform.ScaleY = (1);
            }
        }

        protected void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //GameAudioManageService.Instance.PlaySound("common_click3", 0.7F);
            if (IsEnableTapAnimation)
            {
                CompositeTransform renderTransform = (CompositeTransform)base.RenderTransform;
                renderTransform.ScaleX = (1);
                renderTransform.ScaleY = (1);
            }
        }

        public void ChangeImage(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = (new Uri(imagePath, UriKind.RelativeOrAbsolute));
            this._image.Source = (bitmapImage);
        }
    }
}
