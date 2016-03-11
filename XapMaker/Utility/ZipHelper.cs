using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using ICSharpCode.SharpZipLib.Zip;

namespace XapMaker.Utility
{
    public class ZipHelper
    {
        public static Bitmap GetBmp(string zipfileName)
        {
            ZipFile zf = new ZipFile(zipfileName);
            try
            {

                ZipEntry z_t = zf.GetEntry("Assets/300.png");

                if (z_t != null)
                {
                    using (Stream stream_t = zf.GetInputStream(z_t))
                    {
                        Bitmap b = new Bitmap(stream_t);
                        stream_t.Close();
                        zf.Close();
                        return b;
                    }
                }
                else
                {
                    zf.Close();
                    throw new Exception("没有找到图片");
                }
            }
            catch (Exception ex)
            {
                zf.Close();
                throw ex;
            }
            finally
            {
                zf.Close();
            }
        }

        public static void SetBmp(string zipfileName, string imagePath)
        {

            using (ZipFile zip = new ZipFile(@"D:\work\windowsphone\Unity游戏\eXtreme Bike Stunts\工程\Store\xap\DefaultPackageName_Release_ARM.xap"))
            {
                zip.BeginUpdate();
                zip.Delete(@"GoogleAds.dll");
                zip.CommitUpdate();
            }

            //ZipFile zf = new ZipFile(zipfileName);

            //try
            //{
            //    ZipEntry z_t = zf.GetEntry("GoogleAds.dll");
            //    zf.Close();
            //    if (z_t != null)
            //    {
            //        zf.BeginUpdate();
            //        zf.Delete("GoogleAds.dll");
            //        zf.CommitUpdate();
            //    }

            //    zf.BeginUpdate();
            //    zf.Add(imagePath, "Assets/300.png");
            //    zf.CommitUpdate();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    zf.Close();
            //}
        }
    }
}
