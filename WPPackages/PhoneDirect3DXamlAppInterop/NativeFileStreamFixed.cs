namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.IO;

    public sealed class NativeFileStreamFixed : Stream
    {
        private Stream _stream;

        public NativeFileStreamFixed(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this._stream = stream;
        }

        public override void Flush()
        {
            this._stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this._stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long num = (long)offset;
            long num2 = ((num & 0xffffffffL) << 0x20) | ((num & -4294967296L) >> 0x20);
            return this._stream.Seek((long) num2, origin);
        }

        public override void SetLength(long value)
        {
            this._stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this._stream.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get
            {
                return this._stream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this._stream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return this._stream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return this._stream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this._stream.Position;
            }
            set
            {
                this._stream.Position = value;
            }
        }
    }
}

