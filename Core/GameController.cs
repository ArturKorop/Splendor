using System;
using System.Collections.Generic;

namespace Core
{
    public class GameController
    {
        public GemsRepository Gems { get; set; }

        public CardsRepository Cards { get; set; }

        public List<PlayerController> Players { get; set; }
    }

    public class CardsRepository
    {
        public List<Card> Cards1Level { get; set; }
        public List<Card> Cards2Level { get; set; }
        public List<Card> Cards3Level { get; set; }
    }

    public class CustomersController
    {
        public List<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public Price Price { get; set; }

        public int Vp { get; set; }
    }

    public enum Gem
    {
        Blue,
        White,
        Red,
        Black,
        Green,
        Gold
    }

    public class Card
    {
        public Price Price { get; set; }

        public Gem GemProduct { get; set; }

        public int Level { get; set; }

        public int Vp { get; set; }
    }

    public class Price
    {
        public Dictionary<Gem, int> Gems { get; set; }

        public Price(int blue = 0, int white = 0, int red = 0, int black = 0, int green = 0)
        {
            Gems = new Dictionary<Gem, int>
            {
                { Gem.Blue, blue },
                { Gem.White, white },
                { Gem.Red, red },
                { Gem.Black, black },
                { Gem.Green, green },
            };
        }
    }

    public class GemsRepository
    {
        private readonly Dictionary<Gem, int> _repository;

        public GemsRepository(int gemsCount, int goldCount)
        {
            _repository = new Dictionary<Gem, int>
            {
                { Gem.Blue, gemsCount },
                { Gem.White, gemsCount },
                { Gem.Red, gemsCount },
                { Gem.Black, gemsCount },
                { Gem.Green, gemsCount },
                { Gem.Gold, goldCount },
            };
        }
    }

    public class GemsRepositoryFactory
    {
        public GemsRepository CreateGemRepository(int playersCount)
        {
            switch (playersCount)
            {
                case 2:
                    return new GemsRepository(4, 5);
                case 3:
                    return new GemsRepository(5,5);
                case 4:
                    return new GemsRepository(7,5);
                default:
                    throw new ArgumentException("playersCount should be from 2 till 4", nameof(playersCount));
            }
        }
    }

    public class PlayerController
    {
        public GemsRepository Gems { get; set; }

        public List<Card> Cards { get; set; }

        public List<Card> BookedCards { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
