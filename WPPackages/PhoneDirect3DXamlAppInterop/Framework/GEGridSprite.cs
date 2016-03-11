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
    public class GEGridSprite:Grid
    {
        #region drag

        private bool isMouseCapture;
        private Point originalPoint;
        public bool IsCanDrag = true;
        private double minx;
        private double maxx;
        private double miny;
        private double maxy;
        public bool IsFreeDrag;
        public GELayer GameLayer;

        #endregion


        private Point originalPosition=new Point(0,0);

        public Point OriginalPosition
        {
            get { return originalPosition; }
            set { originalPosition = value; }
        }

        public Image SpritImage = new Image(){CacheMode = new BitmapCache()};

        public GEGridSprite()
        {
            
        }

        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set
            {
                Canvas.SetLeft(this,value);
            }
        }

        public double Top
        {
            get { return Canvas.GetTop(this); }
            set
            {
                Canvas.SetTop(this, value);
            }
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

        public GEGridSprite(string imagePath, double x, double y, double width, double height,bool isfreeDrag=true,bool iscandrag=false)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Rect imageClip = new Rect(x, y, width, height);
            SpritImage.Source = bitmapImage;
            //this.Width = bitmapImage.PixelWidth;
            //this.Height = bitmapImage.PixelHeight;
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -x, Y = -y };
            Children.Clear();
            this.Children.Add(SpritImage);
            Canvas.SetLeft(SpritImage, 0);
            Canvas.SetTop(SpritImage, 0);

            IsFreeDrag = isfreeDrag;
            this.IsCanDrag = iscandrag;
            this.MouseLeftButtonDown += DragableSprite_MouseLeftButtonDown;
            this.MouseLeftButtonUp += DragableSprite_MouseLeftButtonUp;
            this.MouseMove += DragableSprite_MouseMove;
        }

        public GEGridSprite(string imagePath, bool isfreeDrag = true, bool iscandrag = false)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            SpritImage.Source = bitmapImage;
            //Children.Clear();
            this.Children.Add(SpritImage);
            Canvas.SetLeft(SpritImage, 0);
            Canvas.SetTop(SpritImage, 0);
            IsFreeDrag = isfreeDrag;
            this.IsCanDrag = iscandrag;
            this.MouseLeftButtonDown += DragableSprite_MouseLeftButtonDown;
            this.MouseLeftButtonUp += DragableSprite_MouseLeftButtonUp;
            this.MouseMove += DragableSprite_MouseMove;
        }

        public void GEGridSpriteWithFile(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            SpritImage.Source = bitmapImage;
            //this.Width = bitmapImage.PixelWidth;
            //this.Height = bitmapImage.PixelHeight;
            Children.Clear();
            this.Children.Add(SpritImage);
            Canvas.SetLeft(SpritImage, 0);
            Canvas.SetTop(SpritImage, 0);
        }

        public void GEGridSpriteWithFile(string imagePath, double x, double y, double width, double height)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Rect imageClip=new Rect(x,y,width,height);
            SpritImage.Source = bitmapImage;
            SpritImage.Clip = new RectangleGeometry()
            {
                Rect = imageClip
            };
            SpritImage.RenderTransform = new TranslateTransform() { X = -x, Y = -y };
            Children.Clear();
            this.Children.Add(SpritImage);
            Canvas.SetLeft(SpritImage, 0);
            Canvas.SetTop(SpritImage, 0);
        }

        void DragableSprite_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.isMouseCapture && IsCanDrag)
            {
                Point p = e.GetPosition(GameLayer);
                if (!IsFreeDrag)
                {
                    double tempx = p.X + Canvas.GetLeft(this) - originalPoint.X;
                    double tempy = p.Y + Canvas.GetTop(this) - originalPoint.Y;

                    if (tempx <= minx)
                    {
                        Canvas.SetLeft(this, minx);
                    }

                    if (tempx >= maxx-this.ActualWidth)
                    {
                        Canvas.SetLeft(this, maxx - this.ActualWidth);
                    }

                    if (tempy <= miny)
                    {
                        Canvas.SetTop(this, miny);
                    }

                    if (tempy >= maxy-this.ActualHeight)
                    {
                        Canvas.SetTop(this, maxy - this.ActualHeight);
                    }
                }
                else
                {
                    Canvas.SetLeft(this, p.X + Canvas.GetLeft(this) - originalPoint.X);
                    Canvas.SetTop(this, p.Y + Canvas.GetTop(this) - originalPoint.Y);
                }

                originalPoint = p;
            }
        }

        void DragableSprite_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ReleaseMouseCapture();
            this.isMouseCapture = false;
        }

        void DragableSprite_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsCanDrag)
            {
                this.CaptureMouse();
                isMouseCapture = true;
                originalPoint = e.GetPosition(null);
            }
        }

        public void SetCanDrag(bool isCanDrag)
        {
            this.IsCanDrag = isCanDrag;
        }

        public void SetDragArea(double minx, double maxx, double miny, double maxy)
        {
            this.minx = minx;
            this.maxx = maxx;
            this.miny = miny;
            this.maxy = maxy;
        }
    }
}
