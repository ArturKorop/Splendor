using System.Linq;
using Core.Controllers;
using Core.Dto;

namespace Core.Entities
{
    public static class DtoFactory
    {
        public static GameDto GetGameDto(this GameController game)
        {
            var gameDto = new GameDto
            {
                Players = game.Players.Select(x => x.GetPlayerDto()).ToList(),
                Customers = game.Customers.Select(x => x.GetCustomerDto()).ToList(),
                Gems = game.Gems.GetGemRepositoryDto(),
                CardHolder = game.CardHolder.GetCardHolderDto()
            };

            return gameDto;
        }

        public static PlayerDto GetPlayerDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Gems = player.Gems.GetGemRepositoryDto(),
                BoughtCards = player.BoughtCards.Select(x => x.GetCardDto()).ToList(),
                BookedCards = player.BookedCards.Select(x=>x.GetCardDto()).ToList(),
                Customers = player.Customers.Select(x=>x.GetCustomerDto()).ToList()
            };
        }

        public static CustomerDto GetCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Price = customer.Price.GetPriceDto(),
                Vp = customer.Vp
            };
        }

        public static GemRepositoryDto GetGemRepositoryDto(this GemRepository gems)
        {
            return new GemRepositoryDto
            {
                Repository = gems.Gems.Select(x=>new GemCountDto(x.Key, x.Value)).ToList()
            };
        }

        public static CardHolderDto GetCardHolderDto(this CardHolders cardHolder)
        {
            return new CardHolderDto
            {
                ActiveCards = cardHolder.ActiveCards.GetCardRepositoryDto(),
                InactiveCards = cardHolder.InactiveCards.GetCardRepositoryDto()
            };
        }

        public static CardDto GetCardDto(this Card card)
        {
            return new CardDto
            {
                Id = card.Id,
                GemProduct = card.GemProduct,
                Level = card.Level,
                Price = card.Price.GetPriceDto(),
                Vp = card.Vp
            };
        }

        public static PriceDto GetPriceDto(this Price price)
        {
            return new PriceDto
            {
                Gems = price.Gems.Select(x => new GemCountDto(x.Key, x.Value)).ToList()
            };
        }

        public static CardRepositoryDto GetCardRepositoryDto(this CardRepository cardRepository)
        {
            return new CardRepositoryDto
            {
                Cards1Level = cardRepository.Cards1Level.Select(x=>x.GetCardDto()).ToList(),
                Cards2Level = cardRepository.Cards2Level.Select(x=>x.GetCardDto()).ToList(),
                Cards3Level = cardRepository.Cards3Level.Select(x=>x.GetCardDto()).ToList(),
            };
        }
    }
}