using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IRelatorioRepository
    {
        List<RelatorioDorDomain> Listar();
        RelatorioDorDomain BuscarPorId(int id);
        int Cadastrar(RelatorioDto relatorioDto);
        int Atualizar(RelatorioDto relatorioDto, int id);
        int Deletar(int id);        
    }
}