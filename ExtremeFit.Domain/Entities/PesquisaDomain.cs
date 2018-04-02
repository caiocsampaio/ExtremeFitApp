using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class PesquisaDomain : BaseDomain
    {
        [ForeignKey("AlternativaId")]
        public AlternativaDomain Alternativa { get; set; }
        public int AlternativaId { get; set; }

        public string Pergunta { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Setor max length = 30")]
        public string Setor { get; set; }

        [ForeignKey("EmpresaId")]
        public EmpresaDomain Empresa { get; set; }
        public int EmpresaId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
    }
}