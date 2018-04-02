using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IEspecialistaRepository
    {
        List<EspecialistaDomain> Listar();
        EspecialistaDomain BuscarPorId(int id);
        int Atualizar(EspecialistaDto especialistaDto, int id);
        int Deletar(int id);
    }
}