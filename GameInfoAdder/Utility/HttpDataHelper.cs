using GameInfoAdder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GameInfoAdder.Utility
{
    public class HttpDataHelper
    {
        public static void AddPushGameInfo(PushGameInfoModel pushGameInfoModel)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(wc.DownloadData(
                    string.Format("http://gamemanager.pettostudio.net/gamepusher.aspx?action=addpushgameinfo&gamename={0}&version={1}&state={2}&pushername={3}&surfaceaccountid={4}&surfaceadid={5}&googlebanner={6}&googlechaping={7}&pubcenterappid={8}&pubcenteradid={9}&devaccount={10}&devpassword={11}&gamedetails={12}&logopath={13}&backimagepath={14}&sourcetype={15}&filename={16}",
                                   pushGameInfoModel.GameName, pushGameInfoModel.Version, pushGameInfoModel.State, pushGameInfoModel.PusherName, pushGameInfoModel.SurfaceAccountID, pushGameInfoModel.SurfaceAdID, pushGameInfoModel.GoogleBanner, pushGameInfoModel.GoogleChaping,
                                   pushGameInfoModel.PubcenterAppID, pushGameInfoModel.PubcenterAdID, pushGameInfoModel.DevAccount, pushGameInfoModel.DevPassword, pushGameInfoModel.GameDetails, pushGameInfoModel.LogoPath, pushGameInfoModel.BackImagePath, pushGameInfoModel.SourceType, pushGameInfoModel.FileName)));

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

        public static List<PushGameInfoModel> GetNoGameDetailsGameList()
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/GamePusher.aspx?action=GetNoGameDetailsGameList")));

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

        public static void UpdatePushGameInfoByID(string gameDetails, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&gameDetails={1}",
                         Id, gameDetails)));

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

        public static void UpdatePushGameNameInfoByID(string gameName, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&gameName={1}",
                         Id, gameName)));

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

        public static void UpdatePushAdNameInfoByID(string adName, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&adName={1}",
                         Id, adName)));

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

        public static void UpdatePushGameBjImageByID(string backImagePath, string Id)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/GamePusher.aspx?action=UpdatePushGameInfoByID&Id={0}&backImagePath={1}",
                                                            Id.Trim(), backImagePath.Trim())));

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
    }
}
