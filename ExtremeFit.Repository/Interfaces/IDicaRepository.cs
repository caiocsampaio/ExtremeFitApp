using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IDicaRepository
    {
        List<DicaDomain> Listar();

        DicaDomain BuscarPorId(int id);

        int Inserir(DicaDto dicaDto);

        int Atualizar(DicaDto dicaDto, int id);

        int Deletar(int id);

        int Validar(ValidarDicaDto validar, int id);
    }
}