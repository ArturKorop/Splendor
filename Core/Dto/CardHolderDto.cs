namespace Core.Dto
{
    public class CardHolderDto
    {
        public CardRepositoryDto ActiveCards { get; set; }

        public CardRepositoryDto InactiveCards { get; set; }
    }
}