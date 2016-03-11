namespace CloudSixConnector.FileSaver
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.System;

    public class CloudSixSaver
    {
        public CloudSixSaver(string filename, Stream stream)
        {
            this.ImportedStream = stream;
            this.Filename = filename;
        }

        public async static void ClearSaveFolder()
        {
            try
            {
                StorageFolder local = ApplicationData.Current.LocalFolder;
                StorageFolder sharefolder = await local.CreateFolderAsync("CloudSixTmp", (CreationCollisionOption)2);
                IReadOnlyList<StorageFile> files = await sharefolder.GetFilesAsync();
                foreach (StorageFile file in files)
                {
                    await file.DeleteAsync();
                }
            }
            catch
            {
            }
        }

        public async Task Launch()
        {
            StorageFolder local = ApplicationData.Current.LocalFolder;
            await local.CreateFolderAsync("CloudSixTmp", (CreationCollisionOption)3);
            StorageFile windowsRuntimeFile = await local.CreateFileAsync(@"CloudSixTmp\" + this.Filename + "." + ((this.AppCustomExtension != null) ? this.AppCustomExtension.Trim(new char[] { '.' }) : "") + ".cloudsiximport", (CreationCollisionOption)1);
            using (Stream asyncVariable1 = await windowsRuntimeFile.OpenStreamForWriteAsync())
            {
                this.ImportedStream.Position = 0L;
                await this.ImportedStream.CopyToAsync(asyncVariable1);
            }
            try
            {
                bool result = await Launcher.LaunchFileAsync(windowsRuntimeFile);
            }
            catch
            {
            }
        }

        public string AppCustomExtension { get; set; }

        public string AppName { get; set; }

        public string Filename { get; private set; }

        public Stream ImportedStream { get; set; }


    }
}

