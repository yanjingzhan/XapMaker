namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct BitmapInfoHeader
    {
        public int HeaderSize;
        public int PixelWidth;
        public int PixelHeight;
        public short ColorPlanes;
        public short BPP;
        public int Compression;
        public int ImageSize;
        public int PPMWidth;
        public int PPMHeight;
        public int ColorsInPalette;
        public int UsedPaletteColors;
        public BitmapInfoHeader(int pixelWidth, int pixelHeight, short bpp)
        {
            this.HeaderSize = 40;
            this.ColorPlanes = 1;
            this.Compression = 0;
            this.ImageSize = 0;
            this.PPMWidth = 0x7d0;
            this.PPMHeight = 0x7d0;
            this.ColorsInPalette = 0;
            this.UsedPaletteColors = 0;
            this.PixelWidth = pixelWidth;
            this.PixelHeight = pixelHeight;
            this.BPP = bpp;
        }
    }
}

