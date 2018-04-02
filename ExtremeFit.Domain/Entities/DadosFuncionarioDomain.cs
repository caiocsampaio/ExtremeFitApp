using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class DadosFuncionarioDomain : BaseDomain
    {
        [Required]
        [StringLength(11, ErrorMessage="CPF max length = 11")]
        public string CPF { get; set; }

        [ForeignKey("EmpresaId")]
        public EmpresaDomain Empresa { get; set; }
        public int EmpresaId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Setor max length = 30")]
        public string Setor { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Funcao max length = 30")]
        public string Funcao { get; set; }
    }
}