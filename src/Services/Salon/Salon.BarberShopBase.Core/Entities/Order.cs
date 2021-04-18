using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }

        public string OrderStatus { get; set; }

       
    }

    public enum PaymentMethod
    {
        CreditCard = 1,
        DebitCard = 2,
        Paypal = 3
    }
}
