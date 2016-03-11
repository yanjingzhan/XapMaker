using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GamesManager.AndroidHandlers
{
    public class XiaoMiPlayerHandler : BasePlayerHandler
    {
        public override void Init(string unityVersion)
        {
            SpecialTag = INIHelper.ReadIniData("XiaoMi", "SpecialTag", "", GlobalData.ConfigIniPath);

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
            using (StreamReader sr = new StreamReader(MainActivityPath))
            {
                string toBeReplace = sr.ReadLine();

                while (toBeReplace != null)
                {
                    if (toBeReplace.Trim().StartsWith("AdManager.getInstance(this).init") && toBeReplace.Trim().EndsWith("\","))
                    {
                        ReplaceFileContentList.Add(new AndroidModels.ReplaceFileContent
                        {
                            FilePath = MainActivityPath,
                            ToBeReplaceContent = toBeReplace.Trim(),
                            RelpaceerContent = string.Format("AdManager.getInstance(this).init(\"{0}\",", adKey1),
                            HisEncoding = Encoding.GetEncoding("GBK")
                        });
                        break;
                    }
                    toBeReplace = sr.ReadLine();
                }
            }
        }

        public override void ReplaceAdKey2(string adKey2)
        {
            using (StreamReader sr = new StreamReader(MainActivityPath))
            {
                string toBeReplace = sr.ReadLine();

                while (toBeReplace != null)
                {
                    if (toBeReplace.Trim().StartsWith("\"") && toBeReplace.Trim().EndsWith("\", false);"))
                    {
                        ReplaceFileContentList.Add(new AndroidModels.ReplaceFileContent
                        {
                            FilePath = MainActivityPath,
                            ToBeReplaceContent = toBeReplace.Trim(),
                            RelpaceerContent = string.Format("\"{0}\", false);", adKey2),
                            HisEncoding = Encoding.GetEncoding("GBK")
                        });
                        break;
                    }
                    toBeReplace = sr.ReadLine();
                }
            }
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
                    if (toBeReplace.Trim().StartsWith("import ") && toBeReplace.Trim().EndsWith("_x.R;"))
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
