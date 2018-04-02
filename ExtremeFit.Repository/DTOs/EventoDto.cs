using System;
using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class EventoDto
    {
        [Required(ErrorMessage="A descricao deve ser fornecida")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="O ID da unidade Sesi deve ser fornecido")]
        public int UnidadeId { get; set; }

        [Required(ErrorMessage="O ID do usuário deve ser fornecido")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage="A data do evento deve ser fornecida")]
        public DateTime DataEvento { get; set; }
    }
}