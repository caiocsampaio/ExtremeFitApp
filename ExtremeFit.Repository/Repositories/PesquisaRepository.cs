using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class PesquisaRepository : IPesquisaRepository
    {
        private readonly ApiContext _context;
        public PesquisaRepository(ApiContext context)
        {
            _context = context;
        }

        public PesquisaDomain BuscarPorId(int id)
        {
            PesquisaDomain pesquisa = _context.Pesquisas
                                                    .Include(p => p.Alternativa)
                                                        .ThenInclude(a => a.Pergunta)
                                                    .Include(p => p.Empresa)
                                                    .FirstOrDefault(x => x.Id == id);

            return pesquisa;
        }

        public int Cadastrar(PesquisaDto pesquisaDto)
        {
            FuncionarioDomain funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == pesquisaDto.FuncionarioId);
            DadosFuncionarioDomain dadosFuncionario = _context.DadosFuncionarios.FirstOrDefault(x => x.CPF == funcionario.CPF);
            AlternativaDomain alternativa = _context.Alternativas.FirstOrDefault(x => x.Id == pesquisaDto.AlternativaId);

            var pesquisa = new PesquisaDomain{
                AlternativaId = alternativa.Id,
                EmpresaDomainId = dadosFuncionario.EmpresaId,
                Setor = dadosFuncionario.Setor
            };

            _context.Pesquisas.Add(pesquisa);

            return _context.SaveChanges();
        }

        public List<PesquisaDomain> Lista()
        {
            var lista = _context.Pesquisas
                                        .Include(p => p.Alternativa)
                                            .ThenInclude(a => a.Pergunta)
                                        .Include(p => p.Empresa)
                                        .ToList();

            return lista;
        }
    }
}