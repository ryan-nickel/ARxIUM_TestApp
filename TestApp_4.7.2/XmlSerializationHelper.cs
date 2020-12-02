using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestApp_4_7_2
{
    public static class XmlSerializationHelper
    {
        public static void SerializeToXmlFile<T>(string fileName, T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"{nameof(fileName)} cannot be null or empty");
            }

            var xmlserializer = new XmlSerializer(typeof(T));
            using (var streamWriter = new StreamWriter(fileName))
            using (var writer = XmlWriter.Create(streamWriter))
            {
                xmlserializer.Serialize(writer, value);
            }
        }

        public static T DeserializeFromXmlFile<T>(string fileName) where T : class
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"{nameof(fileName)} cannot be null or empty");
            }

            using (TextReader reader = new StreamReader(fileName))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                return xmlserializer.Deserialize(reader) as T;
            }
        }
    }
}
