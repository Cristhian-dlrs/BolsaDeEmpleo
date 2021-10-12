using AutoMapper;
using BolsaDeEmpleo.BackEnd.Core.DTOs;
using BolsaDeEmpleo.BackEnd.Core.Entities;

namespace BolsaDeEmpleo.BackEnd.Infrastructure.Mappings
{
    public class AutomaperProfile : Profile
    {
        public AutomaperProfile()
        {
            CreateMap<JobOffer, JobOfferDTO>();
        }
    }
}