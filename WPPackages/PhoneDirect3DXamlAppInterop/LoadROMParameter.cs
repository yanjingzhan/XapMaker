namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using Windows.Storage;

    [DataContract]
    public class LoadROMParameter
    {
        public StorageFile file { get; set; }

        public StorageFolder folder { get; set; }

        public int LoadState = -1;

        [DataMember]
        public string RomFileName { get; set; }
    }
}

