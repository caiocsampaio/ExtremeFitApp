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
    public class EspecialistaRepository : IEspecialistaRepository
    {
        private readonly ApiContext _context;
        public EspecialistaRepository(ApiContext context)
        {
            _context = context;
        }
        public int Atualizar(EspecialistaDto especialistaDto, int id)
        {
            throw new System.NotImplementedException();
        }

        public EspecialistaDomain BuscarPorId(int id)
        {
            try{
                EspecialistaDomain especialista = _context.Especialistas.FirstOrDefault(x => x.Id == id);

                return especialista;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<EspecialistaDomain> Listar()
        {
            try{
                var lista = _context.Especialistas
                                    .Include("Usuario")
                                    .ToList();

                return lista;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
            throw new System.NotImplementedException();
        }
    }
}