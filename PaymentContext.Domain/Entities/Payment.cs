using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
    protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, Document document, Address address, Email email)
    {
      this.Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
      this.PaidDate = paidDate;
      this.ExpireDate = expireDate;
      this.Total = total;
      this.TotalPaid = totalPaid;
      this.Owner = owner;
      this.Document = document;
      this.Address = address;
      this.Email = email;
      
      AddNotifications(new Contract()
          .Requires()
          .IsGreaterThan(0, total, "Payment.Total", "O total não pode ser Zero")
          .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento!")
      );
    }

    public string Number { get; private set; }
      public DateTime PaidDate { get; private set; }
      public DateTime ExpireDate { get; private set; }
      public decimal Total { get; private set; }
      public decimal TotalPaid { get; private set; }
      public string Owner { get; private set;}
      public Document Document {get; private set;}
      public Address Address {get; private set;}
      public Email Email { get; private set;}

    }
}