using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class EmpresaDto
    {
        [Required(ErrorMessage="O nome fantasia deve ser fornecido")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage="A razão social deve ser fornecida")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage="O número CNAE deve ser fornecido")]
        public string CNAE { get; set; }

        [Required(ErrorMessage="O CNPJ deve ser fornecido")]
        public string CNPJ { get; set; }
    }
}