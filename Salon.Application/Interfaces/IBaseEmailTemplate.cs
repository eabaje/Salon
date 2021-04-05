using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Interfaces
{

    public interface IBaseEmailTemplate<T> where T : class
    {

        //T GetById<T>(int id) ;
        //List<T> List<T>() ;
      
        DbSet<T> Entities { get; }
        Task<int> SaveChangesAsync();
    }

}
