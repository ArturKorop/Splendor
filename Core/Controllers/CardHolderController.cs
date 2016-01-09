using Core.Dto;

namespace Core.Controllers
{
    public class CardHolderController
    {
        public CardRepositoryController ActiveCards { get; } 

        public CardRepositoryController InactiveCards { get; } 
       
        public CardHolderController(CardHolderDto dto)
        {
            ActiveCards = new CardRepositoryController(dto.ActiveCards);
            InactiveCards = new CardRepositoryController(dto.InactiveCards);
        }

        public CardHolderController()
        {
            ActiveCards = new CardRepositoryController();
            InactiveCards = new CardRepositoryController();
        }
    }
}