using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GamesManager.Utility;
using System.IO;
using GamesManager.AndroidModels;
using System.Xml;

namespace GamesManager.AndroidHandlers
{
    public abstract class BasePlayerHandler
    {
        protected string UnityVersionToDir;
        protected string SpecialTag;
        protected string AndroidManifestPath;
        protected string MainActivityPath;

        protected List<ReplaceFileContent> ReplaceFileContentList;

        public BasePlayerHandler()
        {
            ReplaceFileContentList = new List<ReplaceFileContent>();
        }

        public virtual void Init(string unityVersion)
        {
        }

        public virtual void UnPackage(string apkFilePath)
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            string unZipTempPath = Path.Combine(tempPath, "unZipTemp");
            if (Directory.Exists(unZipTempPath))
            {
                Directory.Delete(unZipTempPath, true);
            }
            ZipHelper.ExtractZipFile(apkFilePath, string.Empty, unZipTempPath);
        }

        public virtual void CopyInAssets()
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            string sourceDir = Path.Combine(tempPath, @"unZipTemp\assets");

            string targetDir = Path.Combine(UnityVersionToDir, "assets");
            foreach (var item in Directory.GetDirectories(targetDir))
            {
                Directory.Delete(item, true);
            }

            foreach (var item in Directory.GetFiles(targetDir))
            {
                File.Delete(item);
            }

            FileHelper.CopyFolder(sourceDir, targetDir);
        }

        public virtual void CopyInLibs()
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            string sourceDir = Path.Combine(tempPath, @"unZipTemp\lib");

            DirectoryInfo di = new DirectoryInfo(sourceDir);

            string targetDir = Path.Combine(UnityVersionToDir, "libs");


            foreach (var item in di.GetDirectories())
            {
                if (Directory.Exists(Path.Combine(targetDir, item.Name)))
                {
                    Directory.Delete(Path.Combine(targetDir, item.Name), true);
                }
            }

            foreach (var item in di.GetFiles())
            {
                if (File.Exists(Path.Combine(targetDir, item.Name)))
                {
                    File.Delete(Path.Combine(targetDir, item.Name));
                }
            }

            FileHelper.CopyFolder(sourceDir, targetDir);
        }

        public virtual void DeleteGen()
        {
            string targetDir = Path.Combine(UnityVersionToDir, "gen");

            foreach (var item in Directory.GetDirectories(targetDir))
            {
                Directory.Delete(item, true);
            }
        }

        public virtual void ReplaceAdKey1(string adKey)
        {

        }
        public virtual void ReplaceAdKey2(string adKey)
        {

        }


        public virtual void ReplacePackageName(string packageName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AndroidManifestPath);

            XmlElement rootElem = doc.DocumentElement;
            rootElem.SetAttribute("package", packageName);

            doc.Save(AndroidManifestPath);
        }

        public virtual void ReplaceImportPackageName(string importPackageName)
        {
           
        }

        public virtual void ReplaceAppIcon(string iconPath)
        {
            string targetFile = Path.Combine(UnityVersionToDir, @"res\drawable\app_icon.png");
            File.Copy(iconPath, targetFile, true);

            string targetFile2 = Path.Combine(UnityVersionToDir, @"bin\res\crunch\drawable\app_icon.png");
            if (File.Exists(targetFile2))
            {
                File.Copy(iconPath, targetFile2, true);
            }
        }

        public void AddRelpaceContentFile(ReplaceFileContent replaceFileContent)
        {
            ReplaceFileContentList.Add(replaceFileContent);
        }

        public void DoReplace()
        {
            foreach (var r in ReplaceFileContentList)
            {
                string content = string.Empty;

                using (StreamReader sr = new StreamReader(r.FilePath, r.HisEncoding))
                {
                    content = sr.ReadToEnd();
                }

                string newContent = content.Replace(r.ToBeReplaceContent, r.RelpaceerContent);

                using (StreamWriter sr = new StreamWriter(r.FilePath, false, r.HisEncoding))
                {
                    sr.Write(newContent);
                    sr.Flush();
                }
            }
        }

        public void ModifyGameName(string gameName)
        {
            string targetFile = Path.Combine(UnityVersionToDir, @"res\values\strings.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(targetFile);

            XmlElement rootElem = doc.DocumentElement;
            rootElem.FirstChild.InnerText = gameName;

            doc.Save(targetFile);
        }
    }
}
