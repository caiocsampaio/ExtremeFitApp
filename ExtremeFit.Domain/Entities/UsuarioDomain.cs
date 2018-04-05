using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Domain.Entities
{
    public class UsuarioDomain : BaseDomain
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage="Email max length = 100")]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public string Rfid { get; set; }
        public string Digital { get; set; }

        public ICollection<UsuarioPermissaoDomain> Permissoes { get; set; }
        public ICollection<EspecialistaDomain> Especialistas { get; set; }
        public ICollection<FuncionarioDomain> Funcionarios { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataAlteracao { get; set; }
    }
}