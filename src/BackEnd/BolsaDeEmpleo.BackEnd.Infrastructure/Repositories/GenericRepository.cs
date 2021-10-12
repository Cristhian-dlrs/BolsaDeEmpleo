using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Entities;
using BolsaDeEmpleo.BackEnd.Core.Interfaces;
using BolsaDeEmpleo.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.BackEnd.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DataBaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = _db;
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    query.Include(property);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Add(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }
    }
}