namespace CreditApp.Domain.Interfaces
{
    public interface IValueObject<T>
    {
        void Validate(T value);
    }
}
