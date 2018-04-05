using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class AlternativaRepository : IAlternativaRepository
    {
        private readonly ApiContext _context;

        public AlternativaRepository(ApiContext context)
        {
            _context = context;
        }

        public AlternativaDomain BuscarPorId(int id)
        {
            try{
                var alternativa = _context.Alternativas
                                            .Include("Pergunta")
                                            .FirstOrDefault(x => x.Id == id);
                
                return alternativa;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public List<AlternativaDomain> Listar()
        {
            var lista = _context.Alternativas
                                    .Include(a => a.Pergunta)
                                    .ToList();

            return lista;
        }
    }
}