using System.Collections.Generic;

namespace BolsaDeEmpleo.BackEnd.Core.Entities
{
    public class Poster : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public virtual IEnumerable<JobOffer> PostedJobs { get; set; } 
    }
}