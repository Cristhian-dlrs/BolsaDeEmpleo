using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeEmpleo.BackEnd.Core.Entities
{
    public class JobOffer : BaseEntity
    {
        public string Company { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string HowToApply { get; set; }
        public string PosterEmail { get; set; }

        [ForeignKey(nameof(Poster))] 
        public int PosterId { get; set; }
        public virtual Poster Poster { get; set; }
    }
}