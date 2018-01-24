using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RH.Service.Interface
{
    public interface IRepository <T> where T: class
    {
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task Insert(T entity);
        IEnumerable<T> List();
        Task Update(T entity);
    }
}