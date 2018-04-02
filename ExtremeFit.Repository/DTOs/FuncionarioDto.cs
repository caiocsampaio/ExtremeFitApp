using System;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class FuncionarioDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }
        
        [Required]
        public string Sexo { get; set; }
        
        [Required]
        public double Altura { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Rfid { get; set; }
        public string Digital { get; set; }
    }
}