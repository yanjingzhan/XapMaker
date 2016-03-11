namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct BitmapFileHeader
    {
        public int SizeInBytes;
        public short Reserved1;
        public short Reserved2;
        public int PixelArrayOffset;
        public BitmapFileHeader(int size, int offset)
        {
            this.Reserved1 = 0;
            this.Reserved2 = 0;
            this.SizeInBytes = size;
            this.PixelArrayOffset = offset;
        }
    }
}

