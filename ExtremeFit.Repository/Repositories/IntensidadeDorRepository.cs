using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.Interfaces;

namespace ExtremeFit.Repository.Repositories
{
    public class IntensidadeDorRepository : IIntensidadeDorRepository
    {
        private readonly ApiContext _context;
        public IntensidadeDorRepository(ApiContext context)
        {
            _context = context;
        }

        public List<IntensidadeDorDomain> Listar()
        {
            var lista = _context.IntensidadesDores.ToList();

            return lista;
        }
    }
}