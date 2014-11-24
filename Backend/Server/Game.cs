using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Server {
    class Game {
        int GameId;

        public Game(int lobbyId) 
        {
            GameId = lobbyId;
            //Get if lobbyId in DB has time limit - If yes
        }

        public void Start() 
        {
            //Setup crates and shit
        }
    }
}
