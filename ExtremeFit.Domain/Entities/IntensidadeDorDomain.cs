using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class IntensidadeDorDomain : BaseDomain
    {
        [Required]
        [StringLength(15, ErrorMessage="Intensidade max length = 15")]
        public string Intensidade { get; set; }
    }
}