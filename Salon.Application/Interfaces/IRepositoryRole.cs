using Salon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.Interfaces
{
   

        public interface IRepositoryRole
        {
            T GetById<T>(int id) where T : BaseEntity;
            List<T> List<T>() where T : BaseEntity;
            T Add<T>(T entity) where T : BaseEntity;
            void Update<T>(T entity) where T : BaseEntity;
            void Delete<T>(T entity) where T : BaseEntity;
        }
    }
