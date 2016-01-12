using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;
using Core.Entities;

namespace Core.Controllers
{
    public class GameController
    {
        public GameController(int playersCount)
        {
            Players = new List<Player>();

            InitGems(playersCount);

            InitCardHolder(GameStorage.Instance.Level1Cards,
                GameStorage.Instance.Level2Cards,
                GameStorage.Instance.Level3Cards);

            InitCustomers(GameStorage.Instance.Customers);
        }

        public GameController(GameDto dto)
        {
            Players = dto.Players.Select(x => new Player(x)).ToList();
            CardHolder = new CardHolder(dto.CardHolder);
            Gems = new GemRepository(dto.Gems);
            Customers = dto.Customers.Select(x => new Customer(x)).ToList();
        }

        public List<Player> Players { get; private set; }

        public CardHolder CardHolder { get; private set; }

        public GemRepository Gems { get; private set; }

        public List<Customer> Customers { get; private set; }

        private void InitGems(int playersCount)
        {
            Gems = GemRepositoryFactory.GetGemRepository(playersCount);
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

        private List<Card> ConvertCardDtoListToCardList(List<CardDto> dto)
        {
            return dto.Select(x => new Card(x)).ToList();
        }
    }
}