﻿using DreamSparkerDevRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DreamSparkerDevRegister.Utility
{
    public class HttpDataHelper
    {
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

        public static void UpdateDreamSparkerModel(string id, string state, string devAccount, string devPassword)
        {
            WebClient wc = new WebClient();
            try
            {
                string dataString = Encoding.GetEncoding("utf-8").GetString(
                         wc.DownloadData(string.Format(
                         "http://gamemanager.pettostudio.net/DreamSparker.aspx?action=UpdateDreamSparker&id={0}&state={1}&devAccount={2}&devPassword={3}",
                                                            id, state, devAccount, devPassword)));

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
