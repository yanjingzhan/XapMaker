namespace DucLe.Imaging
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Media;

    public class EditableImage
    {
        private byte[] _buffer;
        private int _height;
        private bool _init;
        private int _rowLength;
        private int _width;

        public event EventHandler<EditableImageErrorEventArgs> ImageError;

        public EditableImage(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public Color GetPixel(int col, int row)
        {
            if ((col > this._width) || (col < 0))
            {
                this.OnImageError("Error: Column must be greater than 0 and less than the Width");
            }
            else if ((row > this._height) || (row < 0))
            {
                this.OnImageError("Error: Row must be greater than 0 and less than the Height");
            }
            Color color = new Color();
            int index = ((this._rowLength * row) + col) + 1;
            color.R = (this._buffer[index]);
            color.G = (this._buffer[index + 1]);
            color.B = (this._buffer[index + 2]);
            color.A = (this._buffer[index + 3]);
            return color;
        }

        public Stream GetStream()
        {
            if (!this._init)
            {
                this.OnImageError("Error: Image has not been initialized");
                return null;
            }
            return PngEncoder.Encode(this._buffer, this._width, this._height);
        }

        private void OnImageError(string msg)
        {
            if (this.ImageError != null)
            {
                EditableImageErrorEventArgs e = new EditableImageErrorEventArgs
                {
                    ErrorMessage = msg
                };
                this.ImageError(this, e);
            }
        }

        public void SetPixel(int col, int row, Color color)
        {
            this.SetPixel(col, row, color.R, color.G, color.B, color.A);
        }

        public void SetPixel(int col, int row, byte red, byte green, byte blue, byte alpha)
        {
            if (!this._init)
            {
                this._rowLength = (this._width * 4) + 1;
                this._buffer = new byte[this._rowLength * this._height];
                for (int i = 0; i < this._height; i++)
                {
                    this._buffer[i * this._rowLength] = 0;
                }
                this._init = true;
            }
            if ((col > this._width) || (col < 0))
            {
                this.OnImageError("Error: Column must be greater than 0 and less than the Width");
            }
            else if ((row > this._height) || (row < 0))
            {
                this.OnImageError("Error: Row must be greater than 0 and less than the Height");
            }
            int index = ((this._rowLength * row) + (col * 4)) + 1;
            this._buffer[index] = red;
            this._buffer[index + 1] = green;
            this._buffer[index + 2] = blue;
            this._buffer[index + 3] = alpha;
        }

        public int Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if (this._init)
                {
                    this.OnImageError("Error: Cannot change Height after the EditableImage has been initialized");
                }
                else if ((value <= 0) || (value > 0x7ff))
                {
                    this.OnImageError("Error: Height must be between 0 and 2047");
                }
                else
                {
                    this._height = value;
                }
            }
        }

        public int Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if (this._init)
                {
                    this.OnImageError("Error: Cannot change Width after the EditableImage has been initialized");
                }
                else if ((value <= 0) || (value > 0x7ff))
                {
                    this.OnImageError("Error: Width must be between 0 and 2047");
                }
                else
                {
                    this._width = value;
                }
            }
        }

        public class EditableImageErrorEventArgs : EventArgs
        {
            private string _errorMessage = string.Empty;

            public string ErrorMessage
            {
                get
                {
                    return this._errorMessage;
                }
                set
                {
                    this._errorMessage = value;
                }
            }
        }
    }
}

