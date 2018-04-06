using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.Interfaces;

namespace ExtremeFit.Repository.Repositories
{
    public class LocalDorRepository : ILocalDorRepository
    {
        private readonly ApiContext _context;
        public LocalDorRepository(ApiContext context)
        {
            _context = context;
        }

        public List<LocalDorDomain> Listar()
        {
            var lista = _context.LocaisDores.ToList();

            return lista;
        }
    }
}