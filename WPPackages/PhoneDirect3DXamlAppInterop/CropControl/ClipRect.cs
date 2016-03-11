namespace CropControl
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows;

    public partial class ClipRect : INotifyPropertyChanged
    {
        private double bottom = double.NaN;
        private double left = double.NaN;
        private double right = double.NaN;
        private double top = double.NaN;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnDependentPropertyCahnged(string name)
        {
            if (this.IsInitialized)
            {
                this.OnPropertyChanged(name);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Reset()
        {
            this.top = double.NaN;
            this.left = double.NaN;
            this.bottom = double.NaN;
            this.right = double.NaN;
        }

        public double Bottom
        {
            get
            {
                if (double.IsNaN(this.bottom))
                {
                    return 0.0;
                }
                return this.bottom;
            }
            set
            {
                this.bottom = value;
                this.OnPropertyChanged("Bottom");
                this.OnDependentPropertyCahnged("Rect");
                this.OnDependentPropertyCahnged("Center");
                this.OnPropertyChanged("BottomShifted");
                this.OnDependentPropertyCahnged("CenterShifted");
            }
        }

        public double BottomShifted
        {
            get
            {
                return (this.ShiftY + this.Bottom);
            }
        }

        public Point Center
        {
            get
            {
                return new Point(this.Left + (this.Width / 2.0), this.Top + (this.Height / 2.0));
            }
        }

        public Point CenterShifted
        {
            get
            {
                return new Point(this.LeftShifted + (this.Width / 2.0), this.TopShifted + (this.Height / 2.0));
            }
        }

        public double Height
        {
            get
            {
                return (this.Bottom - this.Top);
            }
        }

        public bool IsInitialized
        {
            get
            {
                return (((!double.IsNaN(this.left) && !double.IsNaN(this.right)) && !double.IsNaN(this.top)) && !double.IsNaN(this.bottom));
            }
        }

        public double Left
        {
            get
            {
                if (double.IsNaN(this.left))
                {
                    return 0.0;
                }
                return this.left;
            }
            set
            {
                this.left = value;
                this.OnPropertyChanged("Left");
                this.OnDependentPropertyCahnged("Rect");
                this.OnDependentPropertyCahnged("Center");
                this.OnPropertyChanged("LeftShifted");
                this.OnDependentPropertyCahnged("CenterShifted");
            }
        }

        public double LeftShifted
        {
            get
            {
                return (this.ShiftX + this.Left);
            }
        }

        public System.Windows.Rect Rect
        {
            get
            {
                return new System.Windows.Rect(this.Left, this.Top, this.Width, this.Height);
            }
        }

        public double Right
        {
            get
            {
                if (double.IsNaN(this.right))
                {
                    return 0.0;
                }
                return this.right;
            }
            set
            {
                this.right = value;
                this.OnPropertyChanged("Right");
                this.OnDependentPropertyCahnged("Rect");
                this.OnDependentPropertyCahnged("Center");
                this.OnPropertyChanged("RightShifted");
                this.OnDependentPropertyCahnged("CenterShifted");
            }
        }

        public double RightShifted
        {
            get
            {
                return (this.ShiftX + this.Right);
            }
        }

        public double ShiftX { get; set; }

        public double ShiftY { get; set; }

        public double Top
        {
            get
            {
                if (double.IsNaN(this.top))
                {
                    return 0.0;
                }
                return this.top;
            }
            set
            {
                this.top = value;
                this.OnPropertyChanged("Top");
                this.OnDependentPropertyCahnged("Rect");
                this.OnDependentPropertyCahnged("Center");
                this.OnPropertyChanged("TopShifted");
                this.OnDependentPropertyCahnged("CenterShifted");
            }
        }

        public double TopShifted
        {
            get
            {
                return (this.ShiftY + this.Top);
            }
        }

        public double Width
        {
            get
            {
                return (this.Right - this.Left);
            }
        }
    }
}

