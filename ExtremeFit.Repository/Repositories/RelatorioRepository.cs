using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ApiContext _context;
        public RelatorioRepository(ApiContext context)
        {
            _context = context;
        }

        public int Atualizar(RelatorioDto relatorioDto, int id)
        {
            var relatorio = _context.Relatorios.FirstOrDefault(x => x.Id == id);

            if(relatorio == null)
                return 404;

            relatorio.Descricao = relatorioDto.Descricao;
            relatorio.LocalDorId = relatorioDto.LocalDorId;
            relatorio.IntensidadeDorId = relatorioDto.IntensidadeDorId;
            relatorio.Setor = relatorioDto.Setor;

            _context.Relatorios.Update(relatorio);

            return _context.SaveChanges();
        }

        public RelatorioDorDomain BuscarPorId(int id)
        {
            RelatorioDorDomain relatorio = _context.Relatorios
                                                        .Include(r => r.LocalDor)
                                                        .Include(r => r.Intensidade)
                                                        .Include(r => r.Empresa)
                                                        .FirstOrDefault(x => x.Id == id);
            
            return relatorio;
        }

        public int Cadastrar(RelatorioDto relatorioDto)
        {
            var relatorio = new RelatorioDorDomain{
                Descricao = relatorioDto.Descricao,
                LocalDorId = relatorioDto.LocalDorId,
                IntensidadeDorId = relatorioDto.IntensidadeDorId,
                Setor = relatorioDto.Setor
            };

            _context.Relatorios.Add(relatorio);

            return _context.SaveChanges();
        }

        public int Deletar(int id)
        {
            var relatorio = _context.Relatorios.FirstOrDefault(x => x.Id == id);

            _context.Relatorios.Remove(relatorio);

            return _context.SaveChanges();
        }

        public List<RelatorioDorDomain> Listar()
        {
            var lista = _context.Relatorios
                                            .Include(r => r.LocalDor)
                                            .Include(r => r.Intensidade)
                                            .Include(r => r.Empresa)
                                            .ToList();

            return lista;
        }
    }
}