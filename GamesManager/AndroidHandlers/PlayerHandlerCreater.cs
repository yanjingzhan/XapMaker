using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesManager.AndroidHandlers
{
    public class PlayerHandlerCreater
    {
        public static BasePlayerHandler GetHandler(string type)
        {
            switch(type)
            {
                case "test":
                    return new TestIsGoodPlayerHandler();

                case "baidu":
                    return new BaiDuPlayerHandler();

                case "sanliuling":
                    return new SanLiuLingPlayerHandler();

                case "xiaomi":
                    return new XiaoMiPlayerHandler();

                default:
                    return null;
            }
        }
    }
}
