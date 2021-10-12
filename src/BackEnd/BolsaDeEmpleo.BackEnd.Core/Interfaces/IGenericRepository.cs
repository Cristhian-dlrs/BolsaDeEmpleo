using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Entities;

namespace BolsaDeEmpleo.BackEnd.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAll();
        
        public Task<T> Get(Expression<Func<T, bool>> expression,
            List<string> includes = null);
        
        public Task Add(T entity);

        public void Update(T entity);
        
        public Task Delete(int id);
    }
}