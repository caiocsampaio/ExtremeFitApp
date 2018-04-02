using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class FuncionarioDomain : BaseDomain
    {
        [Required]
        [StringLength(50, ErrorMessage="Nome max length = 50")]
        public string Nome { get; set; }

        [Required]
        [StringLength(11, ErrorMessage="CPF max length = 11")]
        public string CPF { get; set; }

        [Required]
        [StringLength(15, ErrorMessage="Sexo max length = 15")]
        public string Sexo { get; set; }

        [Range(50.00, 230.00, ErrorMessage="Altura range: 50-230cm")]
        public double Altura { get; set; }

        [Range(40, 300, ErrorMessage="Peso range: 40-300kg")]
        public double Peso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }

        public ICollection<FuncionarioUnidadeSesiDomain> UnidadesFavoritas { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataAlteracao { get; set; }
    }
}