using System.Collections.Generic;
using Core.Dto;

namespace Core.Common
{
    public class GameStorage
    {
        public GameStorage()
        {
            //Customers = new List<CustomerDto>
            //{
            //    new CustomerDto
            //    {
            //        Name = "Stepan",
            //        Vp = 1,
            //        Price = new PriceDto
            //        {
            //            Gems = new List<GemCountDto>
            //            {
            //                new GemCountDto(Gem.Black, 5)
            //            }
            //        }
            //    }
            //};

            //Level1Cards = new List<CardDto>
            //{
            //    new CardDto
            //    {
            //        GemProduct = Gem.Blue,
            //        Id = 45,
            //        Level = 1,
            //        Vp = 1,
            //        Price = new PriceDto
            //        {
            //            Gems = new List<GemCountDto>
            //            {
            //                new GemCountDto(Gem.Black, 5)
            //            }
            //        }
            //    }
            //};

            //Level2Cards = new List<CardDto>
            //{
            //    new CardDto
            //    {
            //        GemProduct = Gem.Blue,
            //        Id = 45,
            //        Level = 1,
            //        Vp = 1,
            //        Price = new PriceDto
            //        {
            //            Gems = new List<GemCountDto>
            //            {
            //                new GemCountDto(Gem.Black, 5)
            //            }
            //        }
            //    }
            //};

            //Level3Cards = new List<CardDto>
            //{
            //    new CardDto
            //    {
            //        GemProduct = Gem.Blue,
            //        Id = 45,
            //        Level = 1,
            //        Vp = 1,
            //        Price = new PriceDto
            //        {
            //            Gems = new List<GemCountDto>
            //            {
            //                new GemCountDto(Gem.Black, 5)
            //            }
            //        }
            //    }
            //};


        }

        public List<CustomerDto> Customers { get; set; }

        public List<CardDto> Level1Cards { get; set; }

        public List<CardDto> Level2Cards { get; set; }

        public List<CardDto> Level3Cards { get; set; }

        public string Save()
        {
            return SerializeHelper.Serialize(this);
        }
    }
}