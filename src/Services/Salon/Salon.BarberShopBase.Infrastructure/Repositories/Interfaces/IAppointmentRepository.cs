using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointment();
        Task<Appointment> GetAppointment(string id);
        Task<IEnumerable<Appointment>> GetAppointmentBySalon(string salonId);

        Task<IEnumerable<Appointment>> GetAppointmentByCustomer(string customerId);

        Task<IEnumerable<Appointment>> GetAppointmentByBarber(string salonId,string barberId);
        Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime fromDate, DateTime toDate,string salonId=null);

        //  Task<IEnumerable<Appointment>> GetBeautySalonByLocation(string LocationName);

        Task<bool> Create(Appointment appointment);
        Task<bool> Update(Appointment appointment);
        Task<bool> Delete(string id);
    }
}
