using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class UnidadeSesiDto
    {
        [Required(ErrorMessage="O nome da unidade deve ser fornecido")]
        public string NomeUnidade { get; set; }

        [Required(ErrorMessage="A cidade da unidade deve ser fornecida")]
        public string Cidade { get; set; }
    }
}