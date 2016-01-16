using Core.Common;

namespace Core.Dto
{
    public class GemCountDto
    {
        public GemCountDto(Gem gem, int count)
        {
            Gem = gem;
            Count = count;
        }

        public GemCountDto() { }

        public Gem Gem { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Gem}:{Count}";
        }
    }
}