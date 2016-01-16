namespace Core.Interfaces
{
    public interface IPlayerActionProcessor<in T>
    {
        void Process(T parameters);
    }
}