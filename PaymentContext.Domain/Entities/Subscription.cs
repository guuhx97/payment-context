using System;
using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {

    private IList<Payment> _payments;
    
    public Subscription(DateTime? expireDate)
    {
      this.CreateDate = DateTime.Now;
      this.LastUpdateDate = DateTime.Now;
      this.ExpireDate = expireDate;
      this.Active = true;
      this.Payments = new List<Payment>();
      _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active {get; private set;}
        public IReadOnlyCollection<Payment> Payments {get; private set;}
        
        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser no futuro") 
            );
            // IF VALID // SÓ ADICIONA SE FOR VÁLIDO
            _payments.Add(payment);
        }
        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }
        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }

    public class DataTime
    {
    }
}