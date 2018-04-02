using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class DicaDomain : BaseDomain
    {
        public DicaDomain()
        {
            Validacao = false;
        }
        
        [Required]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }

        [Required]
        public bool Validacao { get; set; }
    }
}