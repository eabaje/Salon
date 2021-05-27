
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.WebUI.Models
{
    public class Order 
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
