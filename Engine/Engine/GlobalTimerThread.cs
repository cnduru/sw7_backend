using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    class GlobalTimerThread {
        Queue<GameEvent> gameEvents = new Queue<GameEvent>();
        
        public GlobalTimerThread() {

        }

        public void enqueueGameEvent(GameEvent gameEvent) {
            gameEvents.Enqueue(gameEvent);
        }

        public GameEvent dequeueGameEvent() {
            return gameEvents.Dequeue();
        }


    }
}
