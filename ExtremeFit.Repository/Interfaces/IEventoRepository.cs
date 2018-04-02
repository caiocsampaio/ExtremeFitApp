using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IEventoRepository
    {
        List<EventoDomain> Listar();

        EventoDomain BuscarPorId(int id);

        int Inserir(EventoDto eventoDto);

        int Atualizar(EventoDto eventoDto, int id);

        int Deletar(int id);
    }
}