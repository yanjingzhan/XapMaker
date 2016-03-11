namespace DucLe.Imaging
{
    using System;
    using System.IO;

    public class PngEncoder
    {
        private static byte[] _4BYTEDATA = new byte[4];
        private const int _ADLER32_BASE = 0xfff1;
        private static byte[] _ARGB;
        private static uint[] _crcTable;
        private static bool _crcTableComputed;
        private static byte[] _GAMA = new byte[] { 0x67, 0x41, 0x4d, 0x41 };
        private static byte[] _HEADER = new byte[] { 0x89, 80, 0x4e, 0x47, 13, 10, 0x1a, 10 };
        private static byte[] _IDAT = new byte[] { 0x49, 0x44, 0x41, 0x54 };
        private static byte[] _IEND = new byte[] { 0x49, 0x45, 0x4e, 0x44 };
        private static byte[] _IHDR = new byte[] { 0x49, 0x48, 0x44, 0x52 };
        private const int _MAXBLOCK = 0xffff;

        static PngEncoder()
        {
            byte[] buffer2 = new byte[13];
            buffer2[8] = 8;
            buffer2[9] = 6;
            _ARGB = buffer2;
            _crcTable = new uint[0x100];
            _crcTableComputed = false;
        }

        private static uint ComputeAdler32(byte[] buf)
        {
            uint num = 1;
            uint num2 = 0;
            int length = buf.Length;
            for (int i = 0; i < length; i++)
            {
                num = (num + buf[i]) % 0xfff1;
                num2 = (num2 + num) % 0xfff1;
            }
            return ((num2 << 0x10) + num);
        }

        public static Stream Encode(byte[] data, int width, int height)
        {
            uint num6;
            MemoryStream stream = new MemoryStream();
            stream.Write(_HEADER, 0, _HEADER.Length);
            byte[] bytes = BitConverter.GetBytes(width);
            _ARGB[0] = bytes[3];
            _ARGB[1] = bytes[2];
            _ARGB[2] = bytes[1];
            _ARGB[3] = bytes[0];
            bytes = BitConverter.GetBytes(height);
            _ARGB[4] = bytes[3];
            _ARGB[5] = bytes[2];
            _ARGB[6] = bytes[1];
            _ARGB[7] = bytes[0];
            WriteChunk(stream, _IHDR, _ARGB);
            bytes = BitConverter.GetBytes(0x186a0);
            _4BYTEDATA[0] = bytes[3];
            _4BYTEDATA[1] = bytes[2];
            _4BYTEDATA[2] = bytes[1];
            _4BYTEDATA[3] = bytes[0];
            WriteChunk(stream, _GAMA, _4BYTEDATA);
            uint num = (uint) ((width * 4) + 1);
            uint num2 = (uint) (num * height);
            uint num3 = ComputeAdler32(data);
            MemoryStream stream2 = new MemoryStream();
            uint num4 = 0xffff / num;
            uint num5 = num4 * num;
            uint num8 = num2;
            if ((num2 % num5) == 0)
            {
                num6 = num2 / num5;
            }
            else
            {
                num6 = (num2 / num5) + 1;
            }
            stream2.WriteByte(120);
            stream2.WriteByte(0xda);
            for (uint i = 0; i < num6; i++)
            {
                ushort num7 = (num8 < num5) ? ((ushort) num8) : ((ushort) num5);
                if (num7 == num8)
                {
                    stream2.WriteByte(1);
                }
                else
                {
                    stream2.WriteByte(0);
                }
                stream2.Write(BitConverter.GetBytes(num7), 0, 2);
                stream2.Write(BitConverter.GetBytes(~num7), 0, 2);
                stream2.Write(data, (int) (i * num5), num7);
                num8 -= num5;
            }
            WriteReversedBuffer(stream2, BitConverter.GetBytes(num3));
            stream2.Seek(0L, SeekOrigin.Begin);
            byte[] buffer = new byte[stream2.Length];
            stream2.Read(buffer, 0, (int) stream2.Length);
            WriteChunk(stream, _IDAT, buffer);
            WriteChunk(stream, _IEND, new byte[0]);
            stream.Seek(0L, SeekOrigin.Begin);
            return stream;
        }

        private static uint GetCRC(byte[] buf)
        {
            return (UpdateCRC(uint.MaxValue, buf, buf.Length) ^ uint.MaxValue);
        }

        private static void MakeCRCTable()
        {
            for (int i = 0; i < 0x100; i++)
            {
                uint num = (uint) i;
                for (int j = 0; j < 8; j++)
                {
                    if ((num & 1) > 0)
                    {
                        num = 0xedb88320 ^ (num >> 1);
                    }
                    else
                    {
                        num = num >> 1;
                    }
                }
                _crcTable[i] = num;
            }
            _crcTableComputed = true;
        }

        private static uint UpdateCRC(uint crc, byte[] buf, int len)
        {
            uint num = crc;
            if (!_crcTableComputed)
            {
                MakeCRCTable();
            }
            for (int i = 0; i < len; i++)
            {
                num = _crcTable[(int) ((IntPtr) ((num ^ buf[i]) & 0xff))] ^ (num >> 8);
            }
            return num;
        }

        private static void WriteChunk(Stream stream, byte[] type, byte[] data)
        {
            int num;
            int length = type.Length;
            byte[] buffer = new byte[type.Length + data.Length];
            for (num = 0; num < type.Length; num++)
            {
                buffer[num] = type[num];
            }
            for (num = 0; num < data.Length; num++)
            {
                buffer[num + length] = data[num];
            }
            WriteReversedBuffer(stream, BitConverter.GetBytes(data.Length));
            stream.Write(buffer, 0, buffer.Length);
            WriteReversedBuffer(stream, BitConverter.GetBytes(GetCRC(buffer)));
        }

        private static void WriteReversedBuffer(Stream stream, byte[] data)
        {
            int length = data.Length;
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = data[(length - i) - 1];
            }
            stream.Write(buffer, 0, length);
        }
    }
}

