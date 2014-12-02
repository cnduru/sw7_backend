using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Engine {
    class GlobalTimerThread {
        private static List<GameEvent> gameEvents = new List<GameEvent>();
        public GlobalTimerThread() {

        }

        public static void Run() {
            Console.WriteLine("Global Timer initialised.");
            while (true) {
                if (gameEvents.Count == 0) {
                    Thread.Yield();
                } else {
                    for (int i = 0; i < gameEvents.Count(); i++) {
                        if (gameEvents[i].GetTriggerTimeStamp() < DateTime.Now) {
                            gameEvents[i].RunGameEvent();
                            try {
                                gameEvents.RemoveAt(i);
                            } catch (Exception e) {
                                throw new ArgumentOutOfRangeException("attempted to remove gameEvent at i, no succes");
                            }
                           break;
                        }
                    }
                }
            }
        }

        public static void AddGameEvent(GameEvent gameEvent) {
            gameEvents.Add(gameEvent);
        }


    }
}
