using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class GELayer : Canvas
    {
        public void AddChild(UIElement child,double x,double y,int zindex=0)
        {
            this.Children.Add(child);
            SetLeft(child,x);
            SetTop(child,y);
            SetZIndex(child,zindex);
        }

        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set
            {
                Canvas.SetLeft(this, value);
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

        public void AddChild(UIElement child)
        {
            this.Children.Add(child);
            SetLeft(child, 0);
            SetTop(child, 0);
            SetZIndex(child, 0);
        }

        public void RemoveChild(UIElement child)
        {
            try
            {
                this.Children.Remove(child);
            }
            catch (Exception)
            {
                
            }
        }

        public void ChangePosition(UIElement child,double left, double top)
        {
            Canvas.SetLeft(child,left);
            SetTop(child,top);
        }

    }
}
