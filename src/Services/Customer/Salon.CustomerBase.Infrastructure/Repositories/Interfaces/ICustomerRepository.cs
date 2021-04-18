using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Salon.CustomerBase.Core.Entities;

namespace Salon.CustomerBase.Infrastructure.Repositories.Interfaces
{
   public  interface ICustomerRepository
    {
        Task<bool> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer patient);
        Task<bool> Delete(string id);
        Task<Customer> GetCustomerById(string id);
        Task<List<Customer>> GetCustomer();
    }
}
