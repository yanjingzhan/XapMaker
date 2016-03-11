using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameInfoAdder.Utility
{
    public class ZipHelper
    {
        public static bool IsUorE(string zipfileName)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        if (Path.GetFileNameWithoutExtension(e.Name).ToLower().Contains("(u)") || Path.GetFileNameWithoutExtension(e.Name).ToLower().Contains("(e)"))
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

        public static bool IsJorJP(string zipfileName)
        {
            ZipFile zf = null;

            try
            {
                using (FileStream fs = File.OpenRead(zipfileName))
                {
                    zf = new ZipFile(fs);

                    foreach (ZipEntry e in zf)
                    {
                        if (Path.GetExtension(e.Name).ToLower() == ".smc" || Path.GetExtension(e.Name).ToLower() == ".gba")
                        {
                            if (!Path.GetFileNameWithoutExtension(e.Name).ToLower().Contains("(j)") && !Path.GetFileNameWithoutExtension(e.Name).ToLower().Contains("(jp)"))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return true;
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
    }
}
