using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameInfoAdder.Utility;
using GameInfoAdder.Models;
using System.Threading;

namespace GameInfoAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================");
            Console.WriteLine("===0.Test===========");
            Console.WriteLine("===1.净化游戏文件===");
            Console.WriteLine("===2.上传文件名称===");
            Console.WriteLine("===3.更新详细信息===");
            Console.WriteLine("===4.优化游戏名称===");
            Console.WriteLine("===5.特需游戏名称===");
            Console.WriteLine("===6.作废不在游戏===");
            Console.WriteLine("===7.特优游戏名称===");
            Console.WriteLine("===8.上传背景图片===");
            Console.WriteLine("===9.缩短游戏名字===");
            Console.WriteLine("===A.生成广告名字===");
            Console.WriteLine("===B.第二轮游戏名===");
            Console.WriteLine("===C.上传Unity游戏名===");
            Console.WriteLine("===D.生成Unity广告名字===");
            Console.WriteLine("===E.优化Unity游戏名字===");
            Console.WriteLine("===F.安卓第二轮游戏名===");
            Console.WriteLine("===G.安卓广告名===");

            Console.WriteLine("======================");

            string inputKey = Console.ReadLine();
            switch (inputKey.ToUpper())
            {
                case "1":
                    Console.WriteLine("请键入要净化的目录");
                    string dir = Console.ReadLine();
                    CleanUpGameFiles(dir);
                    break;
                case "2":
                    Console.WriteLine("请键入要上传的目录");
                    string dir2 = Console.ReadLine();
                    UploadGameNameInfo(dir2);
                    break;

                case "3":
                    Console.WriteLine("更新详细信息……");
                    UpdateGameDetails();
                    break;

                case "4":
                    Console.WriteLine("优化游戏名称……");
                    UpdateGameName();
                    break;

                case "5":
                    Console.WriteLine("特需游戏名称");
                    TeXuGameName("Video", "");
                    break;

                case "6":
                    Console.WriteLine("作废不在游戏");
                    DisableGame();
                    break;

                case "7":
                    Console.WriteLine("特优游戏名称");
                    GoodUpdateGameName();
                    break;

                case "8":
                    Console.WriteLine("上传背景图片");
                    UploadBjImage();
                    break;

                case "9":
                    Console.WriteLine("缩短游戏名字");
                    LittleUpdateGameName();
                    break;

                case "A":
                    Console.WriteLine("生成广告名字");
                    CreatAdNames();
                    break;

                case "B":
                    Console.WriteLine("第二轮游戏名");
                    SecondTimeGameName();
                    break;

                case "C":
                    Console.WriteLine("上传Unity游戏名");
                    UploadUnityGameNameInfo(@"E:\Work\WinFrom\XapMaker\资源等\GameNames.txt");
                    break;

                case "D":
                    Console.WriteLine("生成Unity广告名");
                    CreatUnityAdNames();
                    break;

                case "E":
                    Console.WriteLine("优化Unity游戏名字");
                    GoodUpdateUnityGameName();
                    break;

                case "F":
                    Console.WriteLine("安卓第二轮游戏名");
                    AndroidSecondTimeGameName();
                    break;

                case "G":
                    Console.WriteLine("安卓广告名");
                    CreatAndroidAdNames();
                    break;

                case "0":
                    Console.WriteLine("测试");
                    UpdateGameDetails();
                    break;

                default:
                    break;
            }

            Console.WriteLine("\n执行完成，任意键退出");
            Console.ReadKey();
        }


        public static void CleanUpGameFiles(string gameFilesPath)
        {
            string badFilesDir = Path.Combine(gameFilesPath, "badFiles");
            if (!Directory.Exists(badFilesDir))
            {
                Directory.CreateDirectory(badFilesDir);
            }


            foreach (var file in Directory.GetFiles(gameFilesPath))
            {
                string filePath = file;
                if (Path.GetFileNameWithoutExtension(file).ToLower().Contains("(jp)"))
                {
                    Console.WriteLine("{0} 是包含jp的文件，进行移动", Path.GetFileName(file));
                    Logger.Loglog(string.Format("{0} 是包含jp的文件，进行移动", Path.GetFileName(file)));

                    File.Move(file, Path.Combine(badFilesDir, Path.GetFileName(file)));
                    continue;
                }

                if (ZipHelper.IsJorJP(file))
                {
                    Console.WriteLine("{0} 中不包含U、E文件，进行移动", Path.GetFileName(file));
                    Logger.Loglog(string.Format("{0} 中不包含U、E文件，进行移动", Path.GetFileName(file)));

                    File.Move(file, Path.Combine(badFilesDir, Path.GetFileName(file)));
                    continue;
                }

                int index_t = Path.GetFileNameWithoutExtension(filePath).IndexOf(" - ");
                if (index_t > 0)
                {
                    int preNum = 0;
                    if (int.TryParse(Path.GetFileNameWithoutExtension(filePath).Substring(0, index_t), out preNum))
                    {
                        Console.WriteLine("{0} 是有前缀的的文件，进行改名，改为 {1}", Path.GetFileName(filePath), Path.GetFileName(filePath).Substring(index_t + 3));
                        Logger.Loglog(string.Format("{0} 是有前缀的的文件，进行改名，改为 {1}", Path.GetFileName(filePath), Path.GetFileName(filePath).Substring(index_t + 3)));

                        string targetPath = Path.Combine(gameFilesPath, Path.GetFileName(filePath).Substring(index_t + 3)).Trim();
                        if (!File.Exists(targetPath))
                        {
                            File.Move(filePath, targetPath);
                            filePath = targetPath;
                        }
                        else
                        {
                            File.Move(file, Path.Combine(badFilesDir, Path.GetFileName(file)));
                            continue;
                        }
                    }
                }

                if (Path.GetFileNameWithoutExtension(filePath).Contains("(") && Path.GetFileNameWithoutExtension(filePath).Contains(")"))
                {

                    int i1 = Path.GetFileNameWithoutExtension(filePath).IndexOf("(");
                    int i2 = Path.GetFileNameWithoutExtension(filePath).IndexOf(")");

                    string shit = Path.GetFileNameWithoutExtension(filePath).Substring(i1, i2 - i1 + 1);

                    Console.WriteLine("{0} 是有()文件，进行改名，改为 {1}", Path.GetFileName(filePath), Path.GetFileName(filePath).Replace(shit, ""));
                    Logger.Loglog(string.Format("{0} 是有()文件，进行改名，改为 {1}", Path.GetFileName(filePath), Path.GetFileName(filePath).Replace(shit, "")));

                    string targetPath = Path.Combine(gameFilesPath, Path.GetFileName(filePath)).Replace(shit, "").Trim();
                    if (!File.Exists(targetPath))
                    {
                        File.Move(filePath, targetPath);
                        filePath = targetPath;
                    }
                    else
                    {
                        if (filePath.ToLower().Contains("(us)"))
                        {
                            File.Move(targetPath, Path.Combine(badFilesDir, Path.GetFileName(targetPath)));
                            File.Move(filePath, targetPath);
                            filePath = targetPath;
                        }
                        else
                        {
                            File.Move(filePath, Path.Combine(badFilesDir, Path.GetFileName(filePath)));
                        }
                    }
                }

                if (Path.GetFileNameWithoutExtension(filePath).Contains("'") || Path.GetFileNameWithoutExtension(filePath).Contains("&"))
                {
                    Console.WriteLine("{0} 是有'文件，进行改名，改为 {1}", Path.GetFileName(filePath), Path.GetFileName(filePath).Replace("'", "").Replace("&", ""));
                    Logger.Loglog(string.Format("{0} 是有'文件，进行改名，改为 {1}", Path.GetFileName(filePath), Path.GetFileName(filePath).Replace("'", "").Replace("&", "")));

                    try
                    {
                        File.Move(filePath, Path.Combine(gameFilesPath, Path.GetFileName(filePath)).Replace("'", "").Replace("&", "").Trim());
                    }
                    catch { File.Move(filePath, Path.Combine(badFilesDir, Path.GetFileName(filePath))); }
                }
            }
        }

        public static void UploadGameNameInfo(string gameFilesPath)
        {
            foreach (var gameFile in Directory.GetFiles(gameFilesPath))
            {
                try
                {
                    HttpDataHelper.AddPushGameInfo(new PushGameInfoModel
                        {
                            FileName = Path.GetFileName(gameFile),
                            GameName = Path.GetFileNameWithoutExtension(gameFile),
                            State = "待提交",
                            LogoPath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/defaultlogo.png",
                            BackImagePath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/backimage.jpg",
                            Version = "0",
                            SourceType = ZipHelper.GetGameSourceType(gameFile)
                        });

                    Console.WriteLine("{0} 成功", Path.GetFileName(gameFile));
                    Logger.Loglog(string.Format("{0} 成功", Path.GetFileName(gameFile)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败，{1}", Path.GetFileName(gameFile), ex.Message);
                    Logger.Loglog(string.Format("{0} 失败，{1}", Path.GetFileName(gameFile), ex.Message));
                }
            }
        }

        public static void UpdateGameDetails()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetNoGameDetailsGameList();

            Console.WriteLine(gameList.Count);

            foreach (var gameInfo in gameList)
            {
                if (string.IsNullOrWhiteSpace(gameInfo.GameDetails))
                {
                    Thread.Sleep(60 * 1000);

                    try
                    {
                        string gameDetails = KillBadChars(HtmlHelper.GetGameDetails(gameInfo.GameName));
                        Console.WriteLine("{0}的详细信息 {1}", gameInfo.GameName, gameDetails);
                        Logger.Loglog(string.Format("{0}的详细信息 {1}", gameInfo.GameName, gameDetails));

                        HttpDataHelper.UpdatePushGameInfoByID(gameDetails, gameInfo.ID);

                        Console.WriteLine("{0} 成功", gameInfo.GameName);
                        Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                        Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                    }
                }
            }
        }

        private static string KillBadChars(string content)
        {
            string[] str = new string[] { "'", "<", ">", "%", "&", "|", "?", "*", "�" };

            foreach (var s in str)
            {
                if (content.Contains(s))
                {
                    content = content.Replace(s, "");
                }
            }
            return content;
        }

        public static void UpdateGameName()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "", "");

            Console.WriteLine(gameList.Count);

            foreach (var gameInfo in gameList)
            {
                try
                {
                    string newName = gameInfo.GameName.Replace("-", " ").Replace(", The", " ").Replace(",", " ").Replace("!", " ").Replace("   ", " ").Replace("  ", " ");


                    Console.WriteLine("{0}的新名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的详细信息 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void TeXuGameName(string oldStr, string newStr)
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "", "");

            Console.WriteLine(gameList.Count);

            foreach (var gameInfo in gameList)
            {
                try
                {
                    if (gameInfo.GameName.StartsWith(oldStr))
                    {
                        string newName = gameInfo.GameName.Replace(oldStr, newStr);

                        Console.WriteLine("{0}的新名字 {1}", gameInfo.GameName, newName);
                        Logger.Loglog(string.Format("{0}的新名字 {1}", gameInfo.GameName, newName));

                        HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                        Console.WriteLine("{0} 成功", gameInfo.GameName);
                        Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void DisableGame()
        {
            List<string> gameNameListInTxt = new List<string>();
            using (StreamReader sr = new StreamReader(@"E:\Work\WinFrom\GameNamesf3ae5fe8-c892-4b50-a173-51958096434f.txt", Encoding.Unicode))
            {
                string st = sr.ReadToEnd();

                string[] ss = st.Split('\n');

                foreach (var s in ss)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        gameNameListInTxt.Add(s.Trim());
                    }
                }
            }

            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "", "");

            Console.WriteLine(gameList.Count);

            int bad = 0;
            foreach (var game in gameList)
            {
                if (!gameNameListInTxt.Contains(Path.GetFileNameWithoutExtension(game.FileName)))
                {
                    Console.WriteLine("{0} 不在其中", game.GameName);
                    Logger.Loglog(string.Format("{0} 不在其中", game.GameName));

                    HttpDataHelper.UpdatePushGameStateInfoByID("不可用", game.ID);

                    Console.WriteLine("{0} 成功", game.GameName);
                    Logger.Loglog(string.Format("{0} 成功", game.GameName));

                    Console.WriteLine("{0}个了", ++bad);
                }
            }
        }

        public static void GoodUpdateGameName()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "安卓未就绪", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    string[] shitInster =
                        new string[] { "Action", "Adventure", "Fight", "Hero", "Dream", "Bomb", "Go", "Legend", "Next", "Boy", "Story", "Gaiden", "Free" };

                    List<string> gameNameSplited = gameInfo.GameName.Split(' ').ToList();

                    int index_t = rd.Next(0, shitInster.Length);
                    int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                    gameNameSplited.Insert(index_t2, shitInster[index_t]);
                    StringBuilder sb = new StringBuilder();
                    foreach (var s in gameNameSplited)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                    }

                    string newName = sb.ToString().Trim();

                    Console.WriteLine("{0}的新名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的详细信息 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void SecondTimeGameName()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "待审核", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    //string[] shitInster =
                    //    new string[] { "Action", "Adventure", "Fight", "Hero", "Dream", "Bomb",
                    //                    "Go", "Legend", "Next", "Boy", "Story", "Gaiden", "Free","Pro" };

                    //string[] shitInster =
                    //        new string[] { "Win", "Fighting", "Power", "Speed", "Fox", "Gun",
                    //                    "Aim", "Kick", "Blast", "Avenger" };

                    //string[] shitInster =
                    //        new string[] { "King", "Fist", "Angry", "Thinking", "Battle", "War",
                    //                    "Combat", "Classic", "Back", "Terminator" };

                    string[] shitInster =
                            new string[] { "Guns", "Fly", "Sky", "Hit", "Run", "Final",
                                            "Night", "Warfare", "Winning", "Ruins" };

                    string replacedName = gameInfo.GameName;
                    foreach (var s in shitInster)
                    {
                        if ((" " + gameInfo.GameName + " ").Contains(" " + s + " "))
                        {
                            replacedName = replacedName.Replace(s, "");
                        }
                    }

                    replacedName = replacedName.Replace("  ", " ");

                    string newName = gameInfo.GameName;
                    List<string> gameNameSplited = replacedName.Split(' ').ToList();

                    while (newName == gameInfo.GameName)
                    {

                        int index_t = rd.Next(0, shitInster.Length);
                        int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                        gameNameSplited.Insert(index_t2, shitInster[index_t]);
                        StringBuilder sb = new StringBuilder();
                        foreach (var s in gameNameSplited)
                        {
                            sb.Append(s);
                            sb.Append(" ");
                        }

                        newName = sb.ToString().Trim().Replace("  ", " ");
                    }

                    //newName = replacedName;

                    Console.WriteLine("{0}的新名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的详细信息 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void AndroidSecondTimeGameName()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "安卓待审核", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    //string[] shitInster =
                    //    new string[] { "Action", "Adventure", "Fight", "Hero", "Dream", "Bomb",
                    //                    "Go", "Legend", "Next", "Boy", "Story", "Gaiden", "Free","Pro" };

                    //string[] shitInster =
                    //        new string[] { "Win", "Fighting", "Power", "Speed", "Fox", "Gun",
                    //                    "Aim", "Kick", "Blast", "Avenger" };

                    //string[] shitInster =
                    //        new string[] { "King", "Fist", "Angry", "Thinking", "Battle", "War",
                    //                    "Combat", "Classic", "Back", "Terminator" };

                    //string[] shitInster =
                    //        new string[] { "Guns", "Fly", "Sky", "Hit", "Run", "Final",
                    //                        "Night", "Warfare", "Winning", "Ruins" };

                    string[] shitInster = new string[] { "Action", "Adventure", "Fight", "Hero", "Dream", "Bomb",
                                                         "Go", "Legend", "Next", "Boy", "Story", "Gaiden", "Free","Pro",
                                                         "Win", "Fighting", "Power", "Speed", "Fox", "Gun",
                                                         "Aim", "Kick", "Blast", "Avenger",
                                                         "King", "Fist", "Angry", "Thinking", "Battle", "War",
                                                         "Combat", "Classic", "Back", "Terminator",
                                                         "Guns", "Fly", "Sky", "Hit", "Run", "Final",
                                                         "Night", "Warfare", "Winning", "Ruins"};

                    string replacedName = gameInfo.GameName;
                    foreach (var s in shitInster)
                    {
                        if ((" " + gameInfo.GameName + " ").Contains(" " + s + " "))
                        {
                            replacedName = replacedName.Replace(s, "");
                        }
                    }

                    replacedName = replacedName.Replace("  ", " ");

                    string newName = gameInfo.GameName;
                    List<string> gameNameSplited = replacedName.Split(' ').ToList();

                    while (newName == gameInfo.GameName)
                    {

                        int index_t = rd.Next(0, shitInster.Length);
                        int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                        gameNameSplited.Insert(index_t2, shitInster[index_t]);
                        StringBuilder sb = new StringBuilder();
                        foreach (var s in gameNameSplited)
                        {
                            sb.Append(s);
                            sb.Append(" ");
                        }

                        newName = sb.ToString().Trim().Replace("  ", " ");
                    }

                    //newName = replacedName;

                    Console.WriteLine("{0}的新名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的详细信息 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void CreatAndroidAdNames()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "安卓未就绪", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    string[] shitInster =
                        new string[] { "OK", "ER", "D", "N", "L", "PL", "EU", "US" };

                    List<string> gameNameSplited = gameInfo.GameName.Split(' ').ToList();

                    int index_t = rd.Next(0, shitInster.Length);
                    int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                    gameNameSplited.Insert(index_t2, shitInster[index_t]);
                    StringBuilder sb = new StringBuilder();
                    foreach (var s in gameNameSplited)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                    }

                    string newName = sb.ToString().Trim();

                    Console.WriteLine("{0}的新广告名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的新广告名字 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushAdNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void LittleUpdateGameName()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "待提交", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    if (gameInfo.GameName == "Thomas the Tank Engine Adventure and Friends")
                    {
                        Console.WriteLine(gameInfo.GameName.Length);
                    }
                    if (gameInfo.GameName.Length < 45)
                    {
                        continue;
                    }
                    string newName = string.Empty;

                    List<string> gameNameSplited = gameInfo.GameName.Split(' ').ToList();

                    StringBuilder sb = new StringBuilder();
                    foreach (var s in gameNameSplited)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                        if (sb.Length < 45)
                        {
                            newName = sb.ToString().TrimEnd();
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine("{0} 的新名字 {1},长度为{2}", gameInfo.GameName, newName, newName.Length);
                    Logger.Loglog(string.Format("{0} 的新名字 {1},长度为{2}", gameInfo.GameName, newName, newName.Length));

                    HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void CreatAdNames()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "未就绪", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    string[] shitInster =
                        new string[] { "OK", "ER", "D", "N", "L", "PL", "EU", "US" };

                    List<string> gameNameSplited = gameInfo.GameName.Split(' ').ToList();

                    int index_t = rd.Next(0, shitInster.Length);
                    int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                    gameNameSplited.Insert(index_t2, shitInster[index_t]);
                    StringBuilder sb = new StringBuilder();
                    foreach (var s in gameNameSplited)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                    }

                    string newName = sb.ToString().Trim();

                    Console.WriteLine("{0}的新广告名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的新广告名字 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushAdNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void UploadUnityGameNameInfo(string gameNameFile)
        {
            List<string> gameNameList = new List<string>();
            using (StreamReader sr = new StreamReader(gameNameFile))
            {
                string[] s = sr.ReadToEnd().Split('\n');

                gameNameList.AddRange(s);
            }

            foreach (var g in gameNameList)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(g))
                    {
                        continue;
                    }

                    HttpDataHelper.AddPushGameInfo(new PushGameInfoModel
                    {
                        FileName = "DefaultPackageName_Master_ARM.xap",
                        GameName = g.Trim(),
                        State = "Unity未就绪",
                        LogoPath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/defaultlogo.png",
                        BackImagePath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/backimage.jpg",
                        Version = "0",
                        SourceType = "unity"
                    });

                    Console.WriteLine("{0} 成功", g);
                    Logger.Loglog(string.Format("{0} 成功", g));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败，{1}", g, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败，{1}", g, ex.Message));
                }
            }
        }

        public static void CreatUnityAdNames()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "Unity未就绪", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    string[] shitInster =
                        new string[] { "OK", "ER", "D", "N", "L", "PL", "EU", "US" };

                    List<string> gameNameSplited = gameInfo.GameName.Split(' ').ToList();

                    int index_t = rd.Next(0, shitInster.Length);
                    int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                    gameNameSplited.Insert(index_t2, shitInster[index_t]);
                    StringBuilder sb = new StringBuilder();
                    foreach (var s in gameNameSplited)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                    }

                    string newName = sb.ToString().Trim();

                    Console.WriteLine("{0}的新广告名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的新广告名字 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushAdNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }

        public static void GoodUpdateUnityGameName()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "Unity未就绪", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    string[] shitInster =
                        new string[] { "Action", "Adventure", "Fight", "Hero", "Dream", "Bomb", "Go", "Legend", "Next", "Boy", "Story", "Gaiden", "Free" };

                    List<string> gameNameSplited = gameInfo.GameName.Split(' ').ToList();

                    int index_t = rd.Next(0, shitInster.Length);
                    int index_t2 = rd.Next(0, gameNameSplited.Count + 1);

                    gameNameSplited.Insert(index_t2, shitInster[index_t]);
                    StringBuilder sb = new StringBuilder();
                    foreach (var s in gameNameSplited)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                    }

                    string newName = sb.ToString().Trim();

                    Console.WriteLine("{0}的新名字 {1}", gameInfo.GameName, newName);
                    Logger.Loglog(string.Format("{0}的详细信息 {1}", gameInfo.GameName, newName));

                    HttpDataHelper.UpdatePushGameNameInfoByID(newName, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }


        public static void UploadBjImage()
        {
            List<PushGameInfoModel> gameList = HttpDataHelper.GetGameList("", "", "");

            Console.WriteLine(gameList.Count);

            Random rd = new Random();

            foreach (var gameInfo in gameList)
            {
                try
                {
                    if (gameInfo.State == "不可用")
                    {
                        continue;
                    }

                    string imagePath = Directory.GetFiles(@"E:\Work\WinFrom\背景图")[0];
                    File.Move(imagePath, @"E:\Work\WinFrom\背景图\done\" + gameInfo.GameName + "_bj.png");
                    HttpDataHelper.UploadImage(@"E:\Work\WinFrom\背景图\done\" + gameInfo.GameName + "_bj.png");

                    string bjImageUrl = string.Format("http://gamemanager.pettostudio.net/resoures/wp/moniqi/{0}_bj.png", gameInfo.GameName);

                    Console.WriteLine("{0} 的背景图 {1}", gameInfo.GameName, bjImageUrl);
                    Logger.Loglog(string.Format("{0} 的背景图 {1}", gameInfo.GameName, bjImageUrl));

                    HttpDataHelper.UpdatePushGameBjImageByID(bjImageUrl, gameInfo.ID);

                    Console.WriteLine("{0} 成功", gameInfo.GameName);
                    Logger.Loglog(string.Format("{0} 成功", gameInfo.GameName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} 失败,{1}", gameInfo.GameName, ex.Message);
                    Logger.Loglog(string.Format("{0} 失败,{1}", gameInfo.GameName, ex.Message));
                }
            }
        }
    }
}
