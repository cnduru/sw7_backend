using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine {
    class Game {
        int GameId;

        public Game(int lobbyId) {
            GameId = lobbyId;
            //Get if lobbyId in DB has time limit - If yes
        }

        public void Start() {
            //Setup crates and shit
        }

        public string AskDog(out int threadId, string hej) {
            threadId = Thread.CurrentThread.ManagedThreadId;
            Random rnd = new Random();

            if (rnd.Next(0, 2) == 0) {
                return "yes" + GameId.ToString() + hej;
            } else {
                return "no" + GameId.ToString() + hej;
            }

        }
    }
    public delegate string AsyncAskDog(out int threadId, string hej);
}
