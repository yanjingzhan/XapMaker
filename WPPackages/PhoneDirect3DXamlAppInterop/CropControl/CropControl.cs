namespace CropControl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public partial class CropControl : UserControl
    {
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(AspectRatios), typeof(CropControl), new PropertyMetadata(AspectRatios.None, new PropertyChangedCallback(RatioChanged)));
        private double biasX;
        private double biasY;
        private Rect bounds;
        private bool isMouseCaptured;
        private Dictionary<AspectRatios, double> mapRatio;
        private Point mousePrevPosition;
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(BitmapSource), typeof(CropControl), new PropertyMetadata(null));

        public CropControl()
        {
            Dictionary<AspectRatios, double> dictionary = new Dictionary<AspectRatios, double>();
            dictionary.Add(AspectRatios.None, 0.0);
            dictionary.Add(AspectRatios.R43, 1.3333333333333333);
            this.mapRatio = dictionary;
            this.InitializeComponent();
        }

        private void CropBottomLeft_MouseMove(object sender, MouseEventArgs e)
        {
            Point correctedPosition = this.GetCorrectedPosition(e.GetPosition(this.Picture));
            if (this.isMouseCaptured)
            {
                if (this.AspectRatio == AspectRatios.None)
                {
                    this.clip.Bottom = Math.Min(Math.Max(this.clip.Top + this.MinimalCropSize, correctedPosition.Y), this.bounds.Bottom);
                    this.clip.Left = Math.Max(Math.Min(this.clip.Right - this.MinimalCropSize, correctedPosition.X), this.bounds.Left);
                }
                else
                {
                    double num = Math.Min(Math.Max(this.clip.Top + this.MinimalCropSize, correctedPosition.Y), this.bounds.Bottom) - this.clip.Bottom;
                    ClipRect clip = this.clip;
                    clip.Bottom += num;
                    double num2 = (-1.0 * num) * this.mapRatio[this.AspectRatio];
                    ClipRect rect2 = this.clip;
                    rect2.Left += num2;
                    if (this.clip.Left < 0.0)
                    {
                        this.clip.Left = this.bounds.Left;
                        double num3 = this.clip.Width / this.mapRatio[this.AspectRatio];
                        this.clip.Bottom = this.clip.Top + num3;
                    }
                }
            }
        }

        private void CropBottomRight_MouseMove(object sender, MouseEventArgs e)
        {
            Point correctedPosition = this.GetCorrectedPosition(e.GetPosition(this.Picture));
            if (this.isMouseCaptured)
            {
                if (this.AspectRatio == AspectRatios.None)
                {
                    this.clip.Bottom = Math.Min(Math.Max(this.clip.Top + this.MinimalCropSize, correctedPosition.Y), this.bounds.Bottom);
                    this.clip.Right = Math.Min(Math.Max(this.clip.Left + this.MinimalCropSize, correctedPosition.X), this.bounds.Right);
                }
                else
                {
                    double num = Math.Min(Math.Max(this.clip.Top + this.MinimalCropSize, correctedPosition.Y), this.bounds.Bottom) - this.clip.Bottom;
                    ClipRect clip = this.clip;
                    clip.Bottom += num;
                    double num2 = num * this.mapRatio[this.AspectRatio];
                    ClipRect rect2 = this.clip;
                    rect2.Right += num2;
                    if (this.clip.Right > this.bounds.Right)
                    {
                        this.clip.Right = this.bounds.Right;
                        double num3 = this.clip.Width / this.mapRatio[this.AspectRatio];
                        this.clip.Bottom = this.clip.Top + num3;
                    }
                }
            }
        }

        public WriteableBitmap CropImage()
        {
            try
            {
                WriteableBitmap source = this.Source as WriteableBitmap;
                int num = source.PixelWidth;
                int length = (int)((this.clip.Width * source.PixelWidth) / this.Picture.Width);
                int num3 = (int)((this.clip.Height * source.PixelHeight) / this.Picture.Height);
                WriteableBitmap bitmap2 = new WriteableBitmap(length, num3);
                for (int i = 0; i <= (num3 - 1); i++)
                {
                    int sourceIndex = ((int)((this.clip.Left * source.PixelWidth) / this.Picture.Width)) + ((((int)((this.clip.Top * source.PixelHeight) / this.Picture.Height)) + i) * num);
                    int destinationIndex = i * length;
                    Array.Copy(source.Pixels, sourceIndex, bitmap2.Pixels, destinationIndex, length);
                }
                return bitmap2;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        private void CropTopLeft_MouseMove(object sender, MouseEventArgs e)
        {
            Point correctedPosition = this.GetCorrectedPosition(e.GetPosition(this.Picture));
            if (this.isMouseCaptured)
            {
                if (this.AspectRatio == AspectRatios.None)
                {
                    this.clip.Top = Math.Max(Math.Min(this.clip.Bottom - this.MinimalCropSize, correctedPosition.Y), this.bounds.Top);
                    this.clip.Left = Math.Max(Math.Min(this.clip.Right - this.MinimalCropSize, correctedPosition.X), this.bounds.Left);
                }
                else
                {
                    double num = Math.Max(Math.Min(this.clip.Bottom - this.MinimalCropSize, correctedPosition.Y), this.bounds.Top) - this.clip.Top;
                    ClipRect clip = this.clip;
                    clip.Top += num;
                    double num2 = num * this.mapRatio[this.AspectRatio];
                    ClipRect rect2 = this.clip;
                    rect2.Left += num2;
                    if (this.clip.Left < 0.0)
                    {
                        this.clip.Left = this.bounds.Left;
                        double num3 = this.clip.Width / this.mapRatio[this.AspectRatio];
                        this.clip.Top = this.clip.Bottom - num3;
                    }
                }
            }
        }

        private void CropTopRight_MouseMove(object sender, MouseEventArgs e)
        {
            Point correctedPosition = this.GetCorrectedPosition(e.GetPosition(this.Picture));
            if (this.isMouseCaptured)
            {
                if (this.AspectRatio == AspectRatios.None)
                {
                    this.clip.Top = Math.Max(Math.Min(this.clip.Bottom - this.MinimalCropSize, correctedPosition.Y), this.bounds.Top);
                    this.clip.Right = Math.Min(Math.Max(this.clip.Left + this.MinimalCropSize, correctedPosition.X), this.bounds.Right);
                }
                else
                {
                    double num = Math.Max(Math.Min(this.clip.Bottom - this.MinimalCropSize, correctedPosition.Y), this.bounds.Top) - this.clip.Top;
                    ClipRect clip = this.clip;
                    clip.Top += num;
                    double num2 = (-1.0 * num) * this.mapRatio[this.AspectRatio];
                    ClipRect rect2 = this.clip;
                    rect2.Right += num2;
                    if (this.clip.Right > this.bounds.Right)
                    {
                        this.clip.Right = this.bounds.Right;
                        double num3 = this.clip.Width / this.mapRatio[this.AspectRatio];
                        this.clip.Top = this.clip.Bottom - num3;
                    }
                }
            }
        }

        private Point GetCorrectedPosition(Point p)
        {
            return new Point(p.X + this.biasX, p.Y + this.biasY);
        }

        public void Init()
        {
            double num = this.Source.PixelWidth - this.MainCanvas.ActualWidth;
            double num2 = this.Source.PixelHeight - this.MainCanvas.ActualHeight;
            double num3 = ((double)this.Source.PixelHeight) / ((double)this.Source.PixelWidth);
            if ((num > 0.0) || (num2 > 0.0))
            {
                if (num > num2)
                {
                    this.Picture.Width = (this.MainCanvas.ActualWidth);
                    this.Picture.Height = (this.MainCanvas.ActualWidth * num3);
                }
                else
                {
                    this.Picture.Height = (this.MainCanvas.ActualHeight);
                    this.Picture.Width = (this.MainCanvas.ActualHeight / num3);
                }
            }
            else
            {
                this.Picture.Width = ((double)this.Source.PixelWidth);
                this.Picture.Height = ((double)this.Source.PixelHeight);
            }
            this.PictureMask.Width = (this.Picture.Width);
            this.PictureMask.Height = (this.Picture.Height);
            double num4 = (this.MainCanvas.ActualWidth - this.Picture.Width) / 2.0;
            double num5 = (this.MainCanvas.ActualHeight - this.Picture.Height) / 2.0;
            Canvas.SetLeft(this.Picture, num4);
            Canvas.SetTop(this.Picture, num5);
            Canvas.SetLeft(this.PictureMask, num4);
            Canvas.SetTop(this.PictureMask, num5);
            this.bounds = new Rect(0.0, 0.0, this.Picture.Width, this.Picture.Height);
            this.clip.ShiftX = num4;
            this.clip.ShiftY = num5;
            this.InitCropPointers();
        }

        private void InitCropPointers()
        {
            this.clip.Reset();
            if (this.AspectRatio == AspectRatios.None)
            {
                this.clip.Left = this.bounds.Left;
                this.clip.Top = this.bounds.Top;
                this.clip.Right = this.bounds.Right;
                this.clip.Bottom = this.bounds.Bottom;
            }
            else if (this.Picture.Height > this.Picture.Width)
            {
                double num = this.Picture.Width / this.mapRatio[this.AspectRatio];
                this.clip.Left = this.bounds.Left;
                this.clip.Top = (this.bounds.Bottom - num) / 2.0;
                this.clip.Right = this.bounds.Right;
                this.clip.Bottom = this.clip.Top + num;
            }
            else if (this.Picture.Height <= this.Picture.Width)
            {
                double num2 = this.Picture.Height * this.mapRatio[this.AspectRatio];
                this.clip.Left = (this.Picture.Width - num2) / 2.0;
                this.clip.Top = this.bounds.Top;
                this.clip.Right = this.clip.Left + num2;
                this.clip.Bottom = this.bounds.Bottom;
            }
        }

        private void MainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.Init();
        }

        private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            this.isMouseCaptured = true;
            image.CaptureMouse();
            this.biasX = (-image.Margin.Left - (image.RenderTransform as TranslateTransform).X) - e.GetPosition(image).X;
            this.biasY = (-image.Margin.Top - (image.RenderTransform as TranslateTransform).Y) - e.GetPosition(image).Y;
        }

        private void MouseButtonUpHandler(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            this.isMouseCaptured = false;
            image.ReleaseMouseCapture();
        }

        private void Picture_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            Point position = e.GetPosition(image);
            if (((position.X > this.clip.Left) && (position.X < this.clip.Right)) && ((position.Y > this.clip.Top) && (position.Y < this.clip.Bottom)))
            {
                image.Cursor = (Cursors.Hand);
            }
        }

        private void Picture_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            Point position = e.GetPosition(image);
            if (((position.X > this.clip.Left) && (position.X < this.clip.Right)) && ((position.Y > this.clip.Top) && (position.Y < this.clip.Bottom)))
            {
                image.Cursor = (Cursors.Arrow);
            }
        }

        private void Picture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (((e.GetPosition(image).X > this.clip.Left) && (e.GetPosition(image).X < this.clip.Right)) && ((e.GetPosition(image).Y > this.clip.Top) && (e.GetPosition(image).Y < this.clip.Bottom)))
            {
                this.isMouseCaptured = true;
                image.CaptureMouse();
                this.mousePrevPosition = e.GetPosition(image);
            }
        }

        private void Picture_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.MouseButtonUpHandler(sender, e);
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMouseCaptured)
            {
                Image image = sender as Image;
                Point point = new Point((this.clip.Center.X + e.GetPosition(image).X) - this.mousePrevPosition.X, (this.clip.Center.Y + e.GetPosition(image).Y) - this.mousePrevPosition.Y);
                if (((point.X > this.clip.Left) && (point.X < this.clip.Right)) && ((point.Y > this.clip.Top) && (point.Y < this.clip.Bottom)))
                {
                    double num5 = this.clip.Width / 2.0;
                    double num6 = this.clip.Height / 2.0;
                    double introduced14 = Math.Max(point.X, this.bounds.Left + num5);
                    double num = Math.Min(introduced14, this.bounds.Right - num5);
                    double introduced15 = Math.Max(point.Y, this.bounds.Top + num6);
                    double num2 = Math.Min(introduced15, this.bounds.Bottom - num6);
                    double num4 = num - this.clip.Center.X;
                    double num3 = num2 - this.clip.Center.Y;
                    ClipRect clip = this.clip;
                    clip.Bottom += num3;
                    ClipRect rect2 = this.clip;
                    rect2.Top += num3;
                    ClipRect rect3 = this.clip;
                    rect3.Left += num4;
                    ClipRect rect4 = this.clip;
                    rect4.Right += num4;
                    this.mousePrevPosition = e.GetPosition(image);
                }
            }
        }

        public static void RatioChanged(DependencyObject o, DependencyPropertyChangedEventArgs dp)
        {
            if (dp.NewValue != null)
            {
                (o as CropControl).InitCropPointers();
            }
        }

        public AspectRatios AspectRatio
        {
            get
            {
                return (AspectRatios)base.GetValue(AspectRatioProperty);
            }
            set
            {
                base.SetValue(AspectRatioProperty, value);
            }
        }

        private ClipRect clip
        {
            get
            {
                return (base.Resources["ClipRect"] as ClipRect);
            }
        }

        public double MinimalCropSize { get; set; }

        public BitmapSource Source
        {
            get
            {
                return (BitmapSource)base.GetValue(SourceProperty);
            }
            set
            {
                base.SetValue(SourceProperty, value);
            }
        }
    }
}

