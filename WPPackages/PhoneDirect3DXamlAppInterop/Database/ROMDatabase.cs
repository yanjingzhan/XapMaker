namespace PhoneDirect3DXamlAppInterop.Database
{
    using Microsoft.Phone.Data.Linq;
    using PhoneDirect3DXamlAppInterop;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Linq;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Threading;

    internal class ROMDatabase : IDisposable, INotifyPropertyChanged
    {
        private TrulyObservableCollection<ROMDBEntry> _allROMDBEntries;
        private const string ConnectionString = "isostore:/roms.sdf";
        private ROMDataContext context = new ROMDataContext("isostore:/roms.sdf");
        private bool disposed;
        private static ROMDatabase singleton;

        public event PropertyChangedEventHandler PropertyChanged;

        private ROMDatabase()
        {
        }

        public void Add(ROMDBEntry entry)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            this.context.ROMTable.InsertOnSubmit(entry);
            this.context.SubmitChanges();
            this.AllROMDBEntries.Add(entry);
        }

        public void Add(SavestateEntry entry)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            this.context.SavestateTable.InsertOnSubmit(entry);
            this.context.SubmitChanges();
        }

        public void CommitChanges()
        {
            this.context.SubmitChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public ROMDBEntry GetLastPlayed()
        {
            return (from f in this.context.ROMTable
                    where f.LastPlayed != FileHandler.DEFAULT_DATETIME
                    orderby f.LastPlayed descending
                    select f).FirstOrDefault<ROMDBEntry>();
        }

        public int GetLastSavestateSlotByFileNameExceptAuto(string filename)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            filename = filename.ToLower();
            SavestateEntry entry = (from s in this.context.SavestateTable
                                    where (s.ROMFileName.ToLower().Equals(filename) && (s.Slot != 9)) && (s.Savetime != FileHandler.DEFAULT_DATETIME)
                                    orderby s.Savetime descending
                                    select s).FirstOrDefault<SavestateEntry>();
            if (entry != null)
            {
                return entry.Slot;
            }
            return 0;
        }

        public int GetLastSavestateSlotByFileNameIncludingAuto(string filename)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            filename = filename.ToLower();
            SavestateEntry entry = (from s in this.context.SavestateTable
                                    where s.ROMFileName.ToLower().Equals(filename) && (s.Savetime != FileHandler.DEFAULT_DATETIME)
                                    orderby s.Savetime descending
                                    select s).FirstOrDefault<SavestateEntry>();
            if (entry != null)
            {
                return entry.Slot;
            }
            return 0;
        }

        public string GetLastSnapshot()
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            return (from r in this.context.ROMTable
                    where !r.SnapshotURI.Equals("Assets/no_snapshot_gbc.png") && !r.SnapshotURI.Equals("Assets/no_snapshot.png")
                    orderby r.LastPlayed descending
                    select r.SnapshotURI).FirstOrDefault<string>();
        }

        public int GetNumberOfROMs()
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            return this.context.ROMTable.Count<ROMDBEntry>();
        }

        public IEnumerable<ROMDBEntry> GetRecentlyPlayed()
        {
            return (from f in this.context.ROMTable
                    where f.LastPlayed != FileHandler.DEFAULT_DATETIME
                    orderby f.LastPlayed descending
                    select f).Take<ROMDBEntry>(5).ToArray<ROMDBEntry>();
        }

        public IEnumerable<string> GetRecentSnapshotList()
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            return (from r in
                        (from r in this.context.ROMTable
                         where !r.SnapshotURI.Equals("Assets/no_snapshot_gbc.png") && !r.SnapshotURI.Equals("Assets/no_snapshot.png")
                         orderby r.LastPlayed descending
                         select r).Take<ROMDBEntry>(9)
                    select r.SnapshotURI).ToArray<string>();
        }

        public ROMDBEntry GetROM(string fileName)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            fileName = fileName.ToLower();
            ROMDBEntry entry = (from f in this.context.ROMTable
                                where f.FileName.ToLower().Equals(fileName)
                                select f).FirstOrDefault<ROMDBEntry>();
            if (entry == null)
            {
                foreach (ROMDBEntry entry2 in this.context.ROMTable.ToArray<ROMDBEntry>())
                {
                    if (Regex.Replace(entry2.DisplayName, @"[^\w\s]+", "").ToLower().Equals(fileName))
                    {
                        entry = entry2;
                    }
                }
            }
            return entry;
        }

        public ROMDBEntry GetROMFromSavestateName(string savestateName)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            string name = savestateName.Substring(0, savestateName.Length - 5).ToLower();
            ROMDBEntry entry = (from r in this.context.ROMTable
                                where (r.FileName.ToLower().EndsWith(".gb") && r.FileName.Substring(0, r.FileName.Length - 3).ToLower().Equals(name)) || ((r.FileName.ToLower().EndsWith(".gba") || r.FileName.ToLower().EndsWith(".gbc")) && r.FileName.Substring(0, r.FileName.Length - 4).ToLower().Equals(name))
                                select r).FirstOrDefault<ROMDBEntry>();
            if (entry != null)
            {
                return entry;
            }
            return (from r in this.context.ROMTable
                    where r.DisplayName.ToLower().Equals(name)
                    select r).FirstOrDefault<ROMDBEntry>();
        }

        public ROMDBEntry GetROMFromSRAMName(string savestateName)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            string name = savestateName.Substring(0, savestateName.Length - 4).ToLower();
            ROMDBEntry entry = (from r in this.context.ROMTable
                                where (r.FileName.ToLower().EndsWith(".gb") && r.FileName.Substring(0, r.FileName.Length - 3).ToLower().Equals(name)) || ((r.FileName.ToLower().EndsWith(".gba") || r.FileName.ToLower().EndsWith(".gbc")) && r.FileName.Substring(0, r.FileName.Length - 4).ToLower().Equals(name))
                                select r).FirstOrDefault<ROMDBEntry>();
            if (entry != null)
            {
                return entry;
            }
            return (from r in this.context.ROMTable
                    where r.DisplayName.ToLower().Equals(name)
                    select r).FirstOrDefault<ROMDBEntry>();
        }

        public IEnumerable<ROMDBEntry> GetROMList()
        {
            return (from f in this.context.ROMTable
                    orderby f.DisplayName
                    select f).ToArray<ROMDBEntry>();
        }

        public SavestateEntry GetSavestate(string filename)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            return (from s in this.context.SavestateTable
                    where s.FileName.ToLower().Equals(filename.ToLower())
                    select s).FirstOrDefault<SavestateEntry>();
        }

        public SavestateEntry GetSavestate(string romFilename, int slot)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            romFilename = romFilename.ToLower();
            return (from s in this.context.SavestateTable
                    where s.ROMFileName.ToLower().Equals(romFilename) && (s.Slot == slot)
                    select s).FirstOrDefault<SavestateEntry>();
        }

        public IEnumerable<SavestateEntry> GetSavestatesForROM(ROMDBEntry entry)
        {
            return (from s in this.context.SavestateTable
                    where s.ROM == entry
                    orderby s.Slot
                    select s);
        }

        public bool Initialize()
        {
            bool flag = false;
            if (!this.context.DatabaseExists())
            {
                this.context.CreateDatabase();
                DatabaseSchemaUpdater updater = Microsoft.Phone.Data.Linq.Extensions.CreateDatabaseSchemaUpdater(this.context);
                updater.DatabaseSchemaVersion = (App.APP_VERSION);
                updater.Execute();
                this.context.SubmitChanges();
                flag = true;
            }
            else
            {
                this.UpdateDatabase();
            }
            this.context.SubmitChanges();
            return flag;
        }

        public bool IsDisplayNameUnique(string displayName)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            displayName = displayName.ToLower();
            return ((from r in this.context.ROMTable
                     where r.DisplayName.ToLower().Equals(displayName)
                     select r).Count<ROMDBEntry>() == 0);
        }

        public void LoadCollectionsFromDatabase()
        {
            IQueryable<ROMDBEntry> collection = from entry in this.context.ROMTable.Cast<ROMDBEntry>() select entry;
            this.AllROMDBEntries = new TrulyObservableCollection<ROMDBEntry>(collection);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RemoveROM(string fileName)
        {
            ROMDBEntry entry = this.GetROM(fileName);
            if (entry != null)
            {
                this.context.SavestateTable.DeleteAllOnSubmit<SavestateEntry>((from s in this.context.SavestateTable
                                                                               where s.ROM == entry
                                                                               select s).ToArray<SavestateEntry>());
                this.AllROMDBEntries.Remove(entry);
                this.context.ROMTable.DeleteOnSubmit(entry);
            }
        }

        public bool RemoveSavestateFromDB(SavestateEntry entry)
        {
            try
            {
                entry.ROM.Savestates.Remove(entry);
                this.context.SavestateTable.DeleteOnSubmit(entry);
                this.context.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public SavestateEntry SavestateEntryExisting(string filename, int slot)
        {
            if (!this.context.DatabaseExists())
            {
                throw new InvalidOperationException("Database does not exist.");
            }
            return (from s in this.context.SavestateTable
                    where s.ROMFileName.ToLower().Equals(filename.ToLower())
                    where s.Slot == slot
                    select s).FirstOrDefault<SavestateEntry>();
        }

        private void UpdateDatabase()
        {
            DatabaseSchemaUpdater updater = Microsoft.Phone.Data.Linq.Extensions.CreateDatabaseSchemaUpdater(this.context);
            if (updater.DatabaseSchemaVersion < App.APP_VERSION)
            {
                try
                {
                    if (updater.DatabaseSchemaVersion < 2)
                    {
                        updater.AddColumn<ROMDBEntry>("AutoSaveIndex");
                    }
                    updater.DatabaseSchemaVersion = (App.APP_VERSION);
                    updater.Execute();
                }
                catch (Exception)
                {
                }
            }
        }

        public TrulyObservableCollection<ROMDBEntry> AllROMDBEntries
        {
            get
            {
                return this._allROMDBEntries;
            }
            set
            {
                this._allROMDBEntries = value;
                this.NotifyPropertyChanged("AllROMDBEntries");
            }
        }

        public static ROMDatabase Current
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new ROMDatabase();
                }
                return singleton;
            }
        }

        private class ROMDataContext : DataContext
        {
            public ROMDataContext(string uri)
                : base(uri)
            {
                this.ROMTable = base.GetTable<ROMDBEntry>();
                this.SavestateTable = base.GetTable<SavestateEntry>();
            }

            public Table<ROMDBEntry> ROMTable { get; set; }

            public Table<SavestateEntry> SavestateTable { get; set; }
        }
    }
}

