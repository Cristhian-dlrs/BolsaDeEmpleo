using System.Collections.Generic;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Entities;
using BolsaDeEmpleo.BackEnd.Core.Interfaces;

namespace BolsaDeEmpleo.BackEnd.Core.Services
{
    public class JobsOfferService : IJobsOfferceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobsOfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JobOffer>> GetJobs()
        {
            return await _unitOfWork.Jobs.GetAll();
        }

        public Task<JobOffer> GetJob(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertJob(JobOffer post)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateJob(JobOffer post)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteJob(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}