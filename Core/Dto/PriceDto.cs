using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Core.Common;

namespace Core.Dto
{
    public class PriceDto : IXmlSerializable
    {
        public List<GemCountDto> Gems { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Gems = new List<GemCountDto>();
            foreach (var gem in Enum.GetValues(typeof (Gem)).Cast<Gem>())
            {
                reader.MoveToContent();
                var gemCountStr = reader.GetAttribute(gem.ToString());
                if (gemCountStr != null)
                {
                    var gemCount = int.Parse(gemCountStr);
                    if (gemCount > 0)
                    {
                        Gems.Add(new GemCountDto(gem, gemCount));
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var gem in Enum.GetValues(typeof (Gem)).Cast<Gem>())
            {
                AddGemCount(writer, gem);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var gemCountDto in Gems)
            {
                builder.Append(gemCountDto + " ");
            }

            return builder.ToString();
        }

        private void AddGemCount(XmlWriter writer, Gem gem)
        {
            var gemCount = Gems.SingleOrDefault(x => x.Gem == gem)?.Count ?? 0;
            writer.WriteAttributeString(gem.ToString(), gemCount.ToString());
        }
    }
}