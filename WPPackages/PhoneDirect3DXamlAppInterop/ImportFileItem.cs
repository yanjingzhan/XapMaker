namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class ImportFileItem
    {
        public bool Downloading { get; set; }

        public string Name { get; set; }

        public System.IO.Stream Stream { get; set; }

    }
}

