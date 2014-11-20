﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine {
    class GameThreadPool {
        private Dictionary<Thread, GameThread> GameThreads;

        public GameThreadPool() {
            GameThreads = new Dictionary<Thread, GameThread>();
        }

        public void StartThread(int threadId, GameThread game) {
            ThreadStart threadDelegate = new ThreadStart(game.Start);
            Thread gameThread = new Thread(threadDelegate);

            //Thread gameThread = new Thread(game.Start);
            gameThread.IsBackground = true;
            gameThread.Name = "GameThread" + threadId;
            GameThreads.Add(gameThread, game);
            gameThread.Start();
        }
        public void KillThread(int threadId) {
            string name = "GameThread" + threadId;
            foreach (KeyValuePair<Thread, GameThread> threadGamePair in GameThreads) {
                if (threadGamePair.Key.Name == name)
                    threadGamePair.Key.Abort();
            }
        }

        public GameThread GetGameInstance(int threadId) {
            string name = "GameThread" + threadId;
            foreach (KeyValuePair<Thread, GameThread> threadGamePair in GameThreads) {
                if (threadGamePair.Key.Name == name)
                    return threadGamePair.Value;
            }
            throw new ArgumentOutOfRangeException("No such thread in pool");
        }
    }
}
