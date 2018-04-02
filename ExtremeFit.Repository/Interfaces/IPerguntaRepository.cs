using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IPerguntaRepository
    {
        List<PerguntaDomain> Listar();

        PerguntaDomain BuscarPorId(int id);
        
        int Atualizar(PerguntaDto perguntaDto, int id);

        int Inserir(PerguntaDto perguntaDto);

        int Deletar(int id);
    }
}