using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;
using Core.Entities;
using Core.Player;

namespace Core.Controllers
{
    public class GameData
    {
        public GameData(List<IPlayerConnection> connections)
        {
            InitPlayers(connections);

            PlayersRoundManager = new PlayersRoundManager(Players);

            InitGems(connections.Count);

            InitCardHolder(GameStorage.Instance);

            InitCustomers(GameStorage.Instance.Customers);

            Config = new GameConfig(connections.Count);

            GameRoundManager = new GameRoundManager(connections.Select(x=>x.Id).ToList());
        }

        public GameData(GameDto dto)
        {
            Players = dto.PlayersData.Select(x => new Player.Player(new PlayerData(x), null)).ToList();
            CardHolder = new CardHolder(dto.CardHolder);
            GemHolder = new GemHolder(dto.GemHolder);
            Customers = dto.Customers.Select(x => new Customer(x)).ToList();
            PlayersRoundManager = new PlayersRoundManager(Players);
        }

        public List<Player.Player> Players { get; private set; }

        public CardHolder CardHolder { get; private set; }

        public GemHolder GemHolder { get; private set; }

        public PlayersRoundManager PlayersRoundManager { get; private set; }

        public GameConfig Config { get; private set; }

        public List<Customer> Customers { get; private set; }

        public GameRoundManager GameRoundManager { get; private set; }

        public bool IsGameFinished { get; set; }

        private void InitPlayers(List<IPlayerConnection> connections)
        {
            Players = new List<Player.Player>();

            var i = 0;
            foreach (var playerConnection in connections)
            {
                var player = new Player.Player(new PlayerData(i), playerConnection);

                Players.Add(player);

                i++;
            }
        }

        private void InitGems(int playersCount)
        {
            GemHolder = GemRepositoryFactory.GetGemRepository(playersCount);
        }

        private void InitCustomers(List<CustomerDto> customers)
        {
            Customers = customers.Select(x => new Customer(x)).ToList();
        }

        private void InitCardHolder(GameStorage gameStorage)
        {
            var activeCardsRepository = new CardRepository(ConvertCardDtoListToCardList(gameStorage.Level1Cards),
                ConvertCardDtoListToCardList(gameStorage.Level2Cards),
                ConvertCardDtoListToCardList(gameStorage.Level3Cards));

            var inactiveCardsRepository = new CardRepository();

            CardHolder = new CardHolder(activeCardsRepository, inactiveCardsRepository);
        }

        private static List<Card> ConvertCardDtoListToCardList(List<CardDto> dto)
        {
            return dto.Select(x => new Card(x)).ToList();
        }
    }
}