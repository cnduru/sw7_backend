using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Device.Location;

namespace Engine {
    class XMLbuilder {
        public string PublicGamesAsXML(List<Game> publicGames) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<GetPublicGames>");
            foreach (Game game in publicGames) {
                sb.Append("<Game>");
                sb.Append("<GameId>" + game.id + "</GameId>");
                sb.Append("<GameName>" + game.alias + "</GameName>");
                sb.Append("</Game>");
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

        public string JoinComplete() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<JoinGame>");
            sb.Append("<Message>" + "TRUE" + "</Message>");
            sb.Append("</JoinGame>");

            return sb.ToString();
        }

		public string InviteComplete (int accId)
		{
			string status = "TRUE";
			if (accId == 0) {
				status = "FALSE";
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("<InviteUser>");
			sb.Append("<Message>" + status + "</Message>");
			sb.Append("<UserId>" + accId.ToString() + "</UserId>");
			sb.Append("</InviteUser>");

			return sb.ToString();
		}

        public string LeaveGameComplete() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<LeaveGame>");
            sb.Append("<Message>" + "TRUE" + "</Message>");
            sb.Append("</LeaveGame>");

            return sb.ToString();
        }

        public string GameUpdate(List<Player> playersInGame, int gameId) {
            StringBuilder sb = new StringBuilder();
			DBController dbc = new DBController ();
            sb.Append("<GameUpdate>");
            sb.Append("<GameId>" + gameId + "</GameId>");
            foreach (Player player in playersInGame) {
                sb.Append("<Player>");
                sb.Append("<UserId>" + player.id + "</UserId>");
				sb.Append("<UserName>" + dbc.GetAccount(player.userName).userName + "</UserName>");
                sb.Append("<Latitude>" + player.locX + "</Latitude>");
                sb.Append("<Longitude>" + player.locY + "</Longitude>");
                sb.Append("</Player>");
            }
			dbc.Close ();
            sb.Append("</GameUpdate>");

            return sb.ToString();
        }

		public string InvitedPlayers(List<Player> playersInGame) {
			StringBuilder sb = new StringBuilder();
			DBController dbc = new DBController ();
			sb.Append("<GetPlayerInvites>");
			foreach (Player player in playersInGame) {
				sb.Append("<Player>");
				sb.Append("<UserId>" + player.id + "</UserId>");
				sb.Append("<UserName>" + dbc.GetAccount(player.userName).userName + "</UserName>");
				sb.Append("</Player>");
			}
			sb.Append("</GetPlayerInvites>");
			dbc.Close ();
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
            sb.Append("<NumberOfTeams>" + "9999999" + "</NumberOfTeams>");
			sb.Append("<HostId>" + game.hostID.ToString () + "</HostId>");
			sb.Append("<Alias>" + game.alias + "</Alias>");
            sb.Append("<GameEnd>");
            sb.Append("<Year>" + game.end.Year.ToString() + "</Year>");
            sb.Append("<Month>" + game.end.Month.ToString() + "</Month>");
            sb.Append("<Day>" + game.end.Day.ToString() + "</Day>");
            sb.Append("<Hour>" + game.end.Hour.ToString() + "</Hour>");
            sb.Append("<Minute>" + game.end.Minute.ToString() + "</Minute>");
            sb.Append("</GameEnd>");
            sb.Append("<NorthWestBoundary>");
            sb.Append("<Latitude>" + game.nwx + "</Latitude>");
            sb.Append("<Longitude>" + game.nwy + "</Longitude>");
            sb.Append("</NorthWestBoundary>");
            sb.Append("<SouthEastBoundary>");
            sb.Append("<Latitude>" + game.sex + "</Latitude>");
            sb.Append("<Longitude>" + game.sey + "</Longitude>");
            sb.Append("</SouthEastBoundary>");
            sb.Append("</LobbyInfo>");

            return sb.ToString();
        }

        public string CreateGameSuccesful(int gameId) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<CreateGame>");
            sb.Append("<Message>" + "TRUE" + "</Message>");
            sb.Append("<GameId>" + gameId + "</GameId>");
            sb.Append("</CreateGame>");

            return sb.ToString();
        }

        public string CreateGameFailed() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<CreateGame>");
            sb.Append("<Message>" + "FALSE" + "</Message>");
            sb.Append("</CreateGame>");

            return sb.ToString();
        }

        public string ShootActionSuccesful() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ShootAction>");
            sb.Append("<Message>" + "TRUE" + "</Message>");
            sb.Append("</ShootAction>");

            return sb.ToString();
        }

        public string ShootActionOutOfRange() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ShootAction>");
            sb.Append("<Message>" + "FALSE" + "</Message>");
            sb.Append("</ShootAction>");
            
            return sb.ToString();
        }

    }
}
