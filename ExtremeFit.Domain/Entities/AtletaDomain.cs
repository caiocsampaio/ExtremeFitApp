using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class AtletaDomain : BaseDomain
    {
        [Required]
        [StringLength(30, ErrorMessage="Nome max length = 30")]
        public string Nome { get; set; }

        [Required]
        [StringLength(20, ErrorMessage="Esporte max length = 20")]
        public string Esporte { get; set; }
    }
}