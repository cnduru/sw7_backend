using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine {
    class Program {
        static void Main(string[] args) {
            GameThreadPool gameThreadPool = new GameThreadPool();

            GameThread gameA = new GameThread(50);
            GameThread gameB = new GameThread(51);
            GameThread gameC = new GameThread(52);

            gameThreadPool.StartThread(0, gameA);
            gameThreadPool.StartThread(1, gameB);
            gameThreadPool.StartThread(2, gameC);

            //Update thread for some reason
            AsyncAskDog caller = new AsyncAskDog(gameThreadPool.GetGameInstance(2).AskDog);
            int threadId;
            IAsyncResult result = caller.BeginInvoke(out threadId, "Penis", null, null);
            string answer = caller.EndInvoke(out threadId, result);


            AsynchronousSocketListener.StartListening();
            Thread socketListener = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
            socketListener.IsBackground = true;
            socketListener.Start();
        }
    }
}
