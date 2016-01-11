using System.Xml.Serialization;
using Core.Common;

namespace Core.Dto
{
    public class CardDto
    {
        public PriceDto Price { get; set; }

        [XmlAttribute]
        public Gem GemProduct { get; set; }

        [XmlAttribute]
        public int Level { get; set; }

        [XmlAttribute]
        public int Vp { get; set; }

        [XmlAttribute]
        public int Id { get; set; }
    }
}