using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class UnidadeFavoritaDomain : BaseDomain
    {
        [Required]
        [StringLength(50, ErrorMessage="NomeUnidade max length = 50")]
        public string NomeUnidade { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Cidade max length = 30")]
        public string Cidade { get; set; }

        public ICollection<EventoDomain> Eventos { get; set; }

        public ICollection<FuncionarioUnidadeSesiDomain> Funcionarios { get; set; }
    }
}