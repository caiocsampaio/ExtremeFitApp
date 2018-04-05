using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class PerguntaDto
    {
        [Required]
        public string Pergunta { get; set; }

        [Required]
        public string[] Alternativas { get; set; }
    }
}