using MongoDB.Driver;
using Salon.BarberShopBase.Infrastructure.Data.Interfaces;
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salon.BarberShopBase.Infrastructure.Settings;
using Salon.BarberShopBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IBeautySalonContext _context;
        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;
        public AppointmentRepository(IBeautySalonContext AppointmentContext, PostgresDBContext contextPostgres)
        {
            _context = AppointmentContext ?? throw new ArgumentNullException(nameof(AppointmentContext));
            _contextPostgres = contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }

        public async Task<IEnumerable<Appointment>> GetAppointment()
        {
            List<Appointment> AppointmentList = new List<Appointment>();

            return AppointmentList = 
                             await _contextPostgres
                            .Appointments
                            .ToListAsync();

           
        }

        public async Task<Appointment> GetAppointment(string id)
        {
            var Appointment = new Appointment();

            return Appointment = 
                             await _contextPostgres
                            .Appointments
                            .Where(p => p.AppointmentId == Guid.Parse(id))
                            .FirstOrDefaultAsync();

           
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentBySalon(string salonId)
        {


            List<Appointment> AppointmentList = new List<Appointment>();
            

                return await _contextPostgres
                              .Appointments
                              .Where(p => p.SalonId == salonId)
                              .ToListAsync();
          
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByCustomer(string customerId)
        {

            List<Appointment> AppointmentList = new List<Appointment>();
            



                return await _contextPostgres
                              .Appointments
                              .Where(p => p.CustomerId == customerId)
                              .ToListAsync();
           
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByBarber(string salonId, string barberId)
        {

            List<Appointment> AppointmentList = new List<Appointment>();
          

                return await _contextPostgres
                              .Appointments
                              .Where(p => p.SalonId == salonId && p.BarberId == barberId)
                              .ToListAsync();
           
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByBooked(AppointmentStatus booked, string salonId = null)
        {

            //Relational DB

            List<Appointment> AppointmentList = new List<Appointment>();

          
                return AppointmentList = (string.IsNullOrEmpty(salonId)) ? await _contextPostgres
                           .Appointments
                           .Where(p => p.Status >= booked)
                           .ToListAsync()
                           : await _contextPostgres
                           .Appointments
                           .Where(p => p.Status >= booked && p.SalonId == salonId)
                           .ToListAsync();

           

           


           

          
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime fromDate, DateTime ToDate,string salonId)
        {

            //Relational DB

            List<Appointment> AppointmentList = new List<Appointment>();
          
                return AppointmentList = (string.IsNullOrEmpty(salonId)) ? await _contextPostgres
                           .Appointments
                           .Where(p => p.AppointmentDate >= fromDate && p.AppointmentDate <= ToDate)
                           .ToListAsync()
                           : await _contextPostgres
                           .Appointments
                           .Where(p => p.AppointmentDate >= fromDate && p.AppointmentDate <= ToDate && p.SalonId == salonId)
                           .ToListAsync();


              
           
        }
        public async Task<bool> Create(Appointment appointment)
        {
           

                _contextPostgres
                            .Appointments
                            .Add(appointment);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            

        }

        public async Task<bool> Update(Appointment appointment)
        {
           

                _contextPostgres
                            .Appointments
                            .Update(appointment);

                return await _contextPostgres.SaveChangesAsync() > 0;
           
        }

        public async Task<bool> Delete(string id)
        {
           
                var entity = _contextPostgres
                            .Appointments
                            .FirstOrDefault(t => t.AppointmentId == Guid.Parse(id));

                _contextPostgres.Appointments.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
           
        }


    }
}
