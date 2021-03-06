﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class Dispatcher
    {
        /// <summary>
        /// Method dispatching XML instruction to the right component and returns a status XML string
        /// </summary>
        public static string Dispatch(string xml)
        {
            XMLhandler xh = new XMLhandler();

            if (xml.Contains("<Login>"))
            {
                return Admin.VerifyAccount(xml);
            }
            else if (xml.Contains("<CreateGame>")) {
                return Admin.CreateGame(xml);
            }
			else if (xml.Contains("<CloseGame>"))			{
				return Admin.CloseGame (xml);
			}
            else if(xml.Contains("<GameId>"))
            {
                //Locate variables in information sent from client
                string methodCall = xh.GetMethodCallFromXML(xml);
                object[] methodParams = {xml};

                //ATTEMPTING TO CALL FUNCTION
                Type type = typeof(GameThread);
                MethodInfo method = type.GetMethod(methodCall);
                GameThread c = AsynchronousSocketListener.gameThreadPool.GetGameInstance(xh.GetGameIdFromXML(xml));
                string result = (string)method.Invoke(c, methodParams);

                return result;
            } else if(xml.Contains("<GetMyGames>"))
            {
                return Admin.GetMyGames(xml);
            }
            else if (xml.Contains("<GetPublicGames>")) 
            {
                return Admin.GetPublicGames(xml);
            } else {
                // no tag matched a known dispatch instruction
                return @"<Error>Message not understood</Error>";
            }
        }
    }
}
