using System.Numerics;

namespace CreditApp.Interfaces
{
    public interface IValueObject
    {
        void Validate<T>(T value) where T : INumber<T>;
    }
}
