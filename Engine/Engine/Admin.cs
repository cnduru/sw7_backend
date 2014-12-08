using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    static class Admin {
        public static void RecoverAndStartActiveGames() {
            DBController dbc = new DBController();
            List<Game> activeGames = dbc.GetActiveGames();
            foreach(Game game in activeGames) {
                GameThread gameToStart = new GameThread(game.id);
                AsynchronousSocketListener.gameThreadPool.StartThread(game.id, gameToStart);
            }
        }


        public static string GetPublicGames(string xml) {
            XMLbuilder xb = new XMLbuilder();

            DBController dbc = new DBController();
            List<Game> activeGames = dbc.GetActiveGames();
            List<Game> publicGames = new List<Game>();
            foreach (Game game in activeGames) {
                if (game.visibility == 1) {
                    publicGames.Add(game);
                }
            }

            return xb.PublicGamesAsXML(publicGames);
        }
    }
}
