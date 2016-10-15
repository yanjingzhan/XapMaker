using DreamSparkerEduPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace DreamSparkerEduPlayer.Utility
{
    public class HttpDataHelper
    {
        public static void AddDreamSparkerModel(string account, string password, string newpassword, string state,
                                                string devaccount, string devpassword, string sourcetype, string token, string domian)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=adddreamsparkermodel&account={0}&password={1}&newpassword={2}&state={3}&devaccount={4}&devpassword={5}&sourcetype={6}&token={7}&domain={8}&pushcount=0",
                                                            account, password, newpassword, state, devaccount, devpassword, sourcetype, token, domian)));

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

        public static List<DreamSparkerModel> GetEduModelList(int count, string state, string sourceType)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=getdreamsparkerlistbycount&count={0}&state={1}&sourcetype={2}",
                    count, state, sourceType)));

                List<DreamSparkerModel> result = JsonHelper.DeserializeObjectFromJson<List<DreamSparkerModel>>(dataString);
                if (result == null || result.Count == 0)
                {
                    throw new Exception("没有获取到EDU信息");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DreamSparkerModel GetOneEduModelList(int count, string state)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                    wc.DownloadData(string.Format(
                    "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=getdreamsparkerlistbycount&count={0}&state={1}",
                    count, state)));

                List<DreamSparkerModel> result = JsonHelper.DeserializeObjectFromJson<List<DreamSparkerModel>>(dataString);
                if (result == null || result.Count == 0)
                {
                    throw new Exception("没有获取到EDU信息");
                }
                else
                {
                    return result[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static void UpdateDreamSparkerModel(string id, string state, string toek = "")
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=UpdateDreamSparker&id={0}&state={1}&token={2}",
                                                            id, state, toek)));

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

        public static void UpdateDreamSparkerModel(string id, string state, string devaccount, string devpassword)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=UpdateDreamSparker&id={0}&state={1}&devaccount={2}&devpassword={3}",
                                                            id, state, devaccount, devpassword)));

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


        public static List<DreamSparkerModel> CheckAccount(string accountcount)
        {
            WebClient wc = new WebClient();
            byte[] bResult = wc.DownloadData(
               string.Format("http://as.pettostudio.net/account.aspx?action=checkaccount&accountcount={0}", accountcount));

            string aiStr = Encoding.UTF8.GetString(bResult);

            List<AccountInfo> accountInfo = JsonHelper.DeserializeObjectFromJson<List<AccountInfo>>(aiStr);

            if (accountInfo == null || accountInfo.Count == 0)
            {
                return null;
            }
            else
            {
                List<DreamSparkerModel> result = new List<DreamSparkerModel>();

                foreach (var item in accountInfo)
                {
                    result.Add(new DreamSparkerModel
                    {
                        DevAccount = item.Account,
                        DevPassword = item.Password
                    });
                }

                return result;
            }
        }

        public static void UpdateAccountStateWithoutUserName(string account, string state)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://as.pettostudio.net/account.aspx?action=updateaccountstatewithoutusername&account={0}&state={1}",
                                                            account, state)));

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
