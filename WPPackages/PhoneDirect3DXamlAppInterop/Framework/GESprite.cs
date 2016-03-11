using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class GESprite:Canvas
    {
        private Storyboard reverseStoryboard;
        public Storyboard ReverseStoryboard
        {
            get { return reverseStoryboard; }
            set { reverseStoryboard = value; }
        }

        private Point originalPosition = new Point(0, 0);

        public Point OriginalPosition
        {
            get { return originalPosition; }
            set { originalPosition = value; }
        }


        private Point oldPosition;
        public Point OldPosition
        {
            get { return oldPosition; }
            set { OldPosition = value; }
        }

        public Point position;
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public Image SpritImage = new Image();

        public GESprite()
        {
            
        }

        public bool IsVisible
        {
            get {
                return this.Visibility != Visibility.Collapsed;
            }
            set {
                this.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public RoutedEventHandler TouchBegin;

        public GESprite(string imagePath, double x, double y, double width, double height)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Rect imageClip = new Rect(x, y, width, height);
            SpritImage.Source = bitmapImage;
            this.Width = bitmapImage.PixelWidth;
            this.Height = bitmapImage.PixelHeight;
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -x, Y = -y };
            Children.Clear();
            this.Children.Add(SpritImage);
            SetLeft(SpritImage, 0);
            SetTop(SpritImage, 0);
        }

        public GESprite(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            SpritImage.Source = bitmapImage;
            Children.Clear();
            this.Children.Add(SpritImage);
            SetLeft(SpritImage, 0);
            SetTop(SpritImage, 0);

        }

        public  void GESpriteWithFile(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            SpritImage.Source = bitmapImage;
            this.Width = bitmapImage.PixelWidth;
            this.Height = bitmapImage.PixelHeight;
            Children.Clear();
            this.Children.Add(SpritImage);
            SetLeft(SpritImage, 0);
            SetTop(SpritImage, 0);
        }

        public void GESpriteWithFile(string imagePath,double x,double y,double width,double height)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Rect imageClip=new Rect(x,y,width,height);
            this.Width = bitmapImage.PixelWidth;
            this.Height = bitmapImage.PixelHeight;
            SpritImage.Source = bitmapImage;
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -x, Y = -y };
            Children.Clear();
            this.Children.Add(SpritImage);
            SetLeft(SpritImage, 0);
            SetTop(SpritImage, 0);
        }
    }
}
