namespace Core.Interfaces
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
}