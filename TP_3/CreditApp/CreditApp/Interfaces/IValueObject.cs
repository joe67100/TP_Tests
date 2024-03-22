﻿namespace CreditApp.Interfaces
{
    public interface IValueObject<T>
    {
        void Validate(T value);
    }
}
