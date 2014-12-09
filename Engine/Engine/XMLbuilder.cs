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
            StringBuilder sb = new StringBuilder();
            sb.Append("<Login>");
            sb.Append("<UserId>" + acc.id + "</UserId>");
            sb.Append("<Valid>" + "TRUE" + "</Valid>");
            sb.Append("</Login>");

            return sb.ToString();
        }

        public string LoginFailed(Account acc) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Login>");
            sb.Append("<UserId>" + acc.id + "</UserId>");
            sb.Append("<Valid>" + "FALSE" + "</Valid>");
            sb.Append("</Login>");

            return sb.ToString();
        }

        public string InviteComplete() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<JoinGame>");
            sb.Append("<Message>" + "TRUE " + "</Message>");
            sb.Append("</JoinGame>");
            return sb.ToString();
        }

        public string LeaveGameComplete() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<LeaveGame>");
            sb.Append("<Message>" + "TRUE " + "</Message>");
            sb.Append("</LeaveGame>");
            return sb.ToString();
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

        public string LobbyInfo(Game game) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<LobbyInfo>");
            sb.Append("<Privacy>" + game.visibility + "</Privacy>");
            sb.Append("<NumberOfTeams>" + game.teams + "</NumberOfTeams>");
            sb.Append("<GameEnd>" + game.end + "</GameEnd>");
            sb.Append("<SouthEastboundary>");
            sb.Append("<Latitude>" + "FIX KRISTIAN" + "</Latitude>");
            sb.Append("<Longitude>" + "FIX KRISTIAN" + "</Longitude>");
            sb.Append("</SouthEastboundary>");
            sb.Append("<NorthWestBoundary>");
            sb.Append("<Latitude>" + "FIX KRISTIAN" + "</Latitude>");
            sb.Append("<Longitude>" + "FIX KRISTIAN" + "</Longitude>");
            sb.Append("</NorthWestBoundary>");
            sb.Append("</LobbyInfo>");

            return sb.ToString();
        }
    }
}
