using Core.Dto;

namespace Core.Entities
{
    public class CardHolder
    {
        public ActiveCardRepository ActiveCards { get; } 

        public InactiveCardRepository InactiveCards { get; } 
       
        public CardHolder(CardHolderDto dto)
        {
            ActiveCards = new ActiveCardRepository(dto.ActiveCards);
            InactiveCards = new InactiveCardRepository(dto.InactiveCards);
        }

        public CardHolder()
        {
            ActiveCards = new ActiveCardRepository();
            InactiveCards = new InactiveCardRepository();
        }

        public CardHolder(ActiveCardRepository activeCards, InactiveCardRepository inactiveCards)
        {
            ActiveCards = activeCards;
            InactiveCards = inactiveCards;
        }
    }
}