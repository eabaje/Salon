using Salon.CustomerBase.Core.Entities;
using Salon.CustomerBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon.CustomerBase.Infrastructure.Data;

namespace Salon.CustomerBase.Infrastructure.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PostgresDBContext _context;
        public CustomerRepository(PostgresDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCustomer(Customer activity)
        {
            _context.Customers.Add(activity);
             return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> UpdateCustomer(Customer activity)
        {
            _context.Customers.Update(activity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = _context.Customers.FirstOrDefault(t => t.CustomerId == Guid.Parse(id));
            _context.Customers.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return await _context.Customers.FirstOrDefaultAsync(t => t.CustomerId == Guid.Parse(id));

        }
      
        public async Task<List<Customer>> GetCustomer()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
