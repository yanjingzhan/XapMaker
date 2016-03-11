using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class CheckBoxSprite : GEGridSprite
    {
        private string imagePath;
        private string uncheck;
        private bool isCheck;
        private string check;
        private List<Rect> imageRects;
        private Action touchAction;

        private void SetColumn()
        {
            ColumnDefinition columnOne = new ColumnDefinition();
            columnOne.Width = GridLength.Auto;
            this.ColumnDefinitions.Add(columnOne);

            ColumnDefinition columnTwo = new ColumnDefinition();
            columnTwo.Width = GridLength.Auto;
            this.ColumnDefinitions.Add(columnTwo);
        }

        public CheckBoxSprite(string uncheck, string check,bool ischeck,TextBlock text, Action action)
        {
            SetColumn();
            this.uncheck = uncheck;
            this.isCheck = ischeck;
            this.check = check;
            touchAction = action;
            this.MouseLeftButtonDown += CheckBoxSprite_MouseLeftButtonDown;
            SpritImage.Source = new BitmapImage(new Uri(uncheck, UriKind.Relative));
            this.Children.Add(SpritImage);
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            this.Children.Add(text);
            Grid.SetColumn(text, 1);
        }

        public CheckBoxSprite(string uncheck, string check, bool ischeck, Action action)
        {
            this.uncheck = uncheck;
            this.isCheck = ischeck;
            this.check = check;
            touchAction = action;
            this.MouseLeftButtonDown += CheckBoxSprite_MouseLeftButtonDown;
            SpritImage.Source = new BitmapImage(new Uri(uncheck, UriKind.Relative));
            this.Children.Add(SpritImage);
        }

        public CheckBoxSprite(string imagePath, List<Rect> rects, bool ischeck, TextBlock text, Action action)
        {
            SetColumn();
            this.imagePath = imagePath;
            this.isCheck = ischeck;
            imageRects = rects;
            touchAction = action;
            this.MouseLeftButtonDown += CheckBoxSpriteMouseLeftButtonDown;

            if (isCheck)
            {
                Rect imageClip = new Rect(imageRects[1].X, imageRects[1].Y, imageRects[1].Width, imageRects[1].Height);
                SpritImage.Clip = new RectangleGeometry()
                {
                    Rect = imageClip
                };
                SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[1].X, Y = -imageRects[1].Y };
                SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
            else
            {
                Rect imageClip = new Rect(imageRects[0].X, imageRects[0].Y, imageRects[0].Width, imageRects[0].Height);
                SpritImage.Clip = new RectangleGeometry()
                {
                    Rect = imageClip
                };
                SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[0].X, Y = -imageRects[0].Y };
                SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
            this.Children.Add(SpritImage);
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.Margin = new Thickness(5, rects[0].Height / 2 - text.ActualHeight / 2-10, 0, 0);
            this.Children.Add(text);
            Grid.SetColumn(text, 1);
        }

        private double GetTextBlockHeight(string text)
        {
            TextBlock textBlock=new TextBlock(){Text = text};
            return textBlock.ActualHeight;
        }

        public CheckBoxSprite(string imagePath, List<Rect> rects, bool ischeck, Action action)
        {

            this.imagePath = imagePath;
            this.isCheck = ischeck;
            imageRects = rects;
            touchAction = action;
            this.MouseLeftButtonDown += CheckBoxSpriteMouseLeftButtonDown;

            if (isCheck)
            {
                Rect imageClip = new Rect(imageRects[1].X, imageRects[1].Y, imageRects[1].Width, imageRects[1].Height);
                SpritImage.Clip = new RectangleGeometry()
                {
                    Rect = imageClip
                };
                SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[1].X, Y = -imageRects[1].Y };
                SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
            else
            {
                Rect imageClip = new Rect(imageRects[0].X, imageRects[0].Y, imageRects[0].Width, imageRects[0].Height);
                SpritImage.Clip = new RectangleGeometry()
                {
                    Rect = imageClip
                };
                SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[0].X, Y = -imageRects[0].Y };
                SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
            this.Children.Add(SpritImage);
        }



        void CheckBoxSprite_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isCheck = !isCheck;
            if (isCheck)
            {
                SpritImage.Source = new BitmapImage(new Uri(check, UriKind.Relative));
            }
            else
            {
                SpritImage.Source = new BitmapImage(new Uri(uncheck, UriKind.Relative));
            }
            if (touchAction != null)
            {
                touchAction.Invoke();
            }
        }

        void CheckBoxSpriteMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isCheck = !isCheck;
            if (isCheck)
            {
                Rect imageClip = new Rect(imageRects[1].X, imageRects[1].Y, imageRects[1].Width, imageRects[1].Height);
                SpritImage.Clip = new RectangleGeometry()
                {
                    Rect = imageClip
                };
                SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[1].X, Y = -imageRects[1].Y };
                SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
            else
            {
                Rect imageClip = new Rect(imageRects[0].X, imageRects[0].Y, imageRects[0].Width, imageRects[0].Height);
                SpritImage.Clip = new RectangleGeometry()
                {
                    Rect = imageClip
                };
                SpritImage.RenderTransform = new TranslateTransform() { X = -imageRects[0].X, Y = -imageRects[0].Y };
                SpritImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }


            if (touchAction != null)
            {
                touchAction.Invoke();
            }
        }
    }
}
