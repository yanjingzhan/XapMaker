using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace GamesManager.AndroidHandlers
{
    public class BaiDuPlayerHandler : BasePlayerHandler
    {
        public override void Init(string unityVersion)
        {
            SpecialTag = INIHelper.ReadIniData("BaiDu", "SpecialTag", "", GlobalData.ConfigIniPath);

            UnityVersionToDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                string.Format(INIHelper.ReadIniData("UnityVersionToDir", unityVersion, "", GlobalData.ConfigIniPath), SpecialTag));

            AndroidManifestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                string.Format(INIHelper.ReadIniData("UnityVersionToAndroidManifest", unityVersion, "", GlobalData.ConfigIniPath), SpecialTag));

            MainActivityPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                string.Format(INIHelper.ReadIniData("UnityVersionsToActivity", unityVersion, "", GlobalData.ConfigIniPath), SpecialTag));
        }

        public override void UnPackage(string apkFilePath)
        {
            base.UnPackage(apkFilePath);
        }

        public override void CopyInAssets()
        {
            base.CopyInAssets();
        }

        public override void CopyInLibs()
        {
            base.CopyInLibs();
        }

        public override void DeleteGen()
        {
            base.DeleteGen();
        }

        public override void ReplaceAdKey1(string adKey1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AndroidManifestPath);

            XmlElement rootElem = doc.DocumentElement;
            XmlNodeList nList = rootElem.SelectNodes("application/meta-data");

            foreach (var n in nList)
            {
                if ((n as XmlElement).GetAttribute("android:name").ToLower() == "bdappunionsdk_apikey")
                {
                    (n as XmlElement).SetAttribute("android:value", adKey1);
                }
            }
            doc.Save(AndroidManifestPath);
        }

        public override void ReplaceAdKey2(string adKey2)
        {
        }

        public override void ReplacePackageName(string packageName)
        {
            base.ReplacePackageName(packageName);
        }

        public override void ReplaceImportPackageName(string importPackageName)
        {
            using (StreamReader sr = new StreamReader(MainActivityPath))
            {
                string toBeReplace = sr.ReadLine();

                while (toBeReplace != null)
                {
                    if (toBeReplace.Trim().StartsWith("import ") && toBeReplace.Trim().EndsWith("_b.R;"))
                    {
                        ReplaceFileContentList.Add(new AndroidModels.ReplaceFileContent
                        {
                            FilePath = MainActivityPath,
                            ToBeReplaceContent = toBeReplace.Trim(),
                            RelpaceerContent = "import " + importPackageName + ".R;",
                            HisEncoding = Encoding.GetEncoding("GBK")
                        });
                        break;
                    }

                    toBeReplace = sr.ReadLine();
                }
            }
        }

        public override void ReplaceAppIcon(string iconPath)
        {
            base.ReplaceAppIcon(iconPath);
        }
    }
}
