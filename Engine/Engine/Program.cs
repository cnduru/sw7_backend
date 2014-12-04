using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine {
    class Program {
        static void Main(string[] args) {
            
            //GameThreadPool gameThreadPool = new GameThreadPool();

            GameThread gameA = new GameThread(50);
            GameThread gameB = new GameThread(51);
            GameThread gameC = new GameThread(52);

            AsynchronousSocketListener.gameThreadPool.StartThread(0, gameA);
            AsynchronousSocketListener.gameThreadPool.StartThread(1, gameB);
            AsynchronousSocketListener.gameThreadPool.StartThread(2, gameC);
            

            /*
            //Update thread for some reason
            AsyncAskDog caller = new AsyncAskDog(gameThreadPool.GetGameInstance(2).AskDog);
            int threadId;
            IAsyncResult result = caller.BeginInvoke(out threadId, "Penis", null, null);
            string answer = caller.EndInvoke(out threadId, result);

            Console.WriteLine(answer); 
             */

            DateTime time1 = DateTime.Now.AddSeconds(5);
            DateTime time2 = DateTime.Now.AddSeconds(10);
            DateTime time3 = DateTime.Now.AddSeconds(15);
            DateTime time4 = DateTime.Now.AddSeconds(20);

            GameEvent event1 = new GameEvent(1, 1, time1);
            GameEvent event2 = new GameEvent(2, 1, time2);
            GameEvent event3 = new GameEvent(3, 1, time3);
            GameEvent event4 = new GameEvent(4, 1, time4);

            GlobalTimerThread.AddGameEvent(event1);
            GlobalTimerThread.AddGameEvent(event2);
            GlobalTimerThread.AddGameEvent(event3);
            GlobalTimerThread.AddGameEvent(event4);

            //Fires up the global timer
            Thread serverTimerThread = new Thread(new ThreadStart(GlobalTimerThread.Run));
            serverTimerThread.IsBackground = true;
            serverTimerThread.Start();

            Dispatcher.Dispatch("<AskDog><UserId>21</UserId><GameId>2</GameId></AskDog>");

            //Fires up network communication with clients
            AsynchronousSocketListener.StartListening();

            /*
            //Code below will not run. Async-socket-listener will take over main thread.
            Thread socketListener = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
            socketListener.IsBackground = true;
            socketListener.Start();*/
        }
    }
}
