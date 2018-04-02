using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class EspecialistaDomain : BaseDomain
    {
        [Required]
        [StringLength(50, ErrorMessage="Nome max length = 50")]
        public string Nome { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Especialidade max length = 30")]
        public string Especialidade { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}