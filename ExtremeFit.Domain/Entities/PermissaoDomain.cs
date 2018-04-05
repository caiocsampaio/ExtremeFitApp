using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class PermissaoDomain : BaseDomain
    {
        [Required]
        [StringLength(20, ErrorMessage="NomePermissao max length = 20")]
        public string Permissao { get; set; }
    }
}