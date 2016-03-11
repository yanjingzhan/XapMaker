using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using WPGamer.Models;

namespace WPGamer.Utility
{
    public class HttpDataHelper
    {
        public static List<PushGameInfoModel> GetGameList(string gameName, string state, string pusherName)
        {
            WebClient wc = new WebClient();
            try
            {
                state = state == "全部" ? string.Empty : state;
                pusherName = pusherName == "全部" ? string.Empty : pusherName;

                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=getpushgameinfomodellistbycount&count=0&gamename={0}&state={1}&pushername={2}",
                    gameName.Trim(), state.Trim(), pusherName.Trim())));

                List<PushGameInfoModel> pushGameInfoModelList = JsonHelper.DeserializeObjectFromJson<List<PushGameInfoModel>>(dataString);
                if (pushGameInfoModelList == null || pushGameInfoModelList.Count == 0)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return pushGameInfoModelList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UploadImage(string imagePath)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.UploadFile("http://gamemanager.pettostudio.net/UploadManager.aspx", imagePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePushGameInfoByID(string gameName, string surfaceAccountID, string surfaceAdID,
                                                  string pubcenterAppID, string pubcenterAdID,
                                                  string googleBanner, string googleChaping, string logoPath,
                                                  string backImagePath, string Id, string state, string devaccount, string devpassword, string sourceType)
        {
            WebClient wc = new WebClient();
            try
            {
                devpassword = HttpUtility.UrlEncode(devpassword);

                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&gameName={1}&surfaceAccountID={2}&surfaceAdID={3}&pubcenterAppID={4}&pubcenterAdID={5}&googleBanner={6}&googleChaping={7}&logoPath={8}&backImagePath={9}&state={10}&devaccount={11}&devpassword={12}&sourceType={13}",
                                                            Id.Trim(), gameName.Trim(), surfaceAccountID.Trim(), surfaceAdID.Trim(), pubcenterAppID.Trim(), pubcenterAdID.Trim(),
                                                            googleBanner.Trim(), googleChaping.Trim(), logoPath.Trim(), backImagePath.Trim(), state.Trim(), devaccount.Trim(), devpassword.Trim(),sourceType.Trim())));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PushGameInfoModel GetOneGameInfoByStateRandom(string state, string newState)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoByStateRandom&jpstate={0}&newjpstate={1}",
                    state.Trim(), newState.Trim())));

                PushGameInfoModel pushGameInfoModel = JsonHelper.DeserializeObjectFromJson<PushGameInfoModel>(dataString);
                if (pushGameInfoModel == null)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return pushGameInfoModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateJpState(string jpState, string id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdateJpState&jpstate={0}&id={1}",
                                                            jpState, id)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static WordsModel GetWords()
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetWords")));

                WordsModel wordsModel = JsonHelper.DeserializeObjectFromJson<WordsModel>(dataString);
                if (wordsModel == null)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return wordsModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PushGameInfoModel GetOneGameInfoByRealStateRandom(string state, string newState, string devPusher)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoByRealStateRandom&state={0}&newstate={1}&devPusher={2}",
                    state.Trim(), newState.Trim(), devPusher)));

                PushGameInfoModel pushGameInfoModel = JsonHelper.DeserializeObjectFromJson<PushGameInfoModel>(dataString);
                if (pushGameInfoModel == null)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return pushGameInfoModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<WindowsDevAccounts> GetWindowsDevAccountsByGameState(string gameState)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetWindowsDevAccountsByGameState&gameState={0}", gameState.Trim())));

                List<WindowsDevAccounts> devAccountList = JsonHelper.DeserializeObjectFromJson<List<WindowsDevAccounts>>(dataString);
                if (devAccountList == null || devAccountList.Count == 0)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return devAccountList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DownloadFile(string url, string path)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.DownloadFile(url, path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePushGameStateInfoByID(string state, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&State={1}",
                         Id, state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePushGameNameByID(string newGameName, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&GameName={1}",
                         Id, newGameName)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetKeyWords(int count)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=getkeywords&count={0}", count)));

                List<string> devAccountList = JsonHelper.DeserializeObjectFromJson<List<string>>(dataString);
                if (devAccountList == null || devAccountList.Count == 0)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return devAccountList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static WindowsDevAccounts GetDevAccountByAccountName(string account)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetDevAccountByAccountName&account={0}", account)));

                WindowsDevAccounts devAccount = JsonHelper.DeserializeObjectFromJson<WindowsDevAccounts>(dataString);
                if (devAccount == null)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return devAccount;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PushGameInfoModel GetOneGameInfoAndChangeStateRandom(string state, string newstate)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoAndChangeStateRandom&state={0}&newstate={1}", state, newstate)));

                PushGameInfoModel result = JsonHelper.DeserializeObjectFromJson<PushGameInfoModel>(dataString);
                if (result == null)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PushGameInfoModel GetOneGameInfoAndChangeStateRandomForDev(string state, string newstate)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetOneGameInfoAndChangeStateRandomForDev&state={0}&newstate={1}", state, newstate)));

                PushGameInfoModel result = JsonHelper.DeserializeObjectFromJson<PushGameInfoModel>(dataString);
                if (result == null)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void DevSuccessedByDreamSpark(string id, string realDevAccount, string realDevPassword)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=DevSuccessedByDreamSpark&Id={0}&realDevAccount={1}&realDevPassword={2}",
                         id, realDevAccount, realDevPassword)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateDreamSparkerByDevAccount(string devAccount, string state)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=UpdateDreamSparkerByDevAccount&devaccount={0}&state={1}",
                                                            devAccount, state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region UnityPackage

        public static List<DreamSparkerModel> GetDreamSparkerListByCount(string state,int count)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=GetDreamSparkerListByCount&state={0}&count={1}", state, count.ToString())));

                List<DreamSparkerModel> result = JsonHelper.DeserializeObjectFromJson<List<DreamSparkerModel>>(dataString);
                if (result == null)
                {
                    throw new Exception("没有获取到开发者信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PushGameInfoModel GetOneGameByID(string id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=getpushgameinfomodellistbycount&count=0&id={0}",
                    id.Trim())));

                List<PushGameInfoModel> pushGameInfoModelList = JsonHelper.DeserializeObjectFromJson<List<PushGameInfoModel>>(dataString);
                if (pushGameInfoModelList == null || pushGameInfoModelList.Count == 0)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return pushGameInfoModelList[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}
