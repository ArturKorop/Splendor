using System;
using System.Collections.Generic;
using System.Linq;
using Core.Controllers;
using Core.Dto;

namespace Core.Entities
{
    public class PlayerData
    {
        public PlayerData(int id)
        {
            Id = id;
            Gems = new GemRepository();
            BookedCards = new List<Card>();
            BoughtCards = new List<Card>();
            Customers = new List<Customer>();
        }

        public PlayerData(PlayerDto dto)
        {
            Id = dto.Id;
            Gems = new GemRepository(dto.Gems);
            BoughtCards = dto.BoughtCards.Select(x => new Card(x)).ToList();
            BookedCards = dto.BookedCards.Select(x => new Card(x)).ToList();
            Customers = dto.Customers.Select(x=>new Customer(x)).ToList();
        }

        public int Id { get; set; }

        public GemRepository Gems { get; private set; }

        public List<Card> BoughtCards { get; private set; } 

        public List<Card> BookedCards { get; private set; }

        public List<Customer> Customers { get; private set; } 

        public int Vp
        {
            get { return Customers.Sum(x => x.Vp) + BoughtCards.Sum(x => x.Vp); }
        }
    }

    public class Player
    {
        public PlayerData PlayerData { get; private set; }

        public IPlayerConnection Connection { get; private set; }

        public Player(PlayerData data, IPlayerConnection connection)
        {
            PlayerData = data;
            Connection = connection;
        }
    }

    public interface IPlayerConnection
    {
        int Id { get; set; }

        string Name { get; set; }


        PlayerChoice DoTurn(GameDto getGameDto);
    }

    public class DummyPlayerConnection : IPlayerConnection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerChoice DoTurn(GameDto getGameDto)
        {
            throw new NotImplementedException();
        }
    }
}