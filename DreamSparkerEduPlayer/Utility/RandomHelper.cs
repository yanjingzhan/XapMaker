using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamSparkerEduPlayer.Utility
{
    public class RandomHelper
    {
        private static Random _rd = new Random();

        public static string PasswordCreator(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();
                pwd += (_rd.Next(0, 9)).ToString();

            }
            return pwd;
        }

        public static string CreatorZiMu(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();

            }
            return pwd;
        }

        public static string GetRandomPhoneNum()
        {
            string[] phoneSecondNum = { "3", "5", "8" };

            return string.Format("1{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                                phoneSecondNum[_rd.Next(0, phoneSecondNum.Length)], _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10),
                                _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10));
        }

        public static string GetRandomZipCode(int minLength, int maxLength)
        {
            string zipCode = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                zipCode += _rd.Next(0, 10).ToString();

            }
            return zipCode;
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
            int length = _rd.Next(minlength, maxLength + 1);

            string pwd = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string t = ((char)_rd.Next(65, 90)).ToString();

                if (i == 0)
                {
                    pwd = t.ToUpper();
                }
                else
                {
                    pwd += t.ToLower();
                }
            }

            int i1 = _rd.Next(1, 3);
            List<string> sList_t = new List<string>();

            for (int i = 0; i < i1; i++)
            {
                sList_t.Add(_wordList[_rd.Next(0, _wordList.Count)]);
            }

            sList_t.Insert(_rd.Next(0, sList_t.Count + 1), pwd);

            StringBuilder sb = new StringBuilder();

            foreach (var s in sList_t)
            {
                sb.Append(s + " ");
            }

            return sb.ToString().Trim();
        }

    }
}
