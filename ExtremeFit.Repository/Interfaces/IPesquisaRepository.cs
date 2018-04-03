using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IPesquisaRepository
    {
        List<PesquisaDomain> Lista();

        PesquisaDomain BuscarPorId(int id);

        int Cadastrar(PesquisaDto pesquisaDto);
    }
}