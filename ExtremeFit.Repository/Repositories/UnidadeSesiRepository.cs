using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class UnidadeSesiRepository : IUnidadeSesiRepository
    {
        private readonly ApiContext _context;
        public UnidadeSesiRepository(ApiContext context)
        {
            _context = context;
        }

        public int Atualizar(UnidadeSesiDto unidadeSesiDto, int id)
        {
            UnidadeSesiDomain unidade = _context.UnidadesSesi.FirstOrDefault(x => x.Id == id);

            if(unidade == null)
                return 404;
            
            unidade.NomeUnidade = unidadeSesiDto.NomeUnidade;
            unidade.Cidade = unidadeSesiDto.Cidade;

            _context.UnidadesSesi.Update(unidade);

            return _context.SaveChanges();
        }

        public UnidadeSesiDomain BuscarPorId(int id)
        {
            UnidadeSesiDomain unidade = _context.UnidadesSesi
                                                    .Include(u => u.Eventos)
                                                    .Include(u => u.Funcionarios)
                                                        .ThenInclude(f => f.Funcionario)
                                                    .FirstOrDefault(x => x.Id == id);

            return unidade;
        }

        public int Cadastrar(UnidadeSesiDto unidadeSesiDto)
        {
            var unidade = new UnidadeSesiDomain{
                NomeUnidade = unidadeSesiDto.NomeUnidade,
                Cidade = unidadeSesiDto.Cidade
            };

            _context.UnidadesSesi.Add(unidade);

            return _context.SaveChanges();
        }

        public int Deletar(int id)
        {
            UnidadeSesiDomain unidade = _context.UnidadesSesi.FirstOrDefault(x => x.Id == id);

            _context.UnidadesSesi.Remove(unidade);

            return _context.SaveChanges();
        }

        public List<UnidadeSesiDomain> Lista()
        {
            var lista = _context.UnidadesSesi
                                        .Include(u => u.Eventos)
                                        .Include(u => u.Funcionarios)
                                        .ToList();

            return lista;
        }

        public ICollection<EventoDomain> ListarEventosPorId(int id)
        {
            var eventos = _context.Eventos
                                        .Include(e => e.Unidade)
                                        .Where(x => x.UnidadeFavoritaId == id).ToList();

            return eventos;
        }
    }
}