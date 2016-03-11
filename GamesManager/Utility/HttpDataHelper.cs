using GamesManager.Model;
using Models.GameManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GamesManager.Utility
{
    public class HttpDataHelper
    {
        public static int GetGameBiggestVersion(string gameName)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(string.Format("http://gamemanager.pettostudio.net/GamePusher.aspx?action=getpushgameinfomodellistbycount&count=1&gamename={0}", gameName)));

                List<PushGameInfoModel> pushGameInfoModelList = JsonHelper.DeserializeObjectFromJson<List<PushGameInfoModel>>(dataString);
                if (pushGameInfoModelList == null || pushGameInfoModelList.Count == 0)
                {
                    return -1;
                }
                else
                {
                    return int.Parse(pushGameInfoModelList[0].Version);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddPushGameInfo(PushGameInfoModel pushGameInfoModel)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/gamepusher.aspx?action=addpushgameinfo&gamename={0}&version={1}&state={2}&pushername={3}&surfaceaccountid={4}&surfaceadid={5}&googlebanner={6}&googlechaping={7}&pubcenterappid={8}&pubcenteradid={9}&devaccount={10}&devpassword={11}",
                                   pushGameInfoModel.GameName, pushGameInfoModel.Version, pushGameInfoModel.State, pushGameInfoModel.PusherName, pushGameInfoModel.SurfaceAccountID, pushGameInfoModel.SurfaceAdID, pushGameInfoModel.GoogleBanner, pushGameInfoModel.GoogleChaping, pushGameInfoModel.PubcenterAppID, pushGameInfoModel.PubcenterAdID, pushGameInfoModel.DevAccount, pushGameInfoModel.DevPassword)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> GetPusherNames()
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                   string.Format("http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetUserListByCount&count=0")));

                List<PusherUserModel> pusherUserModelList = JsonHelper.DeserializeObjectFromJson<List<PusherUserModel>>(dataString);
                if (pusherUserModelList == null || pusherUserModelList.Count == 0)
                {
                    throw new Exception("没有获取到工作人员信息");
                }
                else
                {
                    List<string> nameList = new List<string>();

                    foreach (var pusher in pusherUserModelList)
                    {
                        nameList.Add(pusher.Name);
                    }

                    return nameList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

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

        public static void DeleteGame(string gameName, string version)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=deletegameinfobynameandversion&gamename={0}&version={1}",
                         gameName.Trim(), version.Trim())));

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

        public static void UpdatePushGameInfo(string gameName, string version, string state, string pusherName, string gameID)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=updatepushgameinfo&gamename={0}&version={1}&state={2}&pusherName={3}&gameID={4}",
                         gameName.Trim(), version.Trim(), state.Trim(), pusherName.Trim(), gameID.Trim())));

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

        public static List<PusherUserModel> GetPushers()
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                   string.Format("http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetUserListByCount&count=0")));

                List<PusherUserModel> pusherUserModelList = JsonHelper.DeserializeObjectFromJson<List<PusherUserModel>>(dataString);
                if (pusherUserModelList == null || pusherUserModelList.Count == 0)
                {
                    throw new Exception("没有获取到工作人员信息");
                }
                else
                {
                    return pusherUserModelList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PusherUserModel GetOnePusher(string pusherName)
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                   string.Format("http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetUserListByCount&count=1&pushername={0}", pusherName)));

                List<PusherUserModel> pusherUserModelList = JsonHelper.DeserializeObjectFromJson<List<PusherUserModel>>(dataString);
                if (pusherUserModelList == null || pusherUserModelList.Count == 0)
                {
                    throw new Exception("没有获取到工作人员信息");
                }
                else
                {
                    return pusherUserModelList[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static void UpdatePusherUser(string pusername, string role, string password)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePusherUser&pushername={0}&role={1}&password={2}",
                         pusername.Trim(), role.Trim(), password.Trim())));

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

        public static void DeletePusherUser(string pusherName)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=deletepusheruser&pushername={0}",
                         pusherName.Trim())));

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

        public static void AddPusherUser(string pusherName, string password, string role)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=addpusheruser&pushername={0}&password={1}&role={2}",
                         pusherName.Trim(), password.Trim(), role.Trim())));

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

        public static DevAccounts GetDevAccountList()
        {
            WebClient wc = new WebClient();

            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                   string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=getdevaccounts&count=0")));

                DevAccounts devAccounts = JsonHelper.DeserializeObjectFromJson<DevAccounts>(dataString);
                if (devAccounts == null)
                {
                    throw new Exception("没有获取到开发账号和密码信息");
                }
                else
                {
                    return devAccounts;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void AndroidAddPushGameInfo(AndroidPushGameInfoModel androidPushGameInfoModel)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=AddAndroidPushGameInfo&GameName={0}&BaiDuAppID={1}&BaiduStoreDevAccount={2}&BaiduStoreDevPassword={3}&BaiduStoreStatus={4}" +
                                                                                            "&DevAccount={5}&DevPassword={6}&DuoMengAppID={7}&DuoMengBannerID={8}&DuoMengChaPingID={9}&FileName={10}&GameID={11}&GoogleBanner={12}" +
                                                                                            "&GoogleChaping={13}&PackageName={14}&PusherName={15}&SanLiuLingAppID={16}&SanLiuLingBannerID={17}&SanLiuLingChaPingID={18}&SanLiuLingStoreDevAccount={19}" +
                                                                                            "&SanLiuLingStoreDevPassword={20}&SanLiuLingStoreStatus={21}&State={22}&Version={23}&XiaomiStoreDevAccount={24}&XiaomiStoreDevPassword={25}&XiaomiStoreStatus={26}" +
                                                                                            "&YouMiAppID={27}&YouMiID={28}&JingZhongAppId={29}",
                                                                                            androidPushGameInfoModel.GameName, androidPushGameInfoModel.BaiDuAppID, androidPushGameInfoModel.BaiduStoreDevAccount, androidPushGameInfoModel.BaiduStoreDevPassword, androidPushGameInfoModel.BaiduStoreStatus,
                                                                                            androidPushGameInfoModel.DevAccount, androidPushGameInfoModel.DevPassword, androidPushGameInfoModel.DuoMengAppID, androidPushGameInfoModel.DuoMengBannerID, androidPushGameInfoModel.DuoMengChaPingID, androidPushGameInfoModel.FileName, androidPushGameInfoModel.GameID, androidPushGameInfoModel.GoogleBanner,
                                                                                            androidPushGameInfoModel.GoogleChaping, androidPushGameInfoModel.PackageName, androidPushGameInfoModel.PusherName, androidPushGameInfoModel.SanLiuLingAppID, androidPushGameInfoModel.SanLiuLingBannerID, androidPushGameInfoModel.SanLiuLingChaPingID, androidPushGameInfoModel.SanLiuLingStoreDevAccount,
                                                                                            androidPushGameInfoModel.SanLiuLingStoreDevPassword, androidPushGameInfoModel.SanLiuLingStoreStatus, androidPushGameInfoModel.State, androidPushGameInfoModel.Version, androidPushGameInfoModel.XiaomiStoreDevAccount, androidPushGameInfoModel.XiaomiStoreDevPassword, androidPushGameInfoModel.XiaomiStoreStatus,
                                                                                            androidPushGameInfoModel.YouMiAppID, androidPushGameInfoModel.YouMiID, androidPushGameInfoModel.JingZhongAppId)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<AndroidPushGameInfoModel> AndroidGetGameList(string gameName, string pusherName)
        {
            WebClient wc = new WebClient();
            try
            {
                pusherName = pusherName == "全部" ? string.Empty : pusherName;

                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=getandroidpushgameinfo&count=0&gamename={0}&pushername={1}",
                    gameName.Trim(), pusherName.Trim())));

                List<AndroidPushGameInfoModel> androidPushGameInfoModelList = JsonHelper.DeserializeObjectFromJson<List<AndroidPushGameInfoModel>>(dataString);
                if (androidPushGameInfoModelList == null || androidPushGameInfoModelList.Count == 0)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return androidPushGameInfoModelList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AndroidPushGameInfoModel> GetAndroidNotCompletedPushGameInfoModelListByPusherNameAndCount(string pusherName)
        {
            WebClient wc = new WebClient();
            try
            {
                pusherName = pusherName == "全部" ? string.Empty : pusherName;

                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=getandroidnotcompletedpushgameinfomodellistbypushernameandcount&count=0&pushername={0}",
                    pusherName.Trim())));

                List<AndroidPushGameInfoModel> androidPushGameInfoModelList = JsonHelper.DeserializeObjectFromJson<List<AndroidPushGameInfoModel>>(dataString);
                if (androidPushGameInfoModelList == null || androidPushGameInfoModelList.Count == 0)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return androidPushGameInfoModelList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void AndroidDeleteGame(string gameName, string version, string packageName)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=deletegameinfobynameandversionandpackagename&gamename={0}&version={1}&packagename={2}",
                         gameName.Trim(), version.Trim(), packageName.Trim())));

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

        public static void AndroidUpdatePushGameInfo(string gameName, string version, string packageName, string pusherName, string baiduStoreState, string sanLiuLingStoreState, string xiaoMiStoreState)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=updateandroidpushgameinfo&gamename={0}&version={1}&packagename={2}&pusherName={3}&baidustorestatus={4}&sanliulingstorestatus={5}&xiaomistorestatus={6}",
                         gameName.Trim(), version.Trim(), packageName.Trim(), pusherName.Trim(), baiduStoreState.Trim(), sanLiuLingStoreState.Trim(), xiaoMiStoreState.Trim())));

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

        #region AndroidLiuMang

        public static AndroidPushGameInfoModel GetOneFreeLiuMangGameInfo()
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=getonefreeliumanggameinfo")));

                AndroidPushGameInfoModel androidPushGameInfoModel = JsonHelper.DeserializeObjectFromJson<AndroidPushGameInfoModel>(dataString);
                if (androidPushGameInfoModel == null)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return androidPushGameInfoModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateGameNameAndState(string gameName, string packageName)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=UpdateGameNameAndState&gamename={0}&packagename={1}&state=待审核",
                          gameName, packageName)));

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

        public static void UpdateGameNameAndDisableState(string gameName, string packageName)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=UpdateGameNameAndState&gamename={0}&packagename={1}&state=不可用",
                          gameName, packageName)));

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

        public static List<AndroidPushGameInfoModel> AndroidGetLiuMangGameList(string gameName, string state, string packangename = "")
        {
            WebClient wc = new WebClient();
            try
            {
                state = state == "全部" ? string.Empty : state;

                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=getandroidpushgameinfo&count=0&gamename={0}&state={1}&packagename={2}",
                    gameName.Trim(), state.Trim(),packangename)));

                List<AndroidPushGameInfoModel> androidPushGameInfoModelList = JsonHelper.DeserializeObjectFromJson<List<AndroidPushGameInfoModel>>(dataString);
                if (androidPushGameInfoModelList == null || androidPushGameInfoModelList.Count == 0)
                {
                    throw new Exception("没有获取到游戏信息");
                }
                else
                {
                    return androidPushGameInfoModelList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void UpdateLiuMangPushGameInfo(string gameName, string version, string packageName, string state,
                                                     string iAdPushAppKey, string jingZhongAppId, string downloadAddress, string appType)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=UpdateAndroidPushGameInfo&gamename={0}&version={1}&state={2}&iadpushappkey={3}&jingzhongappid={4}&downloadaddress={5}&packageName={6}&apptype={7}",
                         gameName.Trim(), version.Trim(), state.Trim(), iAdPushAppKey.Trim(), jingZhongAppId.Trim(), downloadAddress.Trim(), packageName.Trim(), appType.Trim())));

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

        public static void AndroidAddLiuMangPushGameInfo(string gameName, string packageName, string iadpushAppKey, string jingZhongAppId,
                                                         string downloadAddress, string appType)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=AddAndroidPushGameInfo&GameName={0}&version={1}&state={2}&iadpushappkey={3}&jingzhongappid={4}&downloadaddress={5}&packageName={6}&apptype={7}",
                                                                                            gameName, "1", "待提交", iadpushAppKey, jingZhongAppId, downloadAddress, packageName, appType)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<AppInfoTempModel> GetFreeInfoTempModelList()
        {
            try
            {
                WebClient wc = new WebClient();
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                wc.DownloadData(string.Format(
                "http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=GetAppInfoTempList&count=0&state=待绑定")));

                List<AppInfoTempModel> appInfoTempModelList = JsonHelper.DeserializeObjectFromJson<List<AppInfoTempModel>>(dataString);
                if (appInfoTempModelList == null || appInfoTempModelList.Count == 0)
                {
                    throw new Exception("没有获取到应用信息");
                }
                else
                {
                    return appInfoTempModelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateAppInfoTempModel(string id, string state)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=updateappinfotemp&id={0}&state={1}",
                                                                                            id, state)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteAppInfoTempByID(string id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=deleteappinfotempbyid&id={0}",
                                                                                            id)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void AddLiuMangAds(string iadkey, string iadappname, string jingzhongkey, string jingzhongappname, string status)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=addliumangads&iadkey={0}&iadappname={1}&jingzhongkey={2}&jingzhongappname={3}&status={4}",
                                                                                            iadkey, iadappname, jingzhongkey, jingzhongappname, status)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateLiuMangAds(string iadkey, string iadappname, string jingzhongkey, string jingzhongappname, string status, string id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=UpdateLiuMangAds&iadkey={0}&iadappname={1}&jingzhongkey={2}&jingzhongappname={3}&status={4}&id={5}",
                                                                                            iadkey, iadappname, jingzhongkey, jingzhongappname, status, id)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<LiuMangAds> GetLiuMangsAdList(string iadkey, string jingzhongkey, string iadappname, string status)
        {
            WebClient wc = new WebClient();
            try
            {
                status = status == "全部" ? "" : status;

                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=GetLiuMangAdsList&iadkey={0}&jingzhongkey={1}&count=0&iadappname={2}&status={3}",
                                                                                            iadkey, jingzhongkey, iadappname, status)));

                List<LiuMangAds> liuMangsAdList = JsonHelper.DeserializeObjectFromJson<List<LiuMangAds>>(dataString);
                if (liuMangsAdList == null || liuMangsAdList.Count == 0)
                {
                    throw new Exception("没有获取到应用信息");
                }
                else
                {
                    return liuMangsAdList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteLiuMangAd(string id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/AndroidGamePusher.aspx?action=deleteliumangadsbyid&id={0}",
                                                                                            id)));

                if (!dataString.Contains("ok"))
                {
                    throw new Exception(dataString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
