namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct BitmapV4Header
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
        public uint RedMask;
        public uint GreenMask;
        public uint BlueMask;
        public uint AlphaMask;
        public int CSType;
        public byte[] Endpoints;
        public int GammaRed;
        public int GammaGreen;
        public int GammaBlue;
        public BitmapV4Header(int pixelWidth, int pixelHeight, short bpp)
        {
            this.PixelWidth = pixelWidth;
            this.PixelHeight = pixelHeight;
            this.BPP = bpp;
            this.HeaderSize = 0x6c;
            this.ColorPlanes = 1;
            this.Compression = 3;
            this.ImageSize = 0;
            this.PPMWidth = 0xb13;
            this.PPMHeight = 0xb13;
            this.ColorsInPalette = 0;
            this.UsedPaletteColors = 0;
            this.CSType = 0;
            this.RedMask = 0xff0000;
            this.GreenMask = 0xff00;
            this.BlueMask = 0xff;
            this.AlphaMask = 0xff000000;
            this.GammaRed = 0;
            this.GammaGreen = 0;
            this.GammaBlue = 0;
            this.Endpoints = new byte[0x24];
        }
    }
}

