﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Device.Location;
using System.Xml.Serialization;
using System.Xml;

namespace Engine {
    class GameThread {
        // http://adhamhurani.blogspot.dk/2010/08/c-how-to-add-distance-and-calculate-new.html
        // http://stackoverflow.com/questions/15258078/latitude-longitude-and-meters

        int gameId;
        XMLhandler xh = new XMLhandler();
        private static Random seed = new Random();
        private static Random r1 = new Random(seed.Next(0, 1000000));
        private static Random r2 = new Random(seed.Next(0, 1000000));

        public GameThread(int lobbyId) {
            gameId = lobbyId;
            //Get if lobbyId in DB has time limit - If yes
        }

        public void Start() {
            // tell database that the game is live
        }

        public string InitializeGame(string xml) {
            GeoCoordinate southEastBoundary = new GeoCoordinate();
            GeoCoordinate northWestBoundary = new GeoCoordinate();

            string gameName = xh.GetNameFromXML(xml);
            string privacy = xh.GetPrivacyFromXML(xml);
            int numberOfTeams = xh.GetNumberOfTeamsFromXML(xml);
            string gameStart = xh.GetGameStartFromXML(xml);
            string gameEnd = xh.GetGameEndFromXML(xml);
            int hostId = xh.GetHostIdFromXML(xml);
            southEastBoundary = xh.GetSouthEastBoundaryFromXML(xml);
            northWestBoundary = xh.GetNorthWestBoundaryFromXML(xml);



            //This is debug stuff
            // 57.049062, 9.897923 Aalborg Vestby
            // 57.022629, 9.955601 Sohngårsholm Parken
            // 56.834223, 10.118426 Bælum
            southEastBoundary.Latitude = 57.022629;
            southEastBoundary.Longitude = 9.955601;
            northWestBoundary.Latitude = 57.049062;
            northWestBoundary.Longitude = 9.897923;

            //Standard numbers. Used if not user-supplied
            int standardObjectInputCount = 20;
            int standardCollisionRadiusInMeters = 5;
            
            //Initialize Items and store them in the database
            List<GeoCoordinate> objectLocations = PlaceObjectsOnRectangularBoard(standardObjectInputCount, southEastBoundary, northWestBoundary, standardCollisionRadiusInMeters);
            StoreObjectLocationsInDB(objectLocations, gameId);

            return "Initialization complete";
        }

        public string AskDog(string hej) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(hej);
            int test = Convert.ToInt32(x.SelectNodes("//GameId/text()")[0].Value);
            Console.WriteLine(test);
            return "Sådan";
            //threadId = Thread.CurrentThread.ManagedThreadId;
            /*
            Random rnd = new Random();

            if (rnd.Next(0, 2) == 0) {
                return "yes" + GameId.ToString() + hej;
            } else {
                return "no" + GameId.ToString() + hej;
            }
            */
        }

        public string EditPlayerInvites(string xml) {

            return "This is a dummy message from EditPlayerInvites";
        }

        public string GetPlayerInvites(string xml) {
            DBController dbc = new DBController();
            
            dbc.Close();
            return "This is a dummy message from GetPlayerInvites";
        }
         
        public string JoinGame(string xml) {
            return "This is a dummy mesasge from JoinGame";
        }

        public string LeaveGame(string xml) {

            return "This is a dummy message from LeaveGame";
        }

        private List<GeoCoordinate> PlaceObjectsOnRectangularBoard(int inputCount, GeoCoordinate southEastBoundryCoord, GeoCoordinate northWestBoundaryCoord, int collisionRadiusInMeters) {
            List<GeoCoordinate> objectLocations = new List<GeoCoordinate>();
            double startWidth = Math.Min(southEastBoundryCoord.Latitude, northWestBoundaryCoord.Latitude);
            double startHeight = Math.Min(southEastBoundryCoord.Longitude, northWestBoundaryCoord.Longitude);
            double endWidth = Math.Max(southEastBoundryCoord.Latitude, northWestBoundaryCoord.Latitude);
            double endHeight = Math.Max(southEastBoundryCoord.Longitude, northWestBoundaryCoord.Longitude);

            double boardWidth = Math.Abs(southEastBoundryCoord.Latitude - northWestBoundaryCoord.Latitude);
            double boardHeight = Math.Abs(southEastBoundryCoord.Longitude - northWestBoundaryCoord.Longitude);
            double sectorSlicing = boardWidth / (inputCount / 2);
            double heightDivider = boardHeight / 2;
            double sweepWidth = startWidth;

            if (sectorSlicing> collisionRadiusInMeters * 0.0000449) {
                Console.WriteLine("sector sliced");
                for (int i = 0; i < Convert.ToInt32(Math.Floor(Convert.ToDouble(inputCount) / 2)); i++) {
                    // top sector
                    GetValidGeoCoord(objectLocations, southEastBoundryCoord, northWestBoundaryCoord, sweepWidth, sweepWidth + sectorSlicing, startHeight, startHeight + heightDivider, collisionRadiusInMeters);

                    // bottom sector
                    GetValidGeoCoord(objectLocations, southEastBoundryCoord, northWestBoundaryCoord, sweepWidth, sweepWidth + sectorSlicing, startHeight + heightDivider, endHeight, collisionRadiusInMeters);

                    sweepWidth += sectorSlicing;
                }

                if (objectLocations.Count < inputCount) {
                    // in case of uneven inputCount
                    GetValidGeoCoord(objectLocations, southEastBoundryCoord, northWestBoundaryCoord, startWidth, endWidth, startHeight, endHeight, collisionRadiusInMeters);
                }

            } else {
                Console.WriteLine("sector not sliced");
                // in case of too many desired objects on a small map, we just random every point
                for (int i = 0; i < inputCount; i++) {
                    GetValidGeoCoord(objectLocations, southEastBoundryCoord, northWestBoundaryCoord, startWidth, endWidth, startHeight, endHeight, collisionRadiusInMeters);
                }
            }

            return objectLocations;
        }



        private void GetValidGeoCoord(List<GeoCoordinate> objectLocations, GeoCoordinate southEastBoundryCoord, GeoCoordinate northWestBoundaryCoord, double widthMin, double widthMax, double heightMin, double heightMax, int collisionRadiusInMeters) {
            GeoCoordinate rndGeoCoord = new GeoCoordinate();
            do {
                rndGeoCoord = GetRandomGeoCoordOnBoard(widthMin, widthMax, heightMin, heightMax);
            } while (RadiusCollisionDetection(objectLocations, rndGeoCoord, collisionRadiusInMeters) || BorderCollisionDetection(southEastBoundryCoord, northWestBoundaryCoord, rndGeoCoord, collisionRadiusInMeters));
            objectLocations.Add(rndGeoCoord);
        }

        private GeoCoordinate GetRandomGeoCoordOnBoard(double widthMin, double widthMax, double heightMin, double heightMax) {
            double lat = r1.NextDouble() * (widthMax - widthMin) + widthMin;
            double lon = r2.NextDouble() * (heightMax - heightMin) + heightMin;
            GeoCoordinate gc = new GeoCoordinate(lat, lon);
            return gc;
        }

        // check for collision with other points on board
        private bool RadiusCollisionDetection(List<GeoCoordinate> objectLocations, GeoCoordinate geoCoord, int collisionRadiusInMeters) {
            foreach (GeoCoordinate objectLocation in objectLocations) {
                if (objectLocation.GetDistanceTo(geoCoord) <= collisionRadiusInMeters) {
                    return true;
                }
            }
            return false;
        }

        // check for collision with border on board
        private bool BorderCollisionDetection(GeoCoordinate southEastBoundryCoord, GeoCoordinate northWestBoundaryCoord, GeoCoordinate rndGeoCoord, int collisionRadiusInMeters) {

            double rightBorder = Math.Max(southEastBoundryCoord.Latitude, northWestBoundaryCoord.Latitude);
            double leftBorder = Math.Min(southEastBoundryCoord.Latitude, northWestBoundaryCoord.Latitude);
            double topBorder = Math.Max(southEastBoundryCoord.Longitude, northWestBoundaryCoord.Longitude);
            double botBorder = Math.Min(southEastBoundryCoord.Longitude, northWestBoundaryCoord.Longitude);

            GeoCoordinate leftBorderChecker = new GeoCoordinate(leftBorder, rndGeoCoord.Longitude);
            if (leftBorderChecker.GetDistanceTo(rndGeoCoord) <= collisionRadiusInMeters) {
                return true;
            }

            GeoCoordinate rightBorderChecker = new GeoCoordinate(rightBorder, rndGeoCoord.Longitude);
            if (rightBorderChecker.GetDistanceTo(rndGeoCoord) <= collisionRadiusInMeters) {
                return true;
            }

            GeoCoordinate botBorderChecker = new GeoCoordinate(rndGeoCoord.Latitude, botBorder);
            if (botBorderChecker.GetDistanceTo(rndGeoCoord) <= collisionRadiusInMeters) {
                return true;
            }

            GeoCoordinate topborderChecker = new GeoCoordinate(rndGeoCoord.Latitude, topBorder);
            if (topborderChecker.GetDistanceTo(rndGeoCoord) <= collisionRadiusInMeters) {
                return true;
            }

            return false;
        }

        private int GenerateRandomItems(int from, int to) {
            return r1.Next(from, to);
        }
		
        private void StoreObjectLocationsInDB(List<GeoCoordinate> objectLocations, int gameId) {
            List<Location> locationsToStore = new List<Location>();
            foreach (GeoCoordinate location in objectLocations) {
                locationsToStore.Add(new Location(0, gameId, GenerateRandomItems(1,4), 0, location.Latitude, location.Longitude));
            }

            DBController dbc = new DBController();
            dbc.addLocations(locationsToStore);
            dbc.Close();
        }

    }
    public delegate string AsyncAskDog(out int threadId, string hej);
}
