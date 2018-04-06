using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class DadosFuncionarioRepository : IDadosFuncionariosRepository
    {
        private readonly ApiContext _context;
        public DadosFuncionarioRepository(ApiContext context)
        {
            _context = context;
        }

        public int Atualizar(DadosFuncionarioDto dados, int id)
        {
            DadosFuncionarioDomain dadosAtuais = _context.DadosFuncionarios.FirstOrDefault(x => x.Id == id);

            if(dadosAtuais == null)
                return 404;

            dadosAtuais.CPF = dados.CPF;
            dadosAtuais.EmpresaId = dados.EmpresaId;
            dadosAtuais.Funcao = dados.Funcao;
            dadosAtuais.Setor = dados.Setor;

            _context.DadosFuncionarios.Update(dadosAtuais);
            
            return _context.SaveChanges();
        }

        public DadosFuncionarioDomain BuscarPorId(int id)
        {
            var dados = _context.DadosFuncionarios.Include(d => d.Empresa).FirstOrDefault(x => x.Id == id);

            return dados;
        }

        public int Deletar(int id)
        {
            DadosFuncionarioDomain dados = _context.DadosFuncionarios.FirstOrDefault(x => x.Id == id);

            _context.DadosFuncionarios.Remove(dados);
            
            return _context.SaveChanges();
        }

        public int Inserir(DadosFuncionarioDto dados)
        {
            if(!_context.Empresas.Any(x => x.Id == dados.EmpresaId))
                return 0;

            var dadosCadastro = new DadosFuncionarioDomain{
                CPF = dados.CPF,
                EmpresaId = dados.EmpresaId,
                Setor = dados.Setor,
                Funcao = dados.Funcao
            };

            _context.DadosFuncionarios.Add(dadosCadastro);

            return _context.SaveChanges();
        }

        public List<DadosFuncionarioDomain> Listar()
        {
            var lista = _context.DadosFuncionarios.Include(d => d.Empresa).ToList();

            return lista;
        }
    }
}