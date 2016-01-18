using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Controllers;
using Core.Dto;
using Core.Players;

namespace Core.Entities
{
    public class GameData
    {
        public GameData(List<IPlayerConnection> connections)
        {
            InitPlayers(connections);

            PlayersCircularManager = new PlayersCircularManager(Players);

            InitGems(connections.Count);

            InitCardHolder(GameStorage.Instance);

            InitCustomers(GameStorage.Instance.Customers);

            Config = new GameConfig(connections.Count);
        }

        public GameData(GameDto dto)
        {
            Players = dto.PlayersData.Select(x => new Player(new PlayerData(x), null)).ToList();
            CardHolder = new CardHolder(dto.CardHolder);
            GemHolder = new GemHolder(dto.GemHolder);
            Customers = dto.Customers.Select(x => new Customer(x)).ToList();
            PlayersCircularManager = new PlayersCircularManager(Players);
        }

        public List<Player> Players { get; private set; }

        public CardHolder CardHolder { get; private set; }

        public GemHolder GemHolder { get; private set; }

        public PlayersCircularManager PlayersCircularManager { get; private set; }

        public GameConfig Config { get; private set; }

        public List<Customer> Customers { get; private set; }

        public bool IsGameFinished { get; set; }

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
            var level1 = ConvertCardDtoListToCardList(gameStorage.Level1Cards);
            var level2 = ConvertCardDtoListToCardList(gameStorage.Level2Cards);
            var level3 = ConvertCardDtoListToCardList(gameStorage.Level3Cards);

            var shuffler = new Shuffler<Card>();

            var shuffle1 = shuffler.Shuffle(level1);
            var shuffle2 = shuffler.Shuffle(level2);
            var shuffle3 = shuffler.Shuffle(level3);

            var inactiveCardsRepository = new InactiveCardRepository(shuffle1, shuffle2, shuffle3);

            var activeCardsRepository = new ActiveCardRepository();

            CardHolder = new CardHolder(activeCardsRepository, inactiveCardsRepository);


        }

        private static List<Card> ConvertCardDtoListToCardList(List<CardDto> dto)
        {
            return dto.Select(x => new Card(x)).ToList();
        }
    }
}