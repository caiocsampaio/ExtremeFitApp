using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        FuncionarioDomain BuscarPorId(int id);
        
        int Atualizar(FuncionarioDto funcionarioDto, int id);

        int Deletar(int id);
        
        int AtualizarUnidades(UnidadesDto unidadesDto, int id);
    }
}