using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class DragLayer : GELayer
    {
        private bool isMouseCapture;
        private Point originalPoint;
        public bool IsCanDrag = true;

        public  DragLayer()
        {
            this.MouseLeftButtonDown += DragableSprite_MouseLeftButtonDown;
            this.MouseLeftButtonUp += DragableSprite_MouseLeftButtonUp;
            this.MouseMove += DragableSprite_MouseMove;
        }

        void DragableSprite_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.isMouseCapture && IsCanDrag)
            {
                Point p = e.GetPosition(null);
                Canvas.SetLeft(this, p.X + Canvas.GetLeft(this) - originalPoint.X);
                Canvas.SetTop(this, p.Y + Canvas.GetTop(this) - originalPoint.Y);
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
    }
}
