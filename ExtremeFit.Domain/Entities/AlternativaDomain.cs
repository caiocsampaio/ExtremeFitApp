using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeFit.Domain.Entities
{
    public class AlternativaDomain : BaseDomain
    {
        public string Resposta { get; set; }

        [ForeignKey("PerguntaId")]
        public PerguntaDomain Pergunta { get; set; }
        public int PerguntaId { get; set; }
    }
}