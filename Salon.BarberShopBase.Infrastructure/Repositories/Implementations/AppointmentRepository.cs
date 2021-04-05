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
        public AppointmentRepository(IBeautySalonContext AppointmentContext)
        {
            _context = AppointmentContext ?? throw new ArgumentNullException(nameof(AppointmentContext));
        }

        public async Task<IEnumerable<Appointment>> GetAppointment()
        {
            List<Appointment> AppointmentList = new List<Appointment>();

            return AppointmentList = (_setting.IsMongoDb) ? await _context
                            .Appointments
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .Appointments
                            .ToListAsync();

           
        }

        public async Task<Appointment> GetAppointment(string id)
        {
            var Appointment = new Appointment();

            return Appointment = (_setting.IsMongoDb) ? await _context
                            .Appointments
                            .Find(p => p.AppointmentId == id)
                            .FirstOrDefaultAsync()
                            : await _contextPostgres
                            .Appointments
                            .Where(p => p.AppointmentId == id)
                            .FirstOrDefaultAsync();

           
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentBySalon(string salonId)
        {


            List<Appointment> AppointmentList = new List<Appointment>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Appointments
                              .Where(p => p.SalonId == salonId)
                              .ToListAsync();
            }
            FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.ElemMatch(p => p.SalonId, salonId);

            return await _context
                          .Appointments
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByCustomer(string customerId)
        {

            List<Appointment> AppointmentList = new List<Appointment>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Appointments
                              .Where(p => p.CustomerId == customerId)
                              .ToListAsync();
            }
            FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.Eq(p => p.CustomerId, customerId);

            return await _context
                          .Appointments
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByBarber(string salonId, string barberId)
        {

            List<Appointment> AppointmentList = new List<Appointment>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Appointments
                              .Where(p => p.SalonId == salonId && p.BarberId == barberId)
                              .ToListAsync();
            }
            FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.Where(p => p.SalonId==salonId && p.BarberId == barberId);

            return await _context
                          .Appointments
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime fromDate, DateTime ToDate,string salonId)
        {

            //Relational DB

            List<Appointment> AppointmentList = new List<Appointment>();
            if (!_setting.IsMongoDb)
            {
                return AppointmentList = (string.IsNullOrEmpty(salonId)) ? await _contextPostgres
                           .Appointments
                           .Where(p => p.AppointDate >= fromDate && p.AppointDate <= ToDate)
                           .ToListAsync()
                           : await _contextPostgres
                           .Appointments
                           .Where(p => p.AppointDate >= fromDate && p.AppointDate <= ToDate && p.SalonId == salonId)
                           .ToListAsync();


              
            }

            //NoSQL 

            FilterDefinition<Appointment> filter =string.IsNullOrEmpty(salonId)? Builders<Appointment>.Filter.Where(p => p.AppointDate >= fromDate && p.AppointDate <= ToDate):
                Builders<Appointment>.Filter.Where(p => p.AppointDate >= fromDate && p.AppointDate <= ToDate && p.SalonId== salonId)
                ;

            return await _context
                          .Appointments
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<bool> Create(Appointment appointment)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Appointments
                            .Add(appointment);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            try
            {
                await _context.Appointments.InsertOneAsync(appointment);

                return true;
            }
            catch (Exception exc) { return false; }
       //     await _context.Appointments.InsertOneAsync(appointment);

        }

        public async Task<bool> Update(Appointment appointment)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Appointments
                            .Update(appointment);

                return await _contextPostgres.SaveChangesAsync() > 0;
            }
            var updateResult = await _context
                                        .Appointments
                                        .ReplaceOneAsync(filter: g => g.AppointmentId == appointment.AppointmentId, replacement: appointment);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            if (!_setting.IsMongoDb)
            {
                var entity = _contextPostgres
                            .Appointments
                            .FirstOrDefault(t => t.AppointmentId == id);

                _contextPostgres.Appointments.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }
            FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.Eq(m => m.AppointmentId, id);
            DeleteResult deleteResult = await _context
                                                .Appointments
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


    }
}
