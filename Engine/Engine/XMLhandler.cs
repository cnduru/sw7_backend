using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Device.Location;
using System.Xml.Serialization;
using System.Xml;

namespace Engine
{
    class XMLhandler
    {
        ///<Summary>
        /// Method for extracting login data from XML 
        ///</Summary>
        public string[] GetLoginData(string xml) 
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

        public string GetMethodCallFromXML(string xml)
        {
            int index = xml.IndexOf('>');
            return xml.Substring(1, index - 1);
        }

        public List<String> GetParams(string xml)
        {

            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            var xx = x.SelectNodes("//text()");
            List<String> result = new List<string>();

            foreach (XmlNode item in xx)
            {
                result.Add(item.Value);
            }

            return result;
        }

        public int GetGameIdFromXML(string xml)
        {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//GameId/text()")[0].Value);
        }

        public string GetNameFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x.SelectNodes("//Name/text()")[0].Value;
        }

        public int GetUserIdFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//UserId/text()")[0].Value);
        }

        public string GetPrivacyFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x.SelectNodes("//Privacy/text()")[0].Value;
        }

        public int GetNumberOfTeamsFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//NumberOfTeams/text()")[0].Value);
        }

        public GeoCoordinate GetSouthEastBoundaryFromXML(string xml) {
            // Fix this later

            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            string seb = x.SelectNodes("//SouthEastBoundary/text()")[0].Value;

            GeoCoordinate sebGeo = new GeoCoordinate(1.2, 1.2);
            return sebGeo;
        }

        public GeoCoordinate GetNorthWestBoundaryFromXML(string xml) {
            // Fix this later

            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            string nwb = x.SelectNodes("//NorthWestBoundary/text()")[0].Value;

            GeoCoordinate nwbGeo = new GeoCoordinate(1.2, 1.2);
            return nwbGeo;
        }

        public int GetHostIdFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//HostId/text()")[0].Value);
        }

        public string GetGameStartFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x.SelectNodes("//GameStart/text()")[0].Value;
        }

        public string GetGameEndFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x.SelectNodes("//GameEnd/text()")[0].Value;
        }
    }

  
}
