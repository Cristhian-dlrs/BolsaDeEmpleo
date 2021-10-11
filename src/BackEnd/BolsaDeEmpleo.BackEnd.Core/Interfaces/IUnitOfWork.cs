using System;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Entities;

namespace BolsaDeEmpleo.BackEnd.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<JobOffer> Jobs { get; }
        
        IGenericRepository<Poster> Posters { get; }

        Task Save();
    }
}