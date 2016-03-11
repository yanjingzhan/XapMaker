namespace DucLe.Imaging
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class WriteableBitmapEx
    {
        public static WriteableBitmap CreateTile(WriteableBitmap input, Color tilecolor)
        {
            WriteableBitmap bmp = new WriteableBitmap(input.PixelWidth, input.PixelHeight);
            if (tilecolor.A > 0)
            {
                bmp.Clear(tilecolor);
            }
            bmp.Blit(new Rect(0.0, 0.0, (double)input.PixelWidth, (double)input.PixelHeight), input, new Rect(0.0, 0.0, (double)input.PixelWidth, (double)input.PixelHeight));
            return bmp;
        }

        public static WriteableBitmap CreateTile(WriteableBitmap input, string appname, double fontSize, Thickness margin, HorizontalAlignment halign, VerticalAlignment valign, Color tilecolor, Color bandcolor)
        {
            WriteableBitmap bmp = new WriteableBitmap(input.PixelWidth, input.PixelHeight);
            if (tilecolor.A > 0)
            {
                bmp.Clear(tilecolor);
            }
            if ((appname != null) && (appname != ""))
            {
                WriteableBitmap source = GetTextBitmap(appname, fontSize, Colors.White, 1.0);
                int num = source.PixelWidth;
                int num2 = source.PixelHeight;
                int num3 = 40;
                WriteableBitmap bitmap3 = new WriteableBitmap(input.PixelWidth, num3);
                bitmap3.Clear(bandcolor);
                bmp.Blit(new Rect(0.0, 0.0, (double) input.PixelWidth, (double) num3), bitmap3, new Rect(0.0, 0.0, (double) bitmap3.PixelWidth, (double) bitmap3.PixelHeight));
                bitmap3 = new WriteableBitmap(input.PixelWidth, 1);
                bitmap3.Clear(Colors.White);
                bmp.Blit(new Rect(0.0, (double) num3, (double) input.PixelWidth, 1.0), bitmap3, new Rect(0.0, 0.0, (double) bitmap3.PixelWidth, 1.0));
                Rect destRect = new Rect();
                double num4 = 0.0;
                double num5 = 0.0;
                if (halign ==  (HorizontalAlignment)2)
                {
                    num4 = (input.PixelWidth - num) - margin.Right;
                }
                else if (halign == null)
                {
                    num4 = margin.Left;
                }
                else if (halign == (HorizontalAlignment) 1)
                {
                    num4 = ((double) (input.PixelWidth - num)) / 2.0;
                }
                if (valign == (VerticalAlignment) 2)
                {
                    num5 = (input.PixelHeight - num2) - margin.Bottom;
                }
                else if (valign == null)
                {
                    num5 = margin.Top;
                }
                destRect = new Rect(num4, num5, (double) num, (double) num2);
                bmp.Blit(destRect, source, new Rect(0.0, 0.0, (double) num, (double) num2));
            }
            bmp.Blit(new Rect(0.0, 0.0, (double) input.PixelWidth, (double) input.PixelHeight), input, new Rect(0.0, 0.0, (double) input.PixelWidth, (double) input.PixelHeight));
            return bmp;
        }

        private static WriteableBitmap GetTextBitmap(string text, double fontSize, Color color, double opacity)
        {
            TextBlock block = new TextBlock();
            block.Text = (text);
            block.FontSize = (fontSize);
            block.Foreground = (new SolidColorBrush(color));
            block.Opacity = (opacity);
            WriteableBitmap bitmap = new WriteableBitmap((int)block.ActualWidth, (int)block.ActualHeight);
            bitmap.Render(block, null);
            bitmap.Invalidate();
            return bitmap;
        }
    }
}

