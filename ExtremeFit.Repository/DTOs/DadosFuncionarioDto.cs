using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class DadosFuncionarioDto
    {
        [Required(ErrorMessage="O CPF deve ser fornecido")]
        public string CPF { get; set; }

        [Required(ErrorMessage="O ID da empresa deve ser fornecido")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage="O Setor deve ser fornecido")]
        public string Setor { get; set; }

        [Required(ErrorMessage="A Função deve ser fornecida")]
        public string Funcao { get; set; }
    }
}