using System.IO;
using System.Xml.Serialization;

namespace Remont
{
    public static class RideDtoHelper
    {
        private static readonly XmlSerializer Xml = new XmlSerializer(typeof(OrderRequestDto));

        public static void WriteToFile(string fileName, OrderRequestDto data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xml.Serialize(fileStream, data);
            }
        }

        public static OrderRequestDto LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (OrderRequestDto)Xml.Deserialize(fileStream);
            }
        }

        public static OrderRequestDto LoadFromStream(Stream file)
        {
            return (OrderRequestDto)Xml.Deserialize(file);
        }
    }
}