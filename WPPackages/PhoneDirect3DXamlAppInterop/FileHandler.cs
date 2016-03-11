namespace PhoneDirect3DXamlAppInterop
{
    using DucLe.Imaging;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Database;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Resources;
    using Windows.Foundation;
    using Windows.Phone.Storage.SharedAccess;
    using Windows.Storage;
    using Windows.Storage.Streams;

    internal partial class FileHandler
    {
        public static string CUSTOM_TILE_FILENAME = "myCustomTile1.png";
        public static string DEFAULT_BACKGROUND_IMAGE = "Assets/GameboyAdvance.jpg";
        public static DateTime DEFAULT_DATETIME = new DateTime(0x7c5, 2, 0x16);
        public const string DEFAULT_SNAPSHOT = "Assets/no_snapshot_gbc.png";
        public const string DEFAULT_SNAPSHOT_ALT = "Assets/no_snapshot.png";
        public const string ROM_DIRECTORY = "roms";
        public const string ROM_URI_STRING = "rom";
        public const string SAVE_DIRECTORY = "saves";

        private static void captureSnapshot(byte[] pixeldata, int pitch, string filename)
        {
            int width = pitch / 4;
            int height = pixeldata.Length / pitch;
            Bitmap bitmap = new Bitmap(width, height, 0x18);
            int x = 0;
            int y = 0;
            for (int i = 0; i < (pitch * height); i += 4)
            {
                byte num6 = pixeldata[i];
                byte num7 = pixeldata[i + 1];
                byte num8 = pixeldata[i + 2];
                Color color = Color.FromArgb(0xff, num6, num7, num8);
                bitmap.SetColor(x, y, color);
                x++;
                if (x >= width)
                {
                    y++;
                    x = 0;
                }
            }
            int num9 = filename.LastIndexOf('.');
            int num10 = (filename.Length - 1) - num9;
            string str = filename.Substring(0, filename.Length - num10) + "bmp";
            try
            {
                IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("/Shared/ShellContent/" + str, FileMode.Create, userStoreForApplication))
                {
                    bitmap.Save(stream);
                    stream.Flush(true);
                }
                ROMDatabase current = ROMDatabase.Current;
                current.GetROM(filename).SnapshotURI = "Shared/ShellContent/" + str;
                current.CommitChanges();
                //UpdateLiveTile();
                CreateOrUpdateSecondaryTile(false);
                //UpdateROMTile(filename);
            }
            catch (Exception)
            {
            }
        }

        public static void CaptureSnapshot(byte[] pixeldata, int pitch, string filename)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => captureSnapshot(pixeldata, pitch, filename));
        }

        private static Uri CreateAndSavePNGToIsolatedStorage(Uri logo, Color tileColor)
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Shared/ShellContent/" + CUSTOM_TILE_FILENAME, FileMode.Create, file))
                {
                    using (Stream stream2 = RenderAsPNGStream(logo, tileColor))
                    {
                        stream2.CopyTo(stream);
                    }
                }
            }
            return new Uri("isostore:/Shared/ShellContent/" + CUSTOM_TILE_FILENAME, UriKind.Absolute);
        }

        private static FlipTileData CreateFlipTileData(ROMDBEntry re)
        {
            FlipTileData data = new FlipTileData();
            data.Title = (re.DisplayName);
            if (re.SnapshotURI.Equals("Assets/no_snapshot_gbc.png") || re.SnapshotURI.Equals("Assets/no_snapshot.png"))
            {
                data.SmallBackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileSmallGBC.png", UriKind.Relative));
                data.BackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileMediumGBC.png", UriKind.Relative));
                data.WideBackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileLargeGBC.png", UriKind.Relative));
                return data;
            }
            data.SmallBackgroundImage = (new Uri("isostore:/" + re.SnapshotURI, UriKind.Absolute));
            data.BackgroundImage = (new Uri("isostore:/" + re.SnapshotURI, UriKind.Absolute));
            data.WideBackgroundImage = (new Uri("isostore:/" + re.SnapshotURI, UriKind.Absolute));
            return data;
        }

        public async static Task CreateInitialFolderStructure()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.CreateFolderAsync("roms", (CreationCollisionOption)3);
            await romFolder.CreateFolderAsync("saves",(CreationCollisionOption) 3);
        }

        public static void CreateOrUpdateSecondaryTile(bool forceCreate)
        {
            CycleTileData data = new CycleTileData();
            data.Title = (AppResources.ApplicationTitle2);
            IEnumerable<string> recentSnapshotList = ROMDatabase.Current.GetRecentSnapshotList();
            List<Uri> list = new List<Uri>();
            if (recentSnapshotList.Count<string>() == 0)
            {
                list.Add(new Uri("Assets/Tiles/FlipCycleTileLargeGBC.png", UriKind.Relative));
            }
            else
            {
                foreach (string str in recentSnapshotList)
                {
                    list.Add(new Uri("isostore:/" + str, UriKind.Absolute));
                }
            }
            data.CycleImages = (list);
            data.SmallBackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileSmallGBC.png", UriKind.Relative));
            bool flag = false;
            foreach (ShellTile tile in ShellTile.ActiveTiles)
            {
                if (!(tile.NavigationUri.OriginalString == "/") && (tile.NavigationUri.OriginalString.LastIndexOf('=') < 0))
                {
                    flag = true;
                    tile.Update(data);
                    if (forceCreate)
                    {
                        MessageBox.Show(AppResources.TileAlreadyPinnedText);
                    }
                    break;
                }
            }
            if (!flag && forceCreate)
            {
                ShellTile.Create(new Uri("/MainPage.xaml", UriKind.Relative), data, true);
            }
        }

        //public static void CreateROMTile(ROMDBEntry re)
        //{
        //    FlipTileData data = CreateFlipTileData(re);
        //    ShellTile.Create(new Uri("/MainPage.xaml?rom=" + re.FileName, UriKind.Relative), data, true);
        //}

        private static void createSavestate(int slot, string romFileName)
        {
            ROMDatabase current = ROMDatabase.Current;
            int num = romFileName.LastIndexOf('.');
            int num2 = romFileName.Length - num;
            string str = romFileName.Substring(0, romFileName.Length - num2) + ((string)slot.ToString()) + ".sgm";
            SavestateEntry savestate = current.GetSavestate(romFileName, slot);
            if (savestate == null)
            {
                ROMDBEntry rOM = current.GetROM(romFileName);
                savestate = new SavestateEntry
                {
                    ROM = rOM,
                    FileName = str,
                    ROMFileName = romFileName,
                    Savetime = DateTime.Now,
                    Slot = slot
                };
                current.Add(savestate);
            }
            else
            {
                savestate.Savetime = DateTime.Now;
            }
            current.CommitChanges();
        }

        public static void CreateSavestate(int slot, string romFileName)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                createSavestate(slot, romFileName);
                
            });
        }

        public async static Task DeleteROMAsync(ROMDBEntry rom)
        {
            string fileName = rom.FileName;
            StorageFolder asyncVariable0 = await ApplicationData.Current.LocalFolder.GetFolderAsync("roms");
            StorageFile asyncVariable1 = await asyncVariable0.GetFileAsync(fileName);
            DeleteROMTile(asyncVariable1.Name);
            await asyncVariable1.DeleteAsync((StorageDeleteOption)1);
            ROMDatabase.Current.RemoveROM(asyncVariable1.Name);
            ROMDatabase.Current.CommitChanges();
        }

        public static void DeleteROMTile(string romFileName)
        {
            IEnumerable<ShellTile> enumerable = ShellTile.ActiveTiles;
            romFileName = romFileName.ToLower();
            foreach (ShellTile tile in enumerable)
            {
                int num = tile.NavigationUri.OriginalString.LastIndexOf('=');
                if ((num >= 0) && tile.NavigationUri.OriginalString.Substring(num + 1).ToLower().Equals(romFileName))
                {
                    tile.Delete();
                }
            }
        }

        public async static Task<bool> DeleteSaveState(SavestateEntry entry)
        {
            ROMDatabase current = ROMDatabase.Current;
            if (!current.RemoveSavestateFromDB(entry))
            {
                return false;
            }
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
            StorageFolder saveFolder = await romFolder.GetFolderAsync("saves");
            try
            {
                StorageFile asyncVariable0 = await saveFolder.GetFileAsync(entry.FileName);
                await asyncVariable0.DeleteAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal async static Task DeleteSRAMFile(ROMDBEntry re)
        {
            string sramName = re.FileName.Substring(0, re.FileName.LastIndexOf('.')) + ".sav";
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
            StorageFolder saveFolder = await romFolder.GetFolderAsync("saves");
            try
            {
                StorageFile file = await saveFolder.GetFileAsync(sramName);
                IStorageFile asyncVariable0 = file;
                await asyncVariable0.DeleteAsync();
            }
            catch (Exception)
            {
            }
        }

        public async static Task FillDatabaseAsync()
        {
            ROMDatabase current = ROMDatabase.Current;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
            IReadOnlyList<StorageFile> roms = await romFolder.GetFilesAsync();
            foreach (StorageFile file in roms)
            {
                ROMDBEntry entry = InsertNewDBEntry(file.Name);
                await FindExistingSavestatesForNewROM(entry);
            }
            current.CommitChanges();
        }

        public async static Task FindExistingSavestatesForNewROM(ROMDBEntry entry)
        {
            ROMDatabase db = ROMDatabase.Current;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
            StorageFolder saveFolder = await romFolder.GetFolderAsync("saves");
            IReadOnlyList<StorageFile> saves = await saveFolder.GetFilesAsync();
            using (IEnumerator<StorageFile> enumerator = saves.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    StorageFile current = enumerator.Current;
                    string str = current.Name.ToLower();
                    string str2 = entry.DisplayName.ToLower();
                    if (str.Substring(0, str.Length - 5).Equals(str2) && str.EndsWith(".sgm"))
                    {
                        string s = current.Name.Substring(current.Name.Length - 5, 1);
                        int result = 0;
                        if (int.TryParse(s, out result) && (result != 9))
                        {
                            SavestateEntry entry2 = new SavestateEntry
                            {
                                ROM = entry,
                                Savetime = current.DateCreated.DateTime,
                                Slot = result,
                                FileName = current.Name
                            };
                            db.Add(entry2);
                        }
                    }
                }
            }
        }

        public static BitmapImage getBitmapImage(string path, string default_path)
        {
            BitmapImage image = new BitmapImage();
            if (path.Equals(DEFAULT_BACKGROUND_IMAGE))
            {
                return new BitmapImage(new Uri(path, UriKind.Relative));
            }
            if (!string.IsNullOrEmpty(path))
            {
                using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = file.OpenFile(path, FileMode.Open, FileAccess.Read))
                    {
                        image.SetSource(stream);
                    }
                }
            }
            return image;
        }

        public async static Task<LoadROMParameter> GetROMFileToPlayAsync(string fileName)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
            StorageFile romFile = await romFolder.GetFileAsync(fileName);
            return new LoadROMParameter { file = romFile, folder = romFolder, RomFileName = fileName };
        }

        internal async static Task<ROMDBEntry> ImportRomBySharedID(string fileID, string desiredName, DependencyObject page)
        {
            ROMDatabase current = ROMDatabase.Current;
            ProgressIndicator progressIndicator = SystemTray.GetProgressIndicator(page);
            progressIndicator.IsIndeterminate = (true);
            progressIndicator.Text = (string.Format(AppResources.ImportingProgressText, desiredName));
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder romFolder = await localFolder.CreateFolderAsync("roms", (CreationCollisionOption)3);
            IStorageFile asyncVariable0 = await SharedStorageAccessManager.CopySharedFileAsync(romFolder, desiredName, (NameCollisionOption)1, fileID);
            ROMDBEntry rOM = current.GetROM(asyncVariable0.Name);
            if (rOM == null)
            {
                rOM = InsertNewDBEntry(asyncVariable0.Name);
                await FindExistingSavestatesForNewROM(rOM);
                current.CommitChanges();
            }
            progressIndicator.Text = (AppResources.ApplicationTitle2);
            progressIndicator.IsIndeterminate = (false);
            MessageBox.Show(string.Format(AppResources.ImportCompleteText, rOM.DisplayName));
            return rOM;
        }

        internal async static Task ImportSaveBySharedID(string fileID, string actualName, DependencyObject page)
        {
            ROMDatabase current = ROMDatabase.Current;
            ROMDBEntry rOMFromSavestateName = null;
            string extension = Path.GetExtension(actualName).ToLower();
            if (extension == ".sgm")
            {
                rOMFromSavestateName = current.GetROMFromSavestateName(actualName);
            }
            else if (extension == ".sav")
            {
                rOMFromSavestateName = current.GetROMFromSRAMName(actualName);
            }
            if (rOMFromSavestateName == null)
            {
                MessageBox.Show(AppResources.NoMatchingNameText, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            else
            {
                if (extension == ".sgm")
                {
                    string s = actualName.Substring(actualName.Length - 5, 1);
                    int result = 0;
                    if (!int.TryParse(s, out result))
                    {
                        MessageBox.Show(AppResources.ImportSavestateInvalidFormat, AppResources.ErrorCaption, (MessageBoxButton)0);
                        return;
                    }
                }
                ProgressIndicator progressIndicator = SystemTray.GetProgressIndicator(page);
                progressIndicator.IsIndeterminate = (true);
                progressIndicator.Text = (string.Format(AppResources.ImportingProgressText, actualName));
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFolder romFolder = await localFolder.CreateFolderAsync("roms", (CreationCollisionOption)3);
                StorageFolder saveFolder = await romFolder.CreateFolderAsync("saves", (CreationCollisionOption)3);
                switch (extension)
                {
                    case ".sgm":
                        await SharedStorageAccessManager.CopySharedFileAsync(saveFolder, Path.GetFileNameWithoutExtension(rOMFromSavestateName.FileName) + actualName.Substring(actualName.Length - 5), (NameCollisionOption)1, fileID);
                        break;

                    case ".sav":
                        await SharedStorageAccessManager.CopySharedFileAsync(saveFolder, Path.GetFileNameWithoutExtension(rOMFromSavestateName.FileName) + ".sav", (NameCollisionOption)1, fileID);
                        rOMFromSavestateName.SuspendAutoLoadLastState = true;
                        break;
                }
                if (extension == ".sgm")
                {
                    int slot = int.Parse(actualName.Substring(actualName.Length - 5, 1));
                    if (rOMFromSavestateName != null)
                    {
                        SavestateEntry entry = current.SavestateEntryExisting(rOMFromSavestateName.FileName, slot);
                        if (entry != null)
                        {
                            current.RemoveSavestateFromDB(entry);
                        }
                        SavestateEntry entry2 = new SavestateEntry
                        {
                            ROM = rOMFromSavestateName,
                            Savetime = DateTime.Now,
                            Slot = slot,
                            FileName = actualName
                        };
                        current.Add(entry2);
                        current.CommitChanges();
                    }
                }
                progressIndicator.Text = (AppResources.ApplicationTitle2);
                progressIndicator.IsIndeterminate = (false);
                MessageBox.Show(string.Format(AppResources.ImportCompleteText, rOMFromSavestateName.DisplayName));
            }
        }

        public static ROMDBEntry InsertNewDBEntry(string fileName)
        {
            int num = fileName.LastIndexOf('.');
            int num2 = fileName.Length - num;
            string str = fileName.Substring(0, fileName.Length - num2);
            ROMDBEntry entry = new ROMDBEntry
            {
                DisplayName = str,
                FileName = fileName,
                LastPlayed = DEFAULT_DATETIME,
                SnapshotURI = "Assets/no_snapshot_gbc.png"
            };
            ROMDatabase.Current.Add(entry);
            return entry;
        }

        internal async static Task<List<CheatData>> LoadCheatCodes(ROMDBEntry re)
        {
            List<CheatData> cheats = new List<CheatData>();
            try
            {
                string fileName = re.FileName;
                int index = fileName.LastIndexOf('.');
                int diff = fileName.Length - index;
                string cheatFileName = fileName.Substring(0, fileName.Length - diff);
                cheatFileName = cheatFileName + ".cht";
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
                StorageFolder saveFolder = await romFolder.GetFolderAsync("saves");
                StorageFile asyncVariable0 = null;
                try
                {
                    asyncVariable0 = await saveFolder.GetFileAsync(cheatFileName);
                }
                catch (Exception)
                {
                    return cheats;
                }
                string codes = null;
                using (IRandomAccessStreamWithContentType stream = await asyncVariable0.OpenReadAsync())
                {
                    using (IInputStream readStream = stream.GetInputStreamAt(0L))
                    {
                        using (DataReader reader = new DataReader(readStream))
                        {
                            await (IAsyncOperation<uint>)reader.LoadAsync((uint)stream.Size);
                            codes = reader.ReadString((uint)stream.Size);
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(codes))
                {
                    string[] strArray = codes.Split(new char[] { '\n' });
                    for (int j = 0; j < strArray.Length; j += 3)
                    {
                        if ((strArray.Length - j) >= 3)
                        {
                            CheatData item = new CheatData();
                            item.Description = (strArray[j]);
                            item.CheatCode = (strArray[j + 1]);
                            item.Enabled = (strArray[j + 2].Equals("1"));
                            cheats.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return cheats;
        }

        private static Stream RenderAsPNGStream(Uri logo, Color tileColor)
        {
            try
            {
                StreamResourceInfo resourceStream = Application.GetResourceStream(logo);
                WriteableBitmap input = new WriteableBitmap(1, 1);
                try
                {
                    input.SetSource(resourceStream.Stream);
                }
                catch
                {
                }
                WriteableBitmap bitmap2 = WriteableBitmapEx.CreateTile(input, tileColor);
                EditableImage image = new EditableImage(bitmap2.PixelWidth, bitmap2.PixelHeight);
                for (int i = 0; i < bitmap2.PixelHeight; i++)
                {
                    for (int j = 0; j < bitmap2.PixelWidth; j++)
                    {
                        try
                        {
                            byte[] buffer = ControlToPng.ExtractRGBAfromPremultipliedARGB(bitmap2.Pixels[(bitmap2.PixelWidth * i) + j]);
                            image.SetPixel(j, i, buffer[0], buffer[1], buffer[2], buffer[3]);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                return image.GetStream();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async static Task SaveCheatCodes(ROMDBEntry re, List<CheatData> cheatCodes)
        {
            try
            {
                string fileName = re.FileName;
                int index = fileName.LastIndexOf('.');
                int diff = fileName.Length - index;
                string cheatFileName = fileName.Substring(0, fileName.Length - diff);
                cheatFileName = cheatFileName + ".cht";
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFolder romFolder = await localFolder.GetFolderAsync("roms");
                StorageFolder saveFolder = await romFolder.GetFolderAsync("saves");
                StorageFile asyncVariable0 = await saveFolder.CreateFileAsync("cheattmp.cht", (CreationCollisionOption)1);
                using (IRandomAccessStream asyncVariable1 = await asyncVariable0.OpenAsync((FileAccessMode)1))
                {
                    using (IOutputStream outStream = asyncVariable1.GetOutputStreamAt(0L))
                    {
                        using (DataWriter writer = new DataWriter(outStream))
                        {
                            writer.UnicodeEncoding = (UnicodeEncoding)(0);
                            writer.ByteOrder = (ByteOrder)(0);
                            for (int j = 0; j < cheatCodes.Count; j++)
                            {
                                if (j > 0)
                                {
                                    writer.WriteString("\n");
                                }
                                writer.WriteString(cheatCodes[j].Description);
                                writer.WriteString("\n");
                                writer.WriteString(cheatCodes[j].CheatCode);
                                writer.WriteString("\n");
                                writer.WriteString(cheatCodes[j].Enabled ? "1" : "0");
                            }
                            await (IAsyncOperation<uint>)writer.StoreAsync();
                            await writer.FlushAsync();
                            writer.DetachStream();
                        }
                    }
                }
                await asyncVariable0.RenameAsync(cheatFileName, (NameCollisionOption)1);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Save cheat code error: " + exception.Message);
            }
        }

        //public static void UpdateLiveTile()
        //{
        //    ROMDatabase current = ROMDatabase.Current;
        //    ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault<ShellTile>();
        //    FlipTileData data = new FlipTileData();
        //    data.Title = (AppResources.ApplicationTitle2);
        //    IEnumerable<string> recentSnapshotList = current.GetRecentSnapshotList();
        //    if (App.metroSettings.UseAccentColor || (recentSnapshotList.Count<string>() == 0))
        //    {
        //        data.SmallBackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileSmallGBC.png", UriKind.Relative));
        //        data.BackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileMediumGBC.png", UriKind.Relative));
        //        data.WideBackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileLargeGBC.png", UriKind.Relative));
        //        tile.Update(data);
        //    }
        //    else
        //    {
        //        data.SmallBackgroundImage = (new Uri("Assets/Tiles/FlipCycleTileSmallFilledGBC.png", UriKind.Relative));
        //        data.BackgroundImage = (new Uri("isostore:/" + recentSnapshotList.ElementAt<string>(0), UriKind.Absolute));
        //        data.WideBackgroundImage = (new Uri("isostore:/" + recentSnapshotList.ElementAt<string>(0), UriKind.Absolute));
        //        if (recentSnapshotList.Count<string>() >= 2)
        //        {
        //            data.BackBackgroundImage = (new Uri("isostore:/" + recentSnapshotList.ElementAt<string>(1), UriKind.Absolute));
        //            data.WideBackBackgroundImage = (new Uri("isostore:/" + recentSnapshotList.ElementAt<string>(1), UriKind.Absolute));
        //        }
        //        tile.Update(data);
        //    }
        //}

        //public static void UpdateROMTile(string romFileName)
        //{
        //    IEnumerable<ShellTile> enumerable = ShellTile.ActiveTiles;
        //    romFileName = romFileName.ToLower();
        //    foreach (ShellTile tile in enumerable)
        //    {
        //        int num = tile.NavigationUri.OriginalString.LastIndexOf('=');
        //        if ((num >= 0) && tile.NavigationUri.OriginalString.Substring(num + 1).ToLower().Equals(romFileName))
        //        {
        //            ROMDBEntry rOM = ROMDatabase.Current.GetROM(romFileName);
        //            if (rOM != null)
        //            {
        //                FlipTileData data = CreateFlipTileData(rOM);
        //                tile.Update(data);
        //            }
        //            break;
        //        }
        //    }
        //}











    }
}

