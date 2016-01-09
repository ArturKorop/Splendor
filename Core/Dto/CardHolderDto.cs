namespace Core.Dto
{
    public class CardHolderDto
    {
        public CardsRepositoryDto ActiveCards { get; set; }

        public CardsRepositoryDto InactiveCards { get; set; }
    }
}