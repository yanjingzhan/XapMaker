namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Windows.Media;

    public class Bitmap
    {
        public const uint ALPHA_MASK = 0xff000000;
        public const int BI_BITFIELDS = 3;
        public const int BITMAP_HEADER_SIZE = 120;
        public const uint BLUE_MASK = 0xff;
        private BitmapFileHeader fileHeader;
        public const uint GREEN_MASK = 0xff00;
        private byte[] pixels;
        public const uint RED_MASK = 0xff0000;
        private int rowSize;
        private BitmapV4Header v4header;

        public Bitmap(int width, int height, short bpp)
        {
            if ((bpp != 0x18) && (bpp != 0x20))
            {
                throw new ArgumentOutOfRangeException("bpp");
            }
            width = Math.Abs(width);
            height = Math.Abs(height);
            this.rowSize = (int) ((((float) (bpp * width)) / 32f) * 4f);
            this.rowSize += (4 - (this.rowSize % 4)) % 4;
            int num = this.rowSize * height;
            int size = 120 + num;
            this.pixels = new byte[num];
            this.fileHeader = new BitmapFileHeader(size, 120);
            this.v4header = new BitmapV4Header(width, -height, bpp);
        }

        public void Save(IsolatedStorageFileStream fs)
        {
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write((byte) 0x42);
            writer.Write((byte) 0x4d);
            writer.Write(this.fileHeader.SizeInBytes);
            writer.Write(this.fileHeader.Reserved1);
            writer.Write(this.fileHeader.Reserved2);
            writer.Write(this.fileHeader.PixelArrayOffset);
            writer.Write(this.v4header.HeaderSize);
            writer.Write(this.v4header.PixelWidth);
            writer.Write(this.v4header.PixelHeight);
            writer.Write(this.v4header.ColorPlanes);
            writer.Write(this.v4header.BPP);
            writer.Write(this.v4header.Compression);
            writer.Write(this.v4header.ImageSize);
            writer.Write(this.v4header.PPMWidth);
            writer.Write(this.v4header.PPMHeight);
            writer.Write(this.v4header.ColorsInPalette);
            writer.Write(this.v4header.UsedPaletteColors);
            writer.Write(this.v4header.RedMask);
            writer.Write(this.v4header.GreenMask);
            writer.Write(this.v4header.BlueMask);
            writer.Write(this.v4header.AlphaMask);
            writer.Write(this.v4header.CSType);
            for (int i = 0; i < 0x24; i++)
            {
                writer.Write(this.v4header.Endpoints[i]);
            }
            writer.Write(this.v4header.GammaRed);
            writer.Write(this.v4header.GammaGreen);
            writer.Write(this.v4header.GammaBlue);
            for (int j = 0; j < this.pixels.Length; j++)
            {
                writer.Write(this.pixels[j]);
            }
        }

        public void SetColor(int x, int y, Color color)
        {
            int pixelWidth = this.v4header.PixelWidth;
            int num2 = Math.Abs(this.v4header.PixelHeight);
            if ((x < 0) || (x >= pixelWidth))
            {
                throw new ArgumentOutOfRangeException("x");
            }
            if ((y < 0) || (y >= num2))
            {
                throw new ArgumentOutOfRangeException("y");
            }
            int index = (y * this.rowSize) + ((x * this.v4header.BPP) / 8);
            this.pixels[index] = color.B;
            this.pixels[index + 1] = color.G;
            this.pixels[index + 2] = color.R;
            if (this.v4header.BPP == 0x20)
            {
                this.pixels[index + 3] = color.A;
            }
        }
    }
}

