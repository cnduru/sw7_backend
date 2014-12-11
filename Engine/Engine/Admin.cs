using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Engine {
    static class Admin {
        public static void RecoverAndStartActiveGames() {
            DBController dbc = new DBController();
            List<Game> activeGames = dbc.GetActiveGames();
            dbc.Close();
            foreach(Game game in activeGames) {
                GameThread gameToStart = new GameThread(game.id);
                AsynchronousSocketListener.gameThreadPool.StartThread(game.id, gameToStart);
            }
        }

        public static string CreateGame(string xml) {
            XMLhandler xh = new XMLhandler();
            XMLbuilder xb = new XMLbuilder();

            int hostId = xh.GetHostIdFromXML(xml);
            int privacy = xh.GetPrivacyFromXML(xml);
            string gameName = xh.GetNameFromXML(xml);

            //DateTime timeStampNow = new DateTime(); FIX LATER
            //Datetime start
            //Datetime end
            DateTime timeOfCreation = DateTime.Now;
            DateTime startTime = xh.GetGameStartFromXML(xml);
            DateTime endTime = xh.GetGameEndFromXML(xml);

            GeoCoordinate northWestBoundary = xh.GetNorthWestBoundaryFromXML(xml);
            GeoCoordinate southEastBoundary = xh.GetSouthEastBoundaryFromXML(xml);
            double nwx = northWestBoundary.Latitude;
            double nwy = northWestBoundary.Longitude;
            double sex = southEastBoundary.Latitude;
            double sey = southEastBoundary.Longitude;


            // HANDLE SETTINGS

            Game newGame = new Game(0, hostId, privacy, gameName, timeOfCreation,
			                        startTime, endTime, nwx, nwy, sex, sey);
            DBController dbc = new DBController();
            int gameId = dbc.NewGame(newGame);
            dbc.Close();

            if (gameId > 0) {
                GameThread newGameThread = new GameThread(gameId);
                AsynchronousSocketListener.gameThreadPool.StartThread(gameId, newGameThread);

                // HANDLE SETTINGS

                return xb.CreateGameSuccesful(gameId);
            } else {
                return xb.CreateGameFailed();
            }
        }

        public static string GetPublicGames(string xml) {
            XMLbuilder xb = new XMLbuilder();

            DBController dbc = new DBController();
            List<Game> activeGames = dbc.GetActiveGames();
            dbc.Close();
            List<Game> publicGames = new List<Game>();
            foreach (Game game in activeGames) {
                if (game.visibility == 1) {
                    publicGames.Add(game);
                }
            }

            return xb.PublicGamesAsXML(publicGames);
        }

        public static string VerifyAccount(string xml) {
            XMLhandler xh = new XMLhandler();
            XMLbuilder xb = new XMLbuilder();
            // database stuff here
            // return XML indicating success or failure
            DBController dbc = new DBController();
            Account acc = dbc.GetAccount(xh.GetUsernameFromXML(xml));
            dbc.Close();

            string pwd = acc.password;
            
            if (xh.GetPasswordFromXML(xml) == pwd) {
                return xb.LoginSuccesful(acc);
            } else {
                return xb.LoginFailed(acc);
            }
        }

        public static string GetMyGames(string xml) {
            XMLhandler xh = new XMLhandler();
            XMLbuilder xb = new XMLbuilder();

            DBController dbc = new DBController();
            List<Game> myGames = dbc.GetGames(xh.GetUserIdFromXML(xml));
            dbc.Close();

            return xb.MyGames(myGames);
        }
    }
}
