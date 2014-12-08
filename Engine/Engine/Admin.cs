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
    }
}
