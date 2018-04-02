using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class EmpresaDomain : BaseDomain
    {
        [Required]
        [StringLength(40, ErrorMessage="NomeFantasia max length = 40")]
        public string NomeFantasia { get; set; }

        [Required]
        [StringLength(40, ErrorMessage="RazaoSocial max length = 40")]
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(9)]
        public string CNAE { get; set; }
        
        [Required]
        [StringLength(14, ErrorMessage="CNPJ max length = 14")]
        public string CNPJ { get; set; }

        public ICollection<DadosFuncionarioDomain> DadosFuncionarios { get; set; }

        public ICollection<RelatorioDorDomain> Relatorios { get; set; }

        public ICollection<PesquisaDomain> Pesquisas { get; set; }
    }
}