using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class FuncionarioUnidadeSesiDomain : BaseDomain
    {
        [ForeignKey("FuncionarioId")]
        public FuncionarioDomain Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        [ForeignKey("UnidadeSesiId")]
        public UnidadeSesiDomain Unidade { get; set; }
        public int UnidadeSesiId { get; set; }
    }
}