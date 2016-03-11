using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class GEGridRect : Grid
    {
        public Rect Rect { get; set; }

        public GEGridRect(Rect rect,Canvas canvas,int zindex)
        {
            this.Rect = rect;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.Opacity = 0;
            Background=new SolidColorBrush(Colors.Black);
            canvas.Children.Add(this);
            Canvas.SetLeft(this,rect.X);
            Canvas.SetTop(this,rect.Y);
            Canvas.SetZIndex(this, zindex);
        }

    }
}
