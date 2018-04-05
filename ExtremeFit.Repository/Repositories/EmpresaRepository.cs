using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApiContext _context;
        public EmpresaRepository(ApiContext context)
        {
            _context = context;
            
        }

        public int Atualizar(EmpresaDto empresaDto, int id)
        {
            EmpresaDomain empresa = _context.Empresas.FirstOrDefault(x => x.Id == id);

            if(empresa == null)
                return 404;

            empresa.NomeFantasia = empresaDto.NomeFantasia;
            empresa.RazaoSocial = empresaDto.RazaoSocial;
            empresa.CNAE = empresaDto.CNAE;
            empresa.CNPJ = empresaDto.CNPJ;

            _context.Empresas.Update(empresa);

            return _context.SaveChanges();
        }

        public EmpresaDomain BuscarPorId(int id)
        {
            EmpresaDomain empresa = _context.Empresas
                                                .Include(e => e.DadosFuncionarios)
                                                .Include(e => e.Pesquisas)
                                                    .ThenInclude(p => p.Alternativa)
                                                .Include(e => e.Relatorios)
                                                    .ThenInclude(r => r.Intensidade)
                                                .Include(e => e.Relatorios)
                                                    .ThenInclude(r => r.LocalDor)
                                                .FirstOrDefault(x => x.Id == id);

            return empresa;
        }

        public int Deletar(int id)
        {
            EmpresaDomain empresa = _context.Empresas.FirstOrDefault(x => x.Id == id);

            if(empresa == null)
                return 404;
            
            _context.Empresas.Remove(empresa);

            return _context.SaveChanges();
        }

        public int Inserir(EmpresaDto empresaDto)
        {
            var empresa = new EmpresaDomain{
                NomeFantasia = empresaDto.NomeFantasia,
                RazaoSocial = empresaDto.RazaoSocial,
                CNAE = empresaDto.CNAE,
                CNPJ = empresaDto.CNPJ
            };

            _context.Empresas.Add(empresa);

            return _context.SaveChanges();
        }

        public List<EmpresaDomain> Listar()
        {
            var lista = _context.Empresas.Include(e => e.DadosFuncionarios)
                                         .Include(e => e.Pesquisas)
                                            .ThenInclude(p => p.Alternativa)
                                         .Include(e => e.Relatorios)
                                            .ThenInclude(r => r.Intensidade)
                                         .Include(e => e.Relatorios)
                                            .ThenInclude(r => r.LocalDor)
                                         .ToList();

            return lista;
        }
    }
}