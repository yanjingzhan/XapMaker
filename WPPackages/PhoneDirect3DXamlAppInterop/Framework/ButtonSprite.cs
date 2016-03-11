using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhoneDirect3DXamlAppInterop.Framework;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class ButtonSprite : GEGridSprite
    {
        private string imagePath;
        private string normalImage;
        private string pressImage;
        private List<Rect> imageRects;
        private Action touchAction;
        private TextBlock buttonText=new TextBlock();

        public ButtonSprite(string normalImage, string pressImage, TextBlock text, Action action)
        {
            buttonText = text;
            this.normalImage = normalImage;
            this.pressImage = pressImage;
            touchAction = action;
            this.MouseLeftButtonDown += ButtonSprite_MouseLeftButtonDown;
            this.MouseLeftButtonUp += ButtonSprite_MouseLeftButtonUp;
            SpritImage.Source = new BitmapImage(new Uri(normalImage, UriKind.Relative));
            this.Children.Add(SpritImage);
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            this.Children.Add(text);
        }

        public ButtonSprite(string normalImage, string pressImage, Action action)
        {
            this.normalImage = normalImage;
            this.pressImage = pressImage;
            touchAction = action;
            this.MouseLeftButtonDown += ButtonSprite_MouseLeftButtonDown;
            this.MouseLeftButtonUp += ButtonSprite_MouseLeftButtonUp;
            SpritImage.Source = new BitmapImage(new Uri(normalImage, UriKind.Relative));
            this.Children.Add(SpritImage);
        }

        public ButtonSprite(string imagePath, List<Rect> rects, TextBlock text, Action action)
        {
            buttonText = text;
            this.imagePath = imagePath;
            imageRects = rects;
            touchAction = action;
            this.MouseLeftButtonDown += ButtonSpriteMouseLeftButtonDown;
            this.MouseLeftButtonUp += ButtonSpriteMouseLeftButtonUp;

            Rect imageClip = new Rect(rects[0].X, rects[0].Y, rects[0].Width, rects[0].Height);
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -rects[0].X, Y = -rects[0].Y };
            SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            this.Children.Add(SpritImage);
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.Margin = new Thickness(5, rects[0].Height / 2 - text.ActualHeight / 2-5 , 0, 0);
            this.Children.Add(text);
        }



        public ButtonSprite(string imagePath, List<Rect> rects, Action action)
        {
            this.imagePath = imagePath;
            imageRects = rects;
            touchAction = action;
            this.MouseLeftButtonDown += ButtonSpriteMouseLeftButtonDown;
            this.MouseLeftButtonUp += ButtonSpriteMouseLeftButtonUp;

            Rect imageClip = new Rect(rects[0].X, rects[0].Y, rects[0].Width, rects[0].Height);
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -rects[0].X, Y = -rects[0].Y };
            SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            this.Children.Add(SpritImage);
        }

        void ButtonSprite_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SpritImage.Source = new BitmapImage(new Uri(normalImage, UriKind.Relative));
            if (touchAction != null)
            {
                touchAction.Invoke();
            }
        }

        void ButtonSprite_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (normalImage != pressImage)
            {
                SpritImage.Source = new BitmapImage(new Uri(pressImage, UriKind.Relative));
            }
           
        }

        void ButtonSpriteMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Rect imageClip = new Rect(imageRects[0].X, imageRects[0].Y, imageRects[0].Width, imageRects[0].Height);
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[0].X, Y = -imageRects[0].Y };
            SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            if (touchAction != null)
            {
                touchAction.Invoke();
            }
        }

        void ButtonSpriteMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Rect imageClip = new Rect(imageRects[1].X, imageRects[1].Y, imageRects[1].Width, imageRects[1].Height);
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[1].X, Y = -imageRects[1].Y };
            SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }

        public void SetButtonText(string text)
        {
            buttonText.Text = text;
        }
    }
}
