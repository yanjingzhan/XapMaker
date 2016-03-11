using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamSparkerDevRegister.Utility
{
    public class CharsHelper
    {
        private static Random rd;
        private static List<string> _cityList;
        private static List<string> _zipCode;
        private static List<string> _address;

        static CharsHelper()
        {
            rd = new Random();
            _zipCode = new List<string>();
            _cityList = new List<string>();

            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "add.txt"))
            {
                _address = new List<string>(sr.ReadToEnd().Split('\n'));
            }

            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "codecity.txt"))
            {
                string[] ts = (sr.ReadToEnd().Split('\n'));

                foreach (var t in ts)
                {
                    string[] shits = t.Split(' ');

                    if (shits.Length > 3)
                    {
                        _cityList.Add(shits[0].Trim());
                        _zipCode.Add(shits[2].Trim());
                    }
                }
            }
        }

        public static string CreateGBChar(int minLen, int maxLen)
        {
            int charLen = rd.Next(minLen, maxLen + 1);

            int area, code;//汉字由区位和码位组成(都为0-94,其中区位16-55为一级汉字区,56-87为二级汉字区,1-9为特殊字符区)
            StringBuilder sb = new StringBuilder();

            Random rand = new Random();
            for (int i = 0; i < charLen; i++)
            {
                area = rand.Next(16, 88);
                if (area == 55)//第55区只有89个字符
                {
                    code = rand.Next(1, 90);
                }
                else
                {
                    code = rand.Next(1, 94);
                }
                sb.Append(Encoding.GetEncoding("GB2312").GetString(new byte[] { Convert.ToByte(area + 160), Convert.ToByte(code + 160) }));
            }
            return sb.ToString();
        }

        public static string LastNameGetter()
        {
            string target = @"王陈张李周杨吴黄刘徐朱胡沈潘章程方孙郑金叶汪何马赵林蒋俞姚许丁施高余谢董汤钱卢江蔡宋曹邱罗杜郭戴洪唐袁夏童肖姜傅范顾梅盛吕诸邵陆彭韩倪雷郎梁楼万龚储鲍严葛华应冯项崔魏毛阮邹喻曾邓熊任陶费凌虞裘涂苏翁莫卞史季康管黎孔田单娄宣钟饶鲁廖于韦甘石孟柳祝胥殷舒褚薛白向邬尚竺查谈贾温游谭开伍庄成沙柏郝秦尉麻詹赖裴颜尹巴乐厉谷易段钮骆笪阎缪臧樊操卜丰文水兰包平乔伊有牟邢劳来求沃芮闵欧郏柯贺闻桂耿戚符蓝路阚滕霍上卫干支牛计车左申艾仲刑匡印吉宇安戎毕池纪过佘冷时束花迟邰卓宓宗官庞於明练苗茅郁冒洑相郤郦钦奚席晋晏柴聂宿密屠常鄂惠琚窦简蒿阙穆濮";

            int index = rd.Next(0, target.Length);
            return target.Substring(index, 1);
        }

        public static string ConvertToPinYin(string str)
        {
            string PYstr = string.Empty;
            foreach (char item in str.ToCharArray())
            {
                if (Microsoft.International.Converters.PinYinConverter.ChineseChar.IsValidChar(item))
                {
                    Microsoft.International.Converters.PinYinConverter.ChineseChar cc = new Microsoft.International.Converters.PinYinConverter.ChineseChar(item);

                    //PYstr += string.Join("", cc.Pinyins.ToArray());
                    PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1);
                    //PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1).Substring(0, 1).ToLower();
                }
                else
                {
                    PYstr += item.ToString();
                }
            }
            return PYstr.Trim();
        }

        public static string ConvertToPinYin(string str, string inserter)
        {
            string PYstr = string.Empty;
            foreach (char item in str.ToCharArray())
            {
                if (Microsoft.International.Converters.PinYinConverter.ChineseChar.IsValidChar(item))
                {
                    Microsoft.International.Converters.PinYinConverter.ChineseChar cc = new Microsoft.International.Converters.PinYinConverter.ChineseChar(item);

                    //PYstr += string.Join("", cc.Pinyins.ToArray());
                    PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1) + inserter;
                    //PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1).Substring(0, 1).ToLower();
                }
                else
                {
                    PYstr += item.ToString();
                }
            }
            return PYstr.Trim();
        }

        public static string GetAddress()
        {
            return _address[rd.Next(0, _address.Count)];
        }

        public static string GetCityAndZipCode()
        {
            int index_t = rd.Next(0, _zipCode.Count);

            return _cityList[index_t] + ":" + _zipCode[index_t];
        }

        public static string GetRandomPhoneNum()
        {
            string[] phoneSecondNum = { "3", "5", "8" };

            return string.Format("1{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                                phoneSecondNum[rd.Next(0, phoneSecondNum.Length)], rd.Next(0, 10), rd.Next(0, 10), rd.Next(0, 10), rd.Next(0, 10),
                                rd.Next(0, 10), rd.Next(0, 10), rd.Next(0, 10), rd.Next(0, 10), rd.Next(0, 10));
        }

        public static string PasswordCreatorZiMu(int minlength, int maxLength)
        {
            int length = rd.Next(minlength, maxLength + 1);

            string pwd = string.Empty;
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)rd.Next(65, 90)).ToString().ToLower();

            }
            return pwd.ToUpper();
        }

        public static void FuckChs(string path1, string path2)
        {

            using (StreamReader sr = new StreamReader(path1))
            {
                using (StreamWriter sw = new StreamWriter(path2, true))
                {
                    string st = sr.ReadLine();

                    StringBuilder sb = new StringBuilder("{");
                    while (st != null)
                    {
                        if (st.Trim().Length > 0 && !st.Contains(" ") && !st.Contains("/"))
                        {
                            string st2 = string.Empty;
                            foreach (char item in st.ToCharArray())
                            {
                                if (!Microsoft.International.Converters.PinYinConverter.ChineseChar.IsValidChar(item))
                                {
                                    st2 += item.ToString();
                                }
                            }

                            //sw.WriteLine(st2);

                            sb.Append("\"" + st2 + "\",");
                        }

                        st = sr.ReadLine();
                    }
                    sb.Append("}");
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        private static List<string> _wordList = new List<string> {"Strength","Intellect","Spirit","Vigor","Willpower","Cleansing","Charmsty","Luck","Prayer","Perception","Mighty","Infiltrate","Infest","Reincarnate","Impending","Impale","Fortitude","Feint","Plague","Feign","Petrify","Pierce","Detection","Combat",
                                                         "Damage","Cauterize","Conflagration","Detonation","Incinerate","Armor","Smite","Evocation","Block","Accuracy","speed","Defense","Kick","Precision","Throwing","Frenzy","Concussion","Subtlety","Camouflage","Elusiveness","Evasion","Vanish","Blind",
                                                         "Opportunity","Backstab","Ambush","Garrorte","Alchemy","Ambush","Arcane","Banish","Blast","Blizzard","Clasp","absorb","Grasp","Miss","Clock","Thick","Durability","Wild","Blessed","Wing","Dim","Diabolical","Devout","Dispel","Discipline","Aura","Aim",
                                                         "Charge","Defiance","Thorns","Mana","Jump","Shooter","Flail","Dragonslayer","Falchion","Brand","Sword","Rapier","Runesword","Shortsword","Broadsword","Stick","Quarterstaff","Pillar","Tail","Axe","Edge","Dragontooth","Francisca","Reaver","Tomahawk",
                                                         "Chopper","Hatchet","Fist","Weapon","Ballista","Catapult","Ram","Talons","Fork","Bow","Arrow","Godblade","Dragonfang","Thorn","Spike","Longbow","Crossbow","Razor","Rod","Splinter","Poker","Kris","Shiv","Poniard","Blade","Knife","Spear","Pike",
                                                         "Lance","Halberd","Hammer","Staff","Wand","Bardiche","Scythe","Staff","Pole","Gun","Dart","Phylactert","Crystal","Ball","Sphere","Globe","Orb","Stone","Scarab","Zither","Harpanola","Lyre","Didgeridoo","Psaltery","Alphorn","Harp","","Necklace",
                                                         "Pendant","Bauble","Talisman","Charm","Chain","Collar","Relic","Fang","Ion","Plasma","Laser","Bomb","Flare","Launcher","Rocket","Shotgun","Cannon","Howitzer","AP","HE","AA-Guns","Gauss","Battery","Armor","Ammo","Clip","Nail","Radar","Loof",
                                                         "Helmet","Halo","Crest","Greathelm","Circlet","Horns","Tiara","Sickle","Uniforms","Satchel","Backpack","Cinch","Strap","Belt","Sinew","Girdle","Sash","Cord","Waistguard","Kneepads","Gloves","Pants","Vestments","Scale","Cover","Shawl","Veil",
                                                         "Shroud","Drape","Cape","Cloak","Link","Band","Sinew","Signet","Circle","Seal","Bracer","Plate","Buckler","Aegis","Bulwark","Defender","Disk","Targe","Protector","Guard","Amulet","Greaves","Sandals","Footwraps","Striders","Sabatons","Slippers",
                                                         "Geta","Shoes","Loop","Bracelet","Ring","Granary","Tent","Avenger","Collar","Epaulet","Horn","Bugle","Dragonhorn","Star","Spade","Banner","Flag","Medallion","Badge","Totem","Symbol","Writ","Hide","Tablet","Forge","Flint","Ship","Flame","Arena",
                                                         "Armory","Cloister","Auction","Bandage","Mill","Cache","Caldron","Catalyst","Cyclone","Deed","Defile","Delicate","Morale","Demoralize","Manual","Codex","Tome","Scroll","Income","Turtle","Eagle","Crab","Skull","Horse","Spider","Sheep","Scorpion",
                                                         "Crow","Ladybug","Beetle","Chipmunk","Lizard","Bunny","Caterpillar","Cockroach","Fox","Starfish","Camel","Dragonfly","Lobster","Seagull","Giraffe","Rooster","Tarantula","Dinosaur","Dragon","Pack","Dummy","Devourer","Centurion","Centaur","Barbarian",
                                                         "Augur","General","Army","Shaman","Grunt","Gyrocopter","Peon","Sorceress","Blademaster","Knight","Rifleman","Civilian","Milltia","Wisp","Archer","Huntress","Dryad","Hippogryph","Chimaera","Warden","Acolyte","Ghoul","Gargoyle","Necromancer",
                                                         "Banshee","Abomination","Destroyer","Shade","Lich","Beastmaster","Archmage","Gunslinger","Convoy","Alliance","Monarch","Human","Dwarf","Gnome","Draenei","Horde","Orc","Troll","Tauren","Murlocs","Ogres","Nagas","Warrior","Priest","Rogue","Hunter",
                                                         "Mage","Warlock","Druid","Paladin","Apprentice","Panther","Pork","Bacon","Tomato","Beer","Banana","Spinach","Honey","Potato","Pear","Iron","Anvil","Copper","Stannum","Gold","Silver","Ore","Gem","Ruby","Diamond","Amazonium","Lumber","，Crude",
                                                         "Duration","Elite","Duel","Emissary","Encounter","Engulf","Lighten","Enrage","Entangle","Epic","Etch","Glacial","Halo","Heal","Hoof","Imbue","Mend","Martyr","","Cheat","Walkthrough","Character","game","play","player","save","load","continue",
                                                         "back","apply","sound","volume","video","audio","register","sell","crack","patch","tutorial","skip","single","multiply","、press","difficulty","easy","normal","medium","insane","nightmare","expert","profile","opponent","choose","magic","north",
                                                         "south","west","east","creature","slow","enemy","defeat","mission","stage","complete","fail","lose","cost","power","target","send","receive","Beginner","Intermediate","Advanced","skill","quest","danger","safety","abort","resume","legend","original",
                                                         "Cheat","Chanllenge","Adventure","Hire","Pardon","unfair","Rabot","Resolution","Brightness","Bloom","Glow","Blur","Flares","Decals","Exposure","Sprint","Crouch","Inventory","Bracer","Leggings","Telescope","Binoculars","Mask","Cap","Diadem","Crowns",};

        public static string GetRandomDevName(int minlength, int maxLength)
        {
            int length = rd.Next(minlength, maxLength + 1);

            string pwd = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string t = ((char)rd.Next(65, 90)).ToString();

                if(i == 0)
                {
                pwd = t.ToUpper();
                }
                else
                {
                    pwd += t.ToLower();
                }
            }

            int i1 = rd.Next(1, 3);
            List<string> sList_t = new List<string>();

            for (int i = 0; i < i1; i++)
            {
                sList_t.Add(_wordList[rd.Next(0, _wordList.Count)]);
            }

            sList_t.Insert(rd.Next(0, sList_t.Count + 1), pwd);

            StringBuilder sb = new StringBuilder();

            foreach (var s in sList_t)
            {
                sb.Append(s + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
