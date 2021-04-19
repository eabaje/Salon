using MongoDB.Driver;
using Salon.BarberShopBase.Infrastructure.Data.Interfaces;
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salon.BarberShopBase.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Salon.BarberShopBase.Infrastructure.Data;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Implementations
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly IBeautySalonContext _context;

        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;
        public CalendarRepository(IBeautySalonContext BarberContext, IBarberDatabaseSettings setting , PostgresDBContext contextPostgres)
        {
            _context = BarberContext ?? throw new ArgumentNullException(nameof(BarberContext));

            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _contextPostgres= contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }

        public async Task<IEnumerable<Calendar>> GetCalendar()
        {
            List<Calendar> calendarList= new List<Calendar>();

            return calendarList = (_setting.IsMongoDb) ?  await _context
                            .Calendars
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .Calendars
                            .ToListAsync();




        }

        public async Task<Calendar> GetCalendar(string id)
        {
           var calendar = new Calendar();

            return calendar = (_setting.IsMongoDb) ? await _context
                            .Calendars
                            .Find(p => p.CalenderId == Guid.Parse(id))
                            .FirstOrDefaultAsync()
                            :  await _contextPostgres
                            .Calendars
                            .Where(p => p.CalenderId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Calendar>> GetCalendarBySalon(string salonId)
        {
            List<Calendar> calendarList = new List<Calendar>();
            if (!_setting.IsMongoDb)
            {
               


                return await _contextPostgres
                              .Calendars
                              .Where(p => p.SalonId== salonId)
                              .ToListAsync();
            }

            FilterDefinition<Calendar> filter = Builders<Calendar>.Filter.ElemMatch(p => p.SalonId, salonId);


            return await _context
                          .Calendars
                          .Find(filter)
                          .ToListAsync();
        }

       

        public async Task<IEnumerable<CalendarItem>> GetCalendarByBarber(string salonId, string barberId)
        {

            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .CalendarItems
                              .Where(p => p.SalonId == salonId && p.BarberId == barberId)
                              .ToListAsync();
            }
            FilterDefinition<CalendarItem> filter = Builders<CalendarItem>.Filter.Where(p => p.SalonId == salonId && p.BarberId == barberId);

            return await _context
                          .CalendarItems
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<IEnumerable<CalendarItem>> GetCalendarItemByBooked(BookedStatus booked,string salonId)
        {
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .CalendarItems
                              .Where(p => p.booked == booked && p.SalonId==salonId)
                              .ToListAsync();
            }
            FilterDefinition<CalendarItem> filter = Builders<CalendarItem>.Filter.Eq(p => p.booked, booked);

            return await _context
                          .CalendarItems
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<IEnumerable<Calendar>> GetCalendarByDate(DateTime fromDate, DateTime ToDate,string salonId=null)
        {
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Calendars
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.SalonId == salonId)
                              .ToListAsync();
            }
            FilterDefinition<Calendar> filter = string.IsNullOrEmpty(salonId) ? Builders<Calendar>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                : Builders<Calendar>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.SalonId == salonId);

            return await _context
                          .Calendars
                          .Find(filter)
                          .ToListAsync();
        }


        public async Task<IEnumerable<CalendarItem>> GetCalendarItemByDate(DateTime fromDate, DateTime ToDate, string salonId = null)
        {
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .CalendarItems
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.SalonId == salonId)
                              .ToListAsync();
            }
            FilterDefinition<CalendarItem> filter = string.IsNullOrEmpty(salonId) ? Builders<CalendarItem>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                : Builders<CalendarItem>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.SalonId == salonId);

            return await _context
                          .CalendarItems
                          .Find(filter)
                          .ToListAsync();
        }


        public async Task<bool> Create(Calendar calendar)
        {

            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Calendars
                            .Add(calendar);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }


            try {
                await _context.Calendars.InsertOneAsync(calendar);

                return true;
            }
            catch (Exception exc) { return false; }

            
        }


     
        public async Task<bool> Update(Calendar calendar)
        {
            if (!_setting.IsMongoDb)
            {



                _contextPostgres
                            .Calendars
                            .Update(calendar);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

           

            var updateResult = await _context
                                        .Calendars
                                        .ReplaceOneAsync(filter: g => g.CalenderId == calendar.CalenderId, replacement: calendar);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;


        }



        public async Task<bool> UpdateCalendarItem(CalendarItem calendar)
        {
            if (!_setting.IsMongoDb)
            {



                _contextPostgres
                            .CalendarItems
                            .Update(calendar);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }



            var updateResult = await _context
                                        .CalendarItems
                                        .ReplaceOneAsync(filter: g => g.CalenderId == calendar.CalenderId, replacement: CalendarItem);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;


        }

        public async Task<bool> Delete(string id)
        {

            if (!_setting.IsMongoDb)
            {



                var entity = _contextPostgres
                            .Calendars
                            .FirstOrDefault(t => t.CalenderId == Guid.Parse(id));
               
                _contextPostgres.Calendars.Remove(entity);
              


                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }
            FilterDefinition<Calendar> filter = Builders<Calendar>.Filter.Eq(m => m.CalenderId, Guid.Parse(id));
            DeleteResult deleteResult = await _context
                                                .Calendars
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }





        public async Task<bool> DeleteCalendarItem(string id)
        {

            if (!_setting.IsMongoDb)
            {



                var entity = _contextPostgres
                            .CalendarItems
                            .FirstOrDefault(t => t.CalenderId == Guid.Parse(id));

                _contextPostgres.CalendarItems.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }
            FilterDefinition<CalendarItem> filter = Builders<CalendarItem>.Filter.Eq(m => m.CalenderId, Guid.Parse(id));
            DeleteResult deleteResult = await _context
                                                .CalendarItems
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


      


        public async Task<bool> CreateCalendarItem(CalendarItem calendar)
        {

            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .CalendarItems
                            .Add(calendar);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }


            try
            {
                await _context.CalendarItems.InsertOneAsync(calendar);

                return true;
            }
            catch (Exception exc) { return false; }


        }


        // Create interface implemetations for the CalendarSetUp Entity


        public async Task<bool> CreateCalendarSetUp(CalendarSetUp calendar)
        {

           try
            {

                _contextPostgres
                            .CalendarSetUps
                            .Add(calendar);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

         
            catch (Exception exc) { return false; }


        }



        public async Task<bool> UpdateCalendarSetUp(CalendarSetUp calendar)
        {

            try
            {

                _contextPostgres
                            .CalendarSetUps
                            .Update(calendar);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }


            catch (Exception exc) { return false; }


        }


        public async Task<IEnumerable<CalendarSetUp>> GetCalendarSetUpByDate(DateTime fromDate, DateTime ToDate, string salonId)
        {
            try
            {
               

                return await _contextPostgres
                              .CalendarSetUps
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.SalonId == salonId)
                              .ToListAsync();
            }
            


            catch (Exception exc) { return false; }
        }


        public async Task<bool> IsCalendarSetUpManual(string salonId)
        {
            try
            {
                

               var rows =  await _contextPostgres
                              .CalendarSetUps
                              .Where(p => p.IsManual==true  && p.SalonId == salonId)
                              .ToListAsync();
                if(rows.Any) return true


                    return false;

            }



            catch (Exception exc) { return false; }
        }


        /////////******    ********/////
    }
}
