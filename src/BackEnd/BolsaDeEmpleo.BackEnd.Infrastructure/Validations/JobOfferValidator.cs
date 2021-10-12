using BolsaDeEmpleo.BackEnd.Core.DTOs;
using FluentValidation;

namespace BolsaDeEmpleo.BackEnd.Infrastructure.Validations
{
    public class JobOfferValidator : AbstractValidator<JobOfferDTO>
    {
        public JobOfferValidator()
        {
            RuleFor(job => job.Company)
                .NotNull()
                .Length(5, 200);

            RuleFor(job => job.Position)
                .NotNull()
                .Length(5, 200);
            
            RuleFor(job => job.Location)
                .NotNull()
                .Length(5, 200);
            
            RuleFor(job => job.Category)
                .NotNull()
                .Length(5, 200);
            
            RuleFor(job => job.HowToApply)
                .NotNull()
                .Length(5, 500);
            
            RuleFor(job => job.Description)
                .NotNull()
                .Length(5, 500);
            
            RuleFor(job => job.PosterEmail)
                .NotNull()
                .EmailAddress()
                .Length(5, 200);
        }
    }
}