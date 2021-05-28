using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Models
{
    public class AggregrateModel
    {
       public  AppointmentModel appointment { get; set; }

        public IEnumerable<AppointmentModel> appointments { get; set; }

        public OrderModel order { get; set; }

        public IEnumerable<OrderModel>orders { get; set; }


        public BarberModel barber { get; set; }

        public IEnumerable<BarberModel> barbers { get; set; }


        public BeautySalonModel salon { get; set; }

        public IEnumerable<BeautySalonModel> salons { get; set; }

        public BookingModel booking { get; set; }

        public IEnumerable<BookingModel> bookings { get; set; }


        public FavoriteModel favorite { get; set; }

        public IEnumerable<FavoriteModel> favorites { get; set; }


        public CustomerModel customer { get; set; }

        public IEnumerable<CustomerModel> customers { get; set; }

        public PriceListModel pricelist { get; set; }

        public IEnumerable<PriceListModel> pricelists { get; set; }


        public RatingModel rating { get; set; }

        public IEnumerable<RatingModel> ratings { get; set; }
    }
}
