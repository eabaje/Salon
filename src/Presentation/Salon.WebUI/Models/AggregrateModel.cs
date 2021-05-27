using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Models
{
    public class AggregrateModel
    {
       public  Appointment appointment { get; set; }

        public IEnumerable<Appointment> appointments { get; set; }

        public Order order { get; set; }

        public IEnumerable<Order>orders { get; set; }


        public Barber barber { get; set; }

        public IEnumerable<Barber> barbers { get; set; }


        public BeautySalon salon { get; set; }

        public IEnumerable<BeautySalon> salons { get; set; }

        public Booking booking { get; set; }

        public IEnumerable<Booking> bookings { get; set; }


        public Favorite favorite { get; set; }

        public IEnumerable<Favorite> favorites { get; set; }


        public Customer customer { get; set; }

        public IEnumerable<Customer> customers { get; set; }

        public PriceList pricelist { get; set; }

        public IEnumerable<PriceList> pricelists { get; set; }
    }
}
