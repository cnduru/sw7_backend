using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engine
{
    class XMLhandler
    {
        ///<Summary>
        /// Method for extracting login data from XML 
        ///</Summary>
        public string[] GetLoginData(string xml) //string path = "login.xml")
        {
            string pattern = @"<Login><Username>([a-zA-Z0-9]*)<\S*<Password>([a-zA-Z0-9]*)<";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(xml);

            string[] res = {"", ""};

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    res[0] = match.Groups[1].Value;
                    res[1] = match.Groups[2].Value;
                }
                    
            }

            return res;
        }

        public string[] GetJoinGameData(string xml)
        {
            string pattern = @"<JoinGame><UserId>(\d*)<\S*><GameId>(\d*)<";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(xml);

            string[] res = { "", "" };

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    res[0] = match.Groups[1].Value;
                    res[1] = match.Groups[2].Value;
                }

            }

            return res;
        }
    }

  
}
