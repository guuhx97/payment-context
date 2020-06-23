using System;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(FirstName, 3, "Name.FirstName", "Nome deve conter no minimo 3 caracteres")
                .HasMaxLen(LastName, 3, "Name.LastName", "Sobrenome deve conter no minimo 3 caracteres")
                .HasMaxLen(FirstName ,40,"Name.FirstName", "Nome deve ter no maximo 40 caracteres")
                .HasMaxLen(LastName ,40,"Name.LastName", "Sobrenome deve ter no maximo 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}