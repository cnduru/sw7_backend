using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    class GameEvent {
        private int eventType;

        public GameEvent(int eventType) {
            this.eventType = eventType;
        }

        public int getEventType() {
            return this.eventType;
        }
    }
}
