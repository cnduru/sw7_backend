using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    class GameEvent {
        private int eventType;
        private int gameId;
        private DateTime triggerTimeStamp;

        public GameEvent(int gameId, int eventType, DateTime triggerTimeStamp) {
            this.eventType = eventType;
            this.gameId = gameId;
            this.triggerTimeStamp = triggerTimeStamp;
        }

        public int GetEventType() {
            return this.eventType;
        }

        public int GetGameId() {
            return this.gameId;
        }

        public DateTime GetTriggerTimeStamp() {
            return this.triggerTimeStamp;
        }

        public void RunGameEvent() {
            Console.WriteLine("GAMEEVENT FIRED ON ID: " + GetGameId().ToString());
        }


    }
}
