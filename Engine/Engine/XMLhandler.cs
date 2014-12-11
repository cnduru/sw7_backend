using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
// using System.Device.Location;
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

        public string GetUsernameFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x.SelectNodes("//Username/text()")[0].Value;
        }

        public string GetPasswordFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x.SelectNodes("//Password/text()")[0].Value;
        }

        public int GetUserIdFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//UserId/text()")[0].Value);
        }

        public int GetPrivacyFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//Privacy/text()")[0].Value);
        }

        public int GetNumberOfTeamsFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//NumberOfTeams/text()")[0].Value);
        }

        public GeoCoordinate GetSouthEastBoundaryFromXML(string xml) {
			XmlDocument x = new XmlDocument();
			x.LoadXml(xml);
			double seb_lat = Convert.ToDouble(x.SelectNodes("//SouthEastBoundary/Latitude/text()")[0].Value);
			double seb_lng = Convert.ToDouble(x.SelectNodes("//SouthEastBoundary/Longitude/text()")[0].Value);

			GeoCoordinate sebGeo = new GeoCoordinate(seb_lat, seb_lng);
			return sebGeo;
        }

        public GeoCoordinate GetNorthWestBoundaryFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
			double nwb_lat = Convert.ToDouble(x.SelectNodes("//NorthWestBoundary/Latitude/text()")[0].Value);
			double nwb_lng = Convert.ToDouble(x.SelectNodes("//NorthWestBoundary/Longitude/text()")[0].Value);

			GeoCoordinate nwbGeo = new GeoCoordinate(nwb_lat, nwb_lng);
            return nwbGeo;
        }

        public int GetHostIdFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//HostId/text()")[0].Value);
        }

        public GeoCoordinate GetGeoCoordinateFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            double lat = Convert.ToDouble(x.SelectNodes("//Latitude/text()")[0].Value);
            double lng = Convert.ToDouble(x.SelectNodes("//Longitude/text()")[0].Value);
            return new GeoCoordinate(lat, lng);
        }

        public int GetItemIdFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//ItemId/text()")[0].Value);
        }

        public int GetVictimFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return Convert.ToInt32(x.SelectNodes("//Victim/text()")[0].Value);
        }

        public DateTime GetGameStartFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            int year = Convert.ToInt32(x.SelectNodes("//GameStart/Year/text()")[0].Value);
            int month = Convert.ToInt32(x.SelectNodes("//GameStart/Month/text()")[0].Value);
            int day = Convert.ToInt32(x.SelectNodes("//GameStart/Day/text()")[0].Value);
            int hour = Convert.ToInt32(x.SelectNodes("//GameStart/Hour/text()")[0].Value);
            int minute = Convert.ToInt32(x.SelectNodes("//GameStart/Minute/text()")[0].Value);
            return new DateTime(year, month, day, hour, minute, 0);
        }

        public DateTime GetGameEndFromXML(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            int year = Convert.ToInt32(x.SelectNodes("//GameEnd/Year/text()")[0].Value);
            int month = Convert.ToInt32(x.SelectNodes("//GameEnd/Month/text()")[0].Value);
            int day = Convert.ToInt32(x.SelectNodes("//GameEnd/Day/text()")[0].Value);
            int hour = Convert.ToInt32(x.SelectNodes("//GameEnd/Hour/text()")[0].Value);
            int minute = Convert.ToInt32(x.SelectNodes("//GameEnd/Minute/text()")[0].Value);
            return new DateTime(year, month, day, hour, minute, 0);
        }

    }

  
}
