using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestApp
{
    public static class XmlSerializationHelper
    {
        public static void SerializeToXmlFile<T>(string fileName, T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var xmlserializer = new XmlSerializer(typeof(T));
            using var streamWriter = new StreamWriter(fileName);
            using var writer = XmlWriter.Create(streamWriter);
            xmlserializer.Serialize(writer, value);
        }

        public static T DeserializeFromXmlFile<T>(string FileName) where T : class
        {
            using TextReader reader = new StreamReader(FileName);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return ser.Deserialize(reader) as T;
        }
    }
}
