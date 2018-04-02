using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class LocalDorDomain : BaseDomain
    {
        [Required]
        [StringLength(20, ErrorMessage="LocalDor max length = 20")]
        public string LocalDor { get; set; }
    }
}