using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonPlayerGod.Utility
{
    public  class GameTypeConverter
    {
        public static string Convert(string source)
        {
            switch(source)
            {
                case "role-playing-games":
                    return "role-playing-games";

                case "card-games":
                    return "card-games";

                case "arcade-games":
                    return "arcade-games";

                case "trivia-games":
                    return "trivia-games";

                case "casual-games":
                    return "brain-and-puzzle-games";

                case "educational-games":
                    return "brain-and-puzzle-games";

                case "sports-games":
                    return "sports-games";

                case "family-games":
                    return "brain-and-puzzle-games";

                case "casino-games":
                    return "casino-games";

                case "board-games":
                    return "board-games";

                case "puzzle-games":
                    return "brain-and-puzzle-games";

                case "music-games":
                    return "music-and-rhythm-games";

                case "action-games":
                    return "action-games";

                case "simulation-games":
                    return "simulation-games";

                case "strategy-games":
                    return "strategy-games";

                case "word-games":
                    return "word-games";

                case "adventure-games":
                    return "adventure-games";

                case "racing-games":
                    return "racing-games";

                default :
                    return "adventure-games";
            }
        }
    }
}
