using System;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Entities;
using BolsaDeEmpleo.BackEnd.Core.Interfaces;
using BolsaDeEmpleo.BackEnd.Infrastructure.Data;

namespace BolsaDeEmpleo.BackEnd.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private  IGenericRepository<Poster> _posters;
        private  IGenericRepository<JobOffer> _jobs;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<JobOffer> Jobs => _jobs ??= new GenericRepository<JobOffer>(_context);

        public IGenericRepository<Poster> Posters => _posters ??= new GenericRepository<Poster>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}