using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WPGamer.Utility
{
    public class ZipHelper
    {
        public static bool ExtNameExist(string zipfileName, string extName)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        if (Path.GetExtension(e.Name).ToLower() == extName.ToLower())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string GetExtNameFile(string zipfileName, string extName)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        if (Path.GetExtension(e.Name).ToLower() == extName.ToLower())
                        {
                            return e.Name;
                        }
                    }
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void DecompressionOneFileByExtname(string zipfileName, string extName, string targetFile)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        if (Path.GetExtension(e.Name).ToLower() == extName.ToLower())
                        {
                            byte[] buffer = new byte[4096];
                            Stream zipStream = zf.GetInputStream(e);

                            using (FileStream streamWriter = File.Create(targetFile))
                            {
                                StreamUtils.Copy(zipStream, streamWriter, buffer);
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Compresses the files in the nominated folder, and creates a zip file on disk named as outPathname.
        //
        public static void CreateSample(string outPathname, string folderName)
        {

            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
            zipStream.Close();
        }

        // Recurses down the folder structure
        //
        private static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {

            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {

                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }

        public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        public static string GetGameSourceType(string zipfileName)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        if (Path.GetExtension(e.Name).ToLower() == ".smc")
                        {
                            return "SFC";
                        }

                        else if (Path.GetExtension(e.Name).ToLower() == ".gba")
                        {
                            return "GBA";
                        }
                        else
                        {
                            continue;
                        }
                    }

                    return "Nan";

                }
            }
            catch
            {
                return "Nan";
            }
        }

        public static void DecompressionOneFileByExtnameAndCountry(string zipfileName, string extName, string country1, string country2, string targetFile)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        string name_t = Path.GetFileName(e.Name);
                        if (Path.GetExtension(e.Name).ToLower() == extName.ToLower())
                        {
                            if ((!string.IsNullOrWhiteSpace(country1) && name_t.ToLower().Contains(country1.ToLower())) ||
                                (!string.IsNullOrWhiteSpace(country2) && name_t.ToLower().Contains(country2.ToLower())) ||
                                (string.IsNullOrWhiteSpace(country1) && string.IsNullOrWhiteSpace(country2)))
                            {
                                byte[] buffer = new byte[4096];
                                Stream zipStream = zf.GetInputStream(e);

                                using (FileStream streamWriter = File.Create(targetFile))
                                {
                                    StreamUtils.Copy(zipStream, streamWriter, buffer);
                                }
                                return;
                            }
                        }
                    }

                    foreach (ZipEntry e in zf)
                    {
                        string name_t = Path.GetFileName(e.Name);
                        if (Path.GetExtension(e.Name).ToLower() == extName.ToLower())
                        {
                            byte[] buffer = new byte[4096];
                            Stream zipStream = zf.GetInputStream(e);

                            using (FileStream streamWriter = File.Create(targetFile))
                            {
                                StreamUtils.Copy(zipStream, streamWriter, buffer);
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
