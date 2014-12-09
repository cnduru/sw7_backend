using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    class XMLbuilder {
        public string PublicGamesAsXML(List<Game> publicGames) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<GetPublicGames>");
            foreach (Game game in publicGames) {
                string gameId = "<Game>" + "<GameId>" + game.id + "</GameId>" + "<GameName>" + game.alias + "</GameName>" + "</Game>";
                sb.Append(gameId);
            }
            sb.Append("</GetPublicGames>");

            return sb.ToString();
        }

        public string LoginSuccesful(Account acc) {
            return "<Login><UserId>" + acc.id + "</UserId><Valid>" + "TRUE" + "</Valid>" + "</Login>";
        }

        public string LoginFailed(Account acc) {
            return "<Login><UserId>" + acc.id + "</UserId><Valid>" + "FALSE" + "</Valid>" + "</Login>";
        }

        public string InviteComplete() {
            return "<JoinGame>" + "<Message>" + "TRUE" + "</Message>" + "</JoinGame>";
        }

        public string LeaveGameComplete() {
            return "<LeaveGame>" + "<Message>" + "TRUE" + "</Message>" + "</LeaveGame>";
        }

        public string GameUpdate(List<Player> playersInGame, int gameId) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<GameUpdate>");
            sb.Append("<GameId>" + gameId + "</GameId>");
            foreach (Player player in playersInGame) {
                sb.Append("<Player>");
                sb.Append("<UserId>" + player.id + "</UserId>");
                sb.Append("<Latitude>" + player.locX + "</Latitude>");
                sb.Append("<Longitude>" + player.locY + "</Longitude>");
                sb.Append("</Player>");
            }
            sb.Append("</GameUpdate>");
            return sb.ToString();
        }

        public string MyGames(List<Game> myGames) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<GetMyGames>");
            foreach (Game game in myGames) {
                sb.Append("<Game>");
                sb.Append("<GameId>" + game.id + "</GameId>");
                sb.Append("<GameName>" + game.alias + "</GameName>");
                sb.Append("</Game>");
            }
            sb.Append("</GetMyGames>");
            return sb.ToString();
        }

    }
}
