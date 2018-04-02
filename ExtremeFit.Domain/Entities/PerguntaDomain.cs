using System.Collections.Generic;

namespace ExtremeFit.Domain.Entities
{
    public class PerguntaDomain : BaseDomain
    {
        public string Descricao { get; set; }

        public ICollection<AlternativaDomain> Alternativas { get; set; }
    }
}