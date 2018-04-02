using ExtremeFit.Domain.Entities;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IAlternativaRepository
    {
         AlternativaDomain BuscarPorId(int id);
    }
}