using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class RelatorioDto
    {
        public string Descricao { get; set; }

        [Required(ErrorMessage="O ID do local da dor deve ser fornecido")]
        public int LocalDorId { get; set; }

        [Required(ErrorMessage="O ID da intensidade da dor deve ser fornecido")]
        public int IntensidadeDorId { get; set; }

        [Required(ErrorMessage="O ID empresa deve ser fornecido")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage="O setor da empresa deve ser fornecido")]
        public string Setor { get; set; }
    }
}