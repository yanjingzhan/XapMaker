
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace PhoneDirect3DXamlAppInterop
{
    public partial class ExProgressBar : UserControl
    {
        public ExProgressBar()
        {
            InitializeComponent();
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value > 100 || value < 0)
                    return;
                this._value = value;
                SetProgressValue();
            }
        }
        private int _value;
        private void SetProgressValue()
        {
            ProgressClip.Rect=new Rect(2,2,(_value / 100d) * 476,22);
            //this.Progress.Width = (_value / 100d) * 476;
            this.txtProgress.Text = (_value) + "";
        }

        private int LargeChange
        {
            get { return 1; }
            set { LargeChange = 1; }
        }

        private int Maximum
        {
            get { return 100; }
            set { Maximum = 100; }
        }

        private int Minimum
        {
            get
            { return 0; }
            set { Minimum = 0; }
        }

        public bool IsIndeterminate
        {
            get { return _indeterminate; }
            set
            {
                _indeterminate = value;
                ChangeIndeterminate();
            }
        }

        private bool _indeterminate;
        private void ChangeIndeterminate()
        {
            if (_indeterminate)
            {
                ProgressClip.Rect = new Rect(2, 2, (_value / 100d) * 476, 22);
                //this.Progress.Width = 476;
                this.Storyboard1.Begin();
                this.txtContainer.Visibility = Visibility.Collapsed;
                this.txtLoading.Visibility = Visibility.Visible;
            }
            else
            {
                ProgressClip.Rect = new Rect(2, 2, (_value / 100d) * 476, 22);
                //this.Progress.Width = _value;
                this.Storyboard1.Stop();
                this.txtContainer.Visibility = Visibility.Visible;
                this.txtLoading.Visibility = Visibility.Collapsed;
            }
        }
    }
}
