using BolsaDeEmpleo.BackEnd.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.BackEnd.Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<JobOffer> Jobs { get; set; }
        public DbSet<Poster> Posters { get; set; }
    }
}