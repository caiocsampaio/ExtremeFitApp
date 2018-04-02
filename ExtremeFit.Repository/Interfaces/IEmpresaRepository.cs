using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IEmpresaRepository
    {
        List<EmpresaDomain> Listar();

        EmpresaDomain BuscarPorId(int id);

        int Inserir(EmpresaDto empresaDto);

        int Atualizar(EmpresaDto empresaDto, int id);

        int Deletar(int id);
    }
}