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
    }
}
