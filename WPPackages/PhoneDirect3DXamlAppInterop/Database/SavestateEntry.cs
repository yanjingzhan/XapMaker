namespace PhoneDirect3DXamlAppInterop.Database
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Threading;

    [Table]
    public class SavestateEntry : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private string fileName;
        private EntityRef<ROMDBEntry> rom = new EntityRef<ROMDBEntry>();
        private string romFileName;
        private DateTime savetime;
        private int slot;

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

        [Association(Name="FK_ROM_SAVESTATES", Storage="rom", ThisKey="ROMFileName", OtherKey="FileName", IsForeignKey=true)]
        public ROMDBEntry ROM
        {
            get
            {
                return this.rom.Entity;
            }
            set
            {
                ROMDBEntry entry = this.rom.Entity;
                if ((entry != value) || !this.rom.HasLoadedOrAssignedValue)
                {
                    if (entry != null)
                    {
                        this.rom.Entity =(null);
                        entry.Savestates.Remove(this);
                    }
                    this.rom.Entity = (value);
                    if (value != null)
                    {
                        value.Savestates.Add(this);
                        this.romFileName = value.FileName;
                    }
                    else
                    {
                        this.romFileName = null;
                    }
                }
            }
        }

        [Column(IsPrimaryKey=true)]
        public string ROMFileName
        {
            get
            {
                return this.romFileName;
            }
            set
            {
                this.NotifyPropertyChanging("ROMFileName");
                this.romFileName = value;
                this.NotifyPropertyChanged("ROMFileName");
            }
        }

        [Column]
        public DateTime Savetime
        {
            get
            {
                return this.savetime;
            }
            set
            {
                if (value != this.savetime)
                {
                    this.NotifyPropertyChanging("Savetime");
                    this.savetime = value;
                    this.NotifyPropertyChanged("Savetime");
                }
            }
        }

        [Column(IsPrimaryKey=true)]
        public int Slot
        {
            get
            {
                return this.slot;
            }
            set
            {
                if (value != this.slot)
                {
                    this.NotifyPropertyChanging("Slot");
                    this.slot = value;
                    this.NotifyPropertyChanged("Slot");
                }
            }
        }
    }
}

