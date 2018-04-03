using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class PesquisaDto
    {
        [Required(ErrorMessage="O ID da alternativa deve ser fornecido")]
        public int AlternativaId { get; set; }

        [Required(ErrorMessage="O ID do funcionario deve ser fornecido")]
        public int FuncionarioId { get; set; }
    }
}