namespace Core.Controllers
{
    public class PlayerRoundStatus
    {
        public bool IsMainActionDone { get; set; }

        public bool IsCustomerTaken { get; set; }

        public bool IsActionFinished { get; set; }

        public void Clear()
        {
            IsMainActionDone = false;
            IsCustomerTaken = false;
            IsActionFinished = false;
        }
    }
}