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
    public class DicaRepository : IDicaRepository
    {
        private readonly ApiContext _context;
        public DicaRepository(ApiContext context)
        {
            _context = context;
            
        }
        public int Atualizar(DicaDto dicaDto, int id)
        {
            DicaDomain dica = _context.Dicas.FirstOrDefault(x => x.Id == id);

            dica.Descricao = dicaDto.Descricao;
            dica.UsuarioId = dicaDto.UsuarioId;
            dica.DataAlteracao = DateTime.Now;

            _context.Dicas.Update(dica);

            return _context.SaveChanges();
        }

        public DicaDomain BuscarPorId(int id)
        {
            DicaDomain dica = _context.Dicas
                                        .Include("Usuario")
                                            .Include("Usuario.Especialistas")
                                            .Include("Usuario.Funcionarios")
                                        .FirstOrDefault(x => x.Id == id);

            return dica;
        }

        public int Deletar(int id)
        {
            DicaDomain dica = _context.Dicas.FirstOrDefault(x => x.Id == id);

            _context.Dicas.Remove(dica);

            return _context.SaveChanges();
        }

        public int Inserir(DicaDto dicaDto)
        {
            var dica = new DicaDomain{
                Descricao = dicaDto.Descricao,
                UsuarioId = dicaDto.UsuarioId
            };

            _context.Dicas.Add(dica);

            return _context.SaveChanges();
        }

        public List<DicaDomain> Listar()
        {
            var lista = _context.Dicas
                                    .Include("Usuario")
                                        .Include("Usuario.Especialistas")
                                        .Include("Usuario.Funcionarios")
                                    .ToList();

            return lista;
        }

        public int Validar(ValidarDicaDto validar, int id)
        {
            DicaDomain dica = _context.Dicas.FirstOrDefault(x => x.Id == id);

            dica.Validacao = validar.Valido;

            _context.Dicas.Update(dica);

            return _context.SaveChanges();
        }
    }
}