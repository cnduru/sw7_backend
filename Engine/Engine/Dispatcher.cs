using System;
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
                // todo: this string should be sent back to the android client
                string[] loginData = xh.GetLoginData(xml);
                string response = Auth.VerifyAccount(loginData[0], loginData[1]);
                return response;
            }
            else if(xml.Contains("<JoinGame>"))
            {
                string[] joinData = xh.GetJoinGameData(xml);

                //Locate variables in information sent from client
                // joinData[0] is gameID and joinData[1] is userID
                string methodCall = "AskDog";
                object[] methodParams = {joinData[0], joinData[1]};

                //ATTEMPTING TO CALL FUNCTION
                Type type = typeof(GameThread);
                MethodInfo method = type.GetMethod(methodCall);
                GameThread c = AsynchronousSocketListener.gameThreadPool.GetGameInstance(Convert.ToInt32(joinData[0]));
                string result = (string)method.Invoke(c, methodParams);

                return result;
            }
            else if(xml.Contains("<LeaveGame>"))
            {
                return "";
            }
            else if(xml.Contains("<EditPlayerInvites>"))
            {
                return "";
            }
            else
            {
                // no tag matched a known dispatch instruction
                return @"<Error>Message not understood</Error>";
            }
        }
    }
}
