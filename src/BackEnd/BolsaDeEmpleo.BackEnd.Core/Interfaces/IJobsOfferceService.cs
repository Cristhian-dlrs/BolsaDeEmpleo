using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.DTOs;
using BolsaDeEmpleo.BackEnd.Core.Entities;

namespace BolsaDeEmpleo.BackEnd.Core.Interfaces
{
    public interface IJobsOfferceService
    {
        public Task<IEnumerable<JobOffer>> GetJobs();
        
        public Task<JobOffer> GetJob(int id);

        public Task InsertJob(JobOffer post);

        public Task<bool> UpdateJob(JobOffer post);
        
        public Task<bool> DeleteJob(int id);
    }
}