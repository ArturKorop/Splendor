using System;
using System.IO;
using System.Xml.Serialization;

namespace Core.Common
{
    public static class SerializeHelper
    {
        public static string Serialize<T>(T source)
        {
            var serializer = new XmlSerializer(source.GetType());

            using(StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, source);

                return writer.ToString();
            }
        }

        public static T Deserialize<T>(string source)
        {
            var serializer = new XmlSerializer(typeof(T));

            using(TextReader reader = new StringReader(source))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static T DeserializeFromFile<T>(string path)
        {
            var source = File.ReadAllText(path);

            return Deserialize<T>(source);
        }
    }
}
