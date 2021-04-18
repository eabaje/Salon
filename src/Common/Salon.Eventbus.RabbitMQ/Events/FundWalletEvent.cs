using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Eventbus.RabbitMQ.Events
{
   public class FundWalletEvent
    {
        public Guid Id { get; set; }
        public decimal WalletFund { get; set; }
        public string CustomerId { get; set; }  
        public string PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public string Comments { get; set; }
    }
}
