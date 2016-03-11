using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesManager.Model
{
    public class DevAccounts
    {
        public class BaiduDevAccount
        {
            public string BaiduStoreDevAccount;
            public string BaiduStoreDevPassword;
        }

        public class SanLiuLingDevAccounts
        {
            public string SanLiuLingStoreDevAccount;
            public string SanLiuLingStoreDevPassword;
        }

        public class XiaoMiDevAccounts
        {
            public string XiaomiStoreDevAccount;
            public string XiaomiStoreDevPassword;
        }

        public List<BaiduDevAccount> BaiduDevList;
        public List<SanLiuLingDevAccounts> SanLiuLingDevList;
        public List<XiaoMiDevAccounts> XiaoMiDevList;


        public List<string> GetBaiduDevAccounts()
        {
            List<string> result = new List<string>();

            if(BaiduDevList != null && BaiduDevList.Count > 0)
            {
                foreach (var b in BaiduDevList)
                {
                    result.Add(b.BaiduStoreDevAccount);
                }
            }
            return result;
        }

        public string GetBaiduDevPasswordByAccount(string a)
        {
            if (BaiduDevList != null && BaiduDevList.Count > 0)
            {
                foreach (var b in BaiduDevList)
                {
                    if(b.BaiduStoreDevAccount == a)
                    {
                        return b.BaiduStoreDevPassword;
                    }
                }
            }

            return string.Empty;
        }

        public List<string> GetSanLiuLingDevAccounts()
        {
            List<string> result = new List<string>();

            if (SanLiuLingDevList != null && SanLiuLingDevList.Count > 0)
            {
                foreach (var b in SanLiuLingDevList)
                {
                    result.Add(b.SanLiuLingStoreDevAccount);
                }
            }
            return result;
        }

        public string GetSanLiuLingDevPasswordByAccount(string a)
        {
            if (SanLiuLingDevList != null && SanLiuLingDevList.Count > 0)
            {
                foreach (var b in SanLiuLingDevList)
                {
                    if (b.SanLiuLingStoreDevAccount == a)
                    {
                        return b.SanLiuLingStoreDevPassword;
                    }
                }
            }

            return string.Empty;
        }

        public List<string> GetXiaoMiDevAccounts()
        {
            List<string> result = new List<string>();

            if (XiaoMiDevList != null && XiaoMiDevList.Count > 0)
            {
                foreach (var b in XiaoMiDevList)
                {
                    result.Add(b.XiaomiStoreDevAccount);
                }
            }
            return result;
        }

        public string GetXiaoMiDevPasswordByAccount(string a)
        {
            if (XiaoMiDevList != null && XiaoMiDevList.Count > 0)
            {
                foreach (var b in XiaoMiDevList)
                {
                    if (b.XiaomiStoreDevAccount == a)
                    {
                        return b.XiaomiStoreDevPassword;
                    }
                }
            }

            return string.Empty;
        }
    }
}
