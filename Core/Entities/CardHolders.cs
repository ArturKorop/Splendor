using Core.Dto;

namespace Core.Entities
{
    public class CardHolders
    {
        public CardRepository ActiveCards { get; } 

        public CardRepository InactiveCards { get; } 
       
        public CardHolders(CardHolderDto dto)
        {
            ActiveCards = new CardRepository(dto.ActiveCards);
            InactiveCards = new CardRepository(dto.InactiveCards);
        }

        public CardHolders()
        {
            ActiveCards = new CardRepository();
            InactiveCards = new CardRepository();
        }
    }
}