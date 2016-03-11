namespace DucLe.Imaging
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public class ControlToPng
    {
        public static byte[] ExtractRGBAfromPremultipliedARGB(int pARGB)
        {
            byte[] buffer = new byte[] { (byte)(pARGB >> 0x18), (byte)((pARGB & 0xff0000) >> 0x10), (byte)((pARGB & 0xff00) >> 8), (byte)(pARGB & 0xff) };
            if (pARGB == 0)
            {
                return buffer;
            }
            byte[] buffer2 = new byte[4];
            if ((buffer[0] == 0) || (buffer[0] == 0xff))
            {
                buffer2[0] = buffer[1];
                buffer2[1] = buffer[2];
                buffer2[2] = buffer[3];
                buffer2[3] = buffer[0];
                return buffer2;
            }
            double num = 255.0 / ((double)buffer[0]);
            double num2 = buffer[1] * num;
            double num3 = buffer[2] * num;
            double num4 = buffer[3] * num;
            buffer2[0] = Convert.ToByte(Math.Min(255.0, num2));
            buffer2[1] = Convert.ToByte(Math.Min(255.0, num3));
            buffer2[2] = Convert.ToByte(Math.Min(255.0, num4));
            buffer2[3] = buffer[0];
            return buffer2;
        }

        private static byte[] ReadFully(Stream stream, int initialLength)
        {
            int num2;
            if (initialLength < 1)
            {
                initialLength = 0x8000;
            }
            byte[] buffer = new byte[initialLength];
            int offset = 0;
            while ((num2 = stream.Read(buffer, offset, buffer.Length - offset)) > 0)
            {
                offset += num2;
                if (offset == buffer.Length)
                {
                    int num3 = stream.ReadByte();
                    if (num3 == -1)
                    {
                        return buffer;
                    }
                    byte[] buffer2 = new byte[buffer.Length * 2];
                    Array.Copy(buffer, buffer2, buffer.Length);
                    buffer2[offset] = (byte)num3;
                    buffer = buffer2;
                    offset++;
                }
            }
            byte[] destinationArray = new byte[offset];
            Array.Copy(buffer, destinationArray, offset);
            return destinationArray;
        }

        public static byte[] RenderAsPNGBytes(UIElement e)
        {
            Stream stream = RenderAsPNGStream(e);
            if (stream == null)
            {
                return null;
            }
            return ReadFully(stream, (int)stream.Length);
        }

        public static Stream RenderAsPNGStream(UIElement e)
        {
            try
            {
                WriteableBitmap bitmap = new WriteableBitmap(e, null);
                EditableImage image = new EditableImage(bitmap.PixelWidth, bitmap.PixelHeight);
                for (int i = 0; i < bitmap.PixelHeight; i++)
                {
                    for (int j = 0; j < bitmap.PixelWidth; j++)
                    {
                        byte[] buffer = ExtractRGBAfromPremultipliedARGB(bitmap.Pixels[(bitmap.PixelWidth * i) + j]);
                        image.SetPixel(j, i, buffer[0], buffer[1], buffer[2], buffer[3]);
                    }
                }
                return image.GetStream();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

