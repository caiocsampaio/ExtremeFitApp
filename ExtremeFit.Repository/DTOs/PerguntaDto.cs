using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class PerguntaDto
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public string[] Alternativas { get; set; }
    }
}