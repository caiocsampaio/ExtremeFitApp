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

        [Required]
        [StringLength(30, ErrorMessage="Setor max length = 30")]
        public string Setor { get; set; }

        [ForeignKey("EmpresaDomainId")]
        public EmpresaDomain Empresa { get; set; }
        public int EmpresaDomainId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataAlteracao { get; set; }
    }
}