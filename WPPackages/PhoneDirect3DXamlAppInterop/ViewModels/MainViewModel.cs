namespace PhoneDirect3DXamlAppInterop.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    public class MainViewModel
    {
        public ObservableCollection<CheatInfo> DesignCheatInfoList { get; set; }

        public ObservableCollection<CheatText> DesignCheatTextList { get; set; }

        public ObservableCollection<CheatInfo> DesignPartialCheatMatchList { get; set; }

        public ObservableCollection<PhoneDirect3DXamlAppInterop.Database.ROMDBEntry> DesignROMDBEntry { get; set; }

        public string FirstName { get; set; }
    }
}

