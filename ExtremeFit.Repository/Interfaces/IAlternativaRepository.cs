using System.Collections.Generic;
using ExtremeFit.Domain.Entities;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IAlternativaRepository
    {
        List<AlternativaDomain> Listar();
        AlternativaDomain BuscarPorId(int id);
    }
}