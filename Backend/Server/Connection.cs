using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace Server {
    public class Connection {

        int Id;
        int PackageStatus;
        int SignalStrength;
        Queue<int> SignalHistory = new Queue<int>();
        Stopwatch timer = new Stopwatch();

        public Connection(int id, int signalStrength) {
            this.Id = id;
            this.SignalStrength = signalStrength;
            this.SignalHistory.Enqueue(signalStrength);
            timer.Start();

        }

        public void Update(int signalStrength, int packageStatus) {
            timer.Restart();
            PackageStatus = packageStatus;
            this.SignalStrength = signalStrength;

            if (SignalHistory.Count >= 20) {
                SignalHistory.Dequeue();
            }

            SignalHistory.Enqueue(signalStrength);
        }

        public int GetId() {
            return Id;
        }

        public int GetSignalStrength() {
            return SignalStrength;
        }

        public int GetPackageStatus() {
            return PackageStatus;
        }

        public List<Point> GetSignalHistory() {
            List<Point> points = new List<Point>();
            for (int i = 0; i < SignalHistory.Count; i++) {
                points.Add(new Point(i, SignalHistory.ElementAt(i)));
            }

            return points;
        }
        public string GetTimeSinceConnection() {

            TimeSpan ts = timer.Elapsed;
            string presentable = "";
            presentable += String.Format("{0:00}", ts.Hours);
            presentable += " hours, ";
            presentable += String.Format("{0:00}", ts.Minutes);
            presentable += " minutes, ";
            presentable += String.Format("{0:00}", ts.Seconds);
            presentable += " seconds";

            return presentable;
        }
    }
}
