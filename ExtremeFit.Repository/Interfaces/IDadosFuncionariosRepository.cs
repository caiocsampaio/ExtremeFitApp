using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IDadosFuncionariosRepository
    {
        List<DadosFuncionarioDomain> Listar();

        DadosFuncionarioDomain BuscarPorId(int id);

        int Inserir(DadosFuncionarioDto dados);

        int Atualizar(DadosFuncionarioDto dados, int id);

        int Deletar(int id);
    }
}