using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.Interfaces;

namespace ExtremeFit.Repository.Repositories
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly ApiContext _context;
        public PermissaoRepository(ApiContext context)
        {
            _context = context;
        }

        public List<PermissaoDomain> Listar()
        {
            var lista = _context.Permissoes.ToList();

            return lista;
        }
    }
}