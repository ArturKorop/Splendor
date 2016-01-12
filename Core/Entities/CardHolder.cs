using Core.Dto;

namespace Core.Entities
{
    public class CardHolder
    {
        public CardRepository ActiveCards { get; } 

        public CardRepository InactiveCards { get; } 
       
        public CardHolder(CardHolderDto dto)
        {
            ActiveCards = new CardRepository(dto.ActiveCards);
            InactiveCards = new CardRepository(dto.InactiveCards);
        }

        public CardHolder()
        {
            ActiveCards = new CardRepository();
            InactiveCards = new CardRepository();
        }

        public CardHolder(CardRepository activeCards, CardRepository inactiveCards)
        {
            ActiveCards = activeCards;
            InactiveCards = inactiveCards;
        }
    }
}