using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;
using Core.Entities;

namespace Core.Controllers
{
    public class GameData
    {
        public GameData(List<IPlayerConnection> connections)
        {
            InitPlayers(connections);

            PlayersRoundManager = new PlayersRoundManager(Players);

            InitGems(connections.Count);

            InitCardHolder(GameStorage.Instance.Level1Cards,
                GameStorage.Instance.Level2Cards,
                GameStorage.Instance.Level3Cards);

            InitCustomers(GameStorage.Instance.Customers);

            Config = new GameConfig(connections.Count);
        }

        private void InitPlayers(List<IPlayerConnection> connections)
        {
            Players = new List<Player>();

            var i = 0;
            foreach (var playerConnection in connections)
            {
                var player = new Player(new PlayerData(i), playerConnection);

                Players.Add(player);

                i++;
            }
        }

        public GameData(GameDto dto)
        {
            Players = dto.PlayersData.Select(x => new Player(new PlayerData(x), null)).ToList();
            CardHolder = new CardHolder(dto.CardHolder);
            GemHolder = new GemHolder(dto.Gems);
            Customers = dto.Customers.Select(x => new Customer(x)).ToList();
            PlayersRoundManager = new PlayersRoundManager(Players);
        }

        public List<Player> Players { get; private set; }

        public CardHolder CardHolder { get; private set; }

        public GemHolder GemHolder { get; private set; }

        public PlayersRoundManager PlayersRoundManager { get; private set; }

        public GameConfig Config { get; private set; }

        public List<Customer> Customers { get; private set; }

        public bool IsGameFinished { get; set; }

        private void InitGems(int playersCount)
        {
            GemHolder = GemRepositoryFactory.GetGemRepository(playersCount);
        }

        private void InitCustomers(List<CustomerDto> customers)
        {
            Customers = customers.Select(x => new Customer(x)).ToList();
        }

        private void InitCardHolder(List<CardDto> level1Cards, List<CardDto> level2Cards, List<CardDto> level3Cards)
        {
            var activeCardsRepository = new CardRepository(ConvertCardDtoListToCardList(level1Cards),
                ConvertCardDtoListToCardList(level2Cards), ConvertCardDtoListToCardList(level3Cards));

            var inactiveCardsRepository = new CardRepository();

            CardHolder = new CardHolder(activeCardsRepository, inactiveCardsRepository);
        }

        private static List<Card> ConvertCardDtoListToCardList(List<CardDto> dto)
        {
            return dto.Select(x => new Card(x)).ToList();
        }
    }

   
}