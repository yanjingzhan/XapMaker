using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GamesManager.AndroidHandlers
{
    public class TestIsGoodPlayerHandler : BasePlayerHandler
    {
        public override void Init(string unityVersion)
        {
            SpecialTag = INIHelper.ReadIniData("TestIsGood", "SpecialTag", "", GlobalData.ConfigIniPath);

            UnityVersionToDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                string.Format(INIHelper.ReadIniData("UnityVersionToDir", unityVersion, "", GlobalData.ConfigIniPath), SpecialTag));
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

        /// <summary>
        /// 不删
        /// </summary>
        public override void DeleteGen()
        {

        }

        public override void ReplaceAdKey1(string adKey1)
        {
        }

        public override void ReplaceAdKey2(string adKey2)
        {
        }

        public override void ReplacePackageName(string packageName)
        {
        }

        public override void ReplaceImportPackageName(string importPackageName)
        {
        }

        public override void ReplaceAppIcon(string iconPath)
        {
        }
    }
}
