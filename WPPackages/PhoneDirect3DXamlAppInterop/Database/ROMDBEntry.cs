namespace PhoneDirect3DXamlAppInterop.Database
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Threading;

    [Table(Name="ROMs")]
    public class ROMDBEntry : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int? autoSaveIndex = 0;
        private string displayName;
        private string fileName;
        public string Header;
        private DateTime lastPlayed;
        private readonly EntitySet<SavestateEntry> savestateRefs = new EntitySet<SavestateEntry>();
        private string snapshotUri;
        public bool SuspendAutoLoadLastState;

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyPropertyChanging(string propertyName)
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        [Column]
        public int? AutoSaveIndex
        {
            get
            {
                return this.autoSaveIndex;
            }
            set
            {
                this.NotifyPropertyChanging("AutoSaveIndex");
                this.autoSaveIndex = value;
                this.NotifyPropertyChanged("AutoSaveIndex");
            }
        }

        [Column(Storage="displayName", CanBeNull=false)]
        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                if (value != this.displayName)
                {
                    this.NotifyPropertyChanging("DisplayName");
                    this.displayName = value;
                    this.NotifyPropertyChanged("DisplayName");
                }
            }
        }

        [Column(Storage="fileName", CanBeNull=false, IsPrimaryKey=true)]
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                if (value != this.fileName)
                {
                    this.NotifyPropertyChanging("FileName");
                    this.fileName = value;
                    this.NotifyPropertyChanged("FileName");
                }
            }
        }

        [Column(Storage="lastPlayed", CanBeNull=false)]
        public DateTime LastPlayed
        {
            get
            {
                return this.lastPlayed;
            }
            set
            {
                if (value != this.lastPlayed)
                {
                    this.NotifyPropertyChanging("LastPlayed");
                    this.lastPlayed = value;
                    this.NotifyPropertyChanged("LastPlayed");
                }
            }
        }

        [Association(Name="FK_ROM_SAVESTATES", Storage="savestateRefs", ThisKey="FileName", OtherKey="ROMFileName")]
        public EntitySet<SavestateEntry> Savestates
        {
            get
            {
                return this.savestateRefs;
            }
        }

        [Column]
        public string SnapshotURI
        {
            get
            {
                return this.snapshotUri;
            }
            set
            {
                this.NotifyPropertyChanging("SnapshotURI");
                this.snapshotUri = value;
                this.NotifyPropertyChanged("SnapshotURI");
            }
        }
    }
}

