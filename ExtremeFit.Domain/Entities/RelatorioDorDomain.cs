using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class RelatorioDorDomain : BaseDomain
    {
        [Required]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }

        [Required]
        [ForeignKey("IntensidadeDorId")]
        public IntensidadeDorDomain Intensidade { get; set; }
        public int IntensidadeDorId { get; set; }

        [Required]
        [ForeignKey("LocalDorId")]
        public LocalDorDomain LocalDor { get; set; }
        public int LocalDorId { get; set; }

        [Required]
        [ForeignKey("EmpresaId")]
        public EmpresaDomain Empresa { get; set; }
        public int EmpresaId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="Setor max length = 30")]
        public string Setor { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataAlteracao { get; set; }
    }
}