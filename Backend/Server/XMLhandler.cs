using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Server
{
    public static class XMLhandler
    {
        ///<Summary>
        /// Method for deserializing from XML to a login object.
        ///</Summary>
        public static Login DeserializeLogin(string xml) //string path = "login.xml")
        {
            Login login = new Login();

            TextReader reader = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(Login));
            login = (Login) serializer.Deserialize(reader);
            reader.Close();

            return login;
        }

        /* TEST METHOD
        public static void Serialize()
        {
            // Create an instance of Camera class.
            Login login = new Login();
            // Assing values to it’s properties
            login.Username = "John";
            login.Password = "1234";
            // Create and instance of XmlSerializer class. 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Login));
            // Create an instance of stream writer.
            TextWriter txtWriter = new StreamWriter(@"login2.xml");
            // Serialize the instance of BasicSerialization
            xmlSerializer.Serialize(txtWriter, login);
            // Close the stream writer
            txtWriter.Close();
        }*/
    }
}
