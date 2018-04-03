using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IUnidadeSesiRepository
    {
        List<UnidadeSesiDomain> Lista();
        UnidadeSesiDomain BuscarPorId(int id);
        int Atualizar(UnidadeSesiDto unidadeSesiDto, int id);
        int Deletar(int id);
        int Cadastrar(UnidadeSesiDto unidadeSesiDto);
        ICollection<EventoDomain> ListarEventosPorId(int id);
    }
}