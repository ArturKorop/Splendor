using System;
using System.Collections.Generic;
using Core.Dto;

namespace Core.Common
{
    public class GameStorage
    {
        private static readonly Lazy<GameStorage> _instance = new Lazy<GameStorage>(()=> SerializeHelper.DeserializeFromFile<GameStorage>("Cards.xml"));

        private GameStorage()
        {
        }

        public static GameStorage Instance => _instance.Value;

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