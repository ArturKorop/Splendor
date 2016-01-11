using System.Xml.Serialization;

namespace Core.Dto
{
    public class CustomerDto
    {
        public PriceDto Price { get; set; }

        [XmlAttribute]
        public int Vp { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int Id { get; set; }
    }
}