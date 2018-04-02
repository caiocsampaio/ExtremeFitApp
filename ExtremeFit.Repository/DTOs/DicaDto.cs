using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class DicaDto
    {
        [Required(ErrorMessage="A descrição da dica deve ser fornecida")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="O ID do usuário que cadastrou a dica deve ser fornecido")]
        public int UsuarioId { get; set; }
    }
}