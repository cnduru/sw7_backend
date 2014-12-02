using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Device.Location;

namespace Engine {
    class GameThread {
        int GameId;

        public GameThread(int lobbyId) {
            GameId = lobbyId;
            //Get if lobbyId in DB has time limit - If yes
        }

        public void Start() {
            //Setup crates and shit
        }

        public string InitializeGame() {

            return "win";
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

        public string EditPlayerInvites(out int threadId, string[] playersToInvite) {
            threadId = Thread.CurrentThread.ManagedThreadId;



            return "This is a dummy message from EditPlayerInvites";
        }

        public string GetPlayerInvites(out int threadId) {
            threadId = Thread.CurrentThread.ManagedThreadId;



            return "This is a dummy message from GetPlayerInvites";
        }

        public string JoinGame(out int threadId, string userToInvite) {
            threadId = Thread.CurrentThread.ManagedThreadId;

            return "This is a dummy mesasge from JoinGame";
        }

        public string LeaveGame(out int threadId, string userToRemove) {
            threadId = Thread.CurrentThread.ManagedThreadId;

            return "This is a dummy message from LeaveGame";
        }

        private void placeObjectsInRectangularMap(int inputCount, GeoCoordinate mapCoord1, GeoCoordinate mapCoord2) {
            List<Tuple<int, int>> objectLocationsAsPoint = new List<Tuple<int, int>>();
            double width = Math.Abs(mapCoord1.Latitude - mapCoord2.Latitude);
            double height = Math.Abs(mapCoord1.Longitude - mapCoord2.Longitude);
            double sectorSlicing = width / (inputCount / 2);
            int heightDivider = Convert.ToInt32(Math.Floor(height / 2));

            double sweepWidth = 0;
            int collisionRadius = 55;
            int widthPlacement = 0;
            int heightPlacement = 0;
            Random rnd = new Random();

            if (sectorSlicing > collisionRadius) {
                Console.WriteLine("Slicing Sector. " + sectorSlicing);
                for (int i = 0; i < Convert.ToInt32(Math.Ceiling(Convert.ToDouble(inputCount) / 2)); i++) {
                    Console.WriteLine("sweepWidth: " + sweepWidth);
                    // top sector
                    do {
                        widthPlacement = rnd.Next(Convert.ToInt32(Math.Floor(sweepWidth)), Convert.ToInt32(Math.Floor(sweepWidth + sectorSlicing)));
                        heightPlacement = rnd.Next(0, heightDivider);
                    } while (radiusCollisionDetection(objectLocationsAsPoint, widthPlacement, heightPlacement, collisionRadius) || borderCollisionDetection(mapCoord1, mapCoord2, widthPlacement, heightPlacement, collisionRadius));

                    // Insert code to create object on map here                    
                    objectLocationsAsPoint.Add(new Tuple<int, int>(widthPlacement, heightPlacement));

                    // bottom sector
                    do {
                        widthPlacement = rnd.Next(Convert.ToInt32(Math.Floor(sweepWidth)), Convert.ToInt32(Math.Floor(sweepWidth + sectorSlicing)));
                        heightPlacement = rnd.Next(heightDivider, Convert.ToInt32(Math.Floor(height)));
                    } while (radiusCollisionDetection(objectLocationsAsPoint, widthPlacement, heightPlacement, collisionRadius) || borderCollisionDetection(mapCoord1, mapCoord2, widthPlacement, heightPlacement, collisionRadius));
                    objectLocationsAsPoint.Add(new Tuple<int, int>(widthPlacement, heightPlacement));

                    sweepWidth += sectorSlicing;
                }

                while (objectLocationsAsPoint.Count < inputCount) {
                    do {
                        widthPlacement = rnd.Next(0, Convert.ToInt32(Math.Floor(width)));
                        heightPlacement = rnd.Next(0, Convert.ToInt32(Math.Floor(height)));
                    } while (radiusCollisionDetection(objectLocationsAsPoint, widthPlacement, heightPlacement, collisionRadius) || borderCollisionDetection(mapCoord1, mapCoord2, widthPlacement, heightPlacement, collisionRadius));
                    objectLocationsAsPoint.Add(new Tuple<int, int>(widthPlacement, heightPlacement));
                }

            } else {
                Console.WriteLine("Not Slicing Sector. " + sectorSlicing);
                for (int i = 0; i < inputCount; i++) {
                    do {
                        widthPlacement = rnd.Next(0, Convert.ToInt32(Math.Floor(width)));
                        heightPlacement = rnd.Next(0, Convert.ToInt32(Math.Floor(height)));
                    } while (radiusCollisionDetection(objectLocationsAsPoint, widthPlacement, heightPlacement, collisionRadius) || borderCollisionDetection(mapCoord1, mapCoord2, widthPlacement, heightPlacement, collisionRadius));
                    // Insert code to create object on map here
                    objectLocationsAsPoint.Add(new Tuple<int, int>(widthPlacement, heightPlacement));
                }
            }



        }

        private bool radiusCollisionDetection(List<Tuple<int, int>> objectLocations, int pointX, int pointY, int radius) {
            foreach (Tuple<int, int> objectLocation in objectLocations) {
                //detect point in circle e.g. point in another points collision radius
                //(x - center_x)^2 + (y - center_y)^2 < radius^2
                if (Math.Pow((pointX - objectLocation.Item1), 2) + Math.Pow((pointY - objectLocation.Item2), 2) < Math.Pow(radius, 2)) {
                    return true;
                }
            }
            return false;
        }

        // check for collision with border on map
        private bool borderCollisionDetection(GeoCoordinate mapCoord1, GeoCoordinate mapCoord2, int pointX, int pointY, int radius) {

            double rightBorder = Math.Max(mapCoord1.Latitude, mapCoord2.Latitude);
            double leftBorder = Math.Min(mapCoord1.Latitude, mapCoord2.Latitude);
            double topBorder = Math.Max(mapCoord1.Longitude, mapCoord2.Longitude);
            double botBorder = Math.Min(mapCoord1.Longitude, mapCoord2.Longitude);

            //left-border-check
            if (pointX - radius <= leftBorder) {
                return true;
            }
            //right-border-check
            if (pointX + radius >= rightBorder) {
                return true;
            }
            //top-border-check
            if (pointY + radius >= topBorder) {
                return true;
            }
            //bot-border-check
            if (pointY - radius <= botBorder) {
                return true;
            }

            return false;
        }




    }
    public delegate string AsyncAskDog(out int threadId, string hej);
}
