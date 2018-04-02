using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApiContext _context;
        public EventoRepository(ApiContext context)
        {
            _context = context;   
        }

        public int Atualizar(EventoDto eventoDto, int id)
        {
            EventoDomain evento = _context.Eventos.FirstOrDefault(x => x.Id == id);

            if(evento == null)
                return 404;

            evento.Descricao = eventoDto.Descricao;
            evento.UnidadeId = eventoDto.UnidadeId;
            evento.UsuarioId = eventoDto.UsuarioId;
            evento.DataEvento = eventoDto.DataEvento;
            evento.DataAlteracao = DateTime.Now;

            _context.Eventos.Update(evento);

            return _context.SaveChanges();
        }

        public EventoDomain BuscarPorId(int id)
        {
            EventoDomain evento = _context.Eventos
                                    .Include(e => e.Usuario)
                                    .Include(e => e.Unidade)
                                    .FirstOrDefault(x => x.Id == id);

            return evento;
        }

        public int Deletar(int id)
        {
            EventoDomain evento = _context.Eventos.FirstOrDefault(x => x.Id == id);

            if(evento == null)
                return 404;

            _context.Eventos.Remove(evento);

            return _context.SaveChanges();
        }

        public int Inserir(EventoDto eventoDto)
        {
            EventoDomain evento = new EventoDomain{
                Descricao = eventoDto.Descricao,
                UsuarioId = eventoDto.UsuarioId,
                UnidadeId = eventoDto.UnidadeId,
                DataEvento = eventoDto.DataEvento,
                DataAlteracao = DateTime.Now
            };

            _context.Eventos.Add(evento);

            return _context.SaveChanges();
        }

        public List<EventoDomain> Listar()
        {
            var lista = _context.Eventos
                                    .Include(e => e.Usuario)
                                    .Include(e => e.Unidade)
                                    .ToList();

            return lista;
        }
    }
}