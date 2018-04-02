using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApiContext _context;

        public BaseRepository(ApiContext context)
        {
            _context = context;
        }

        public int Atualizar(T dados)
        {
            try{
                _context.Set<T>().Update(dados);

                return _context.SaveChanges();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public T BuscarPorId(int id, string[] includes = null)
        {
            //obter o ID da classe genérica T
            var keyProperty = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];

            try{
                if(includes == null)
                    return _context.Set<T>().FirstOrDefault(e => EF.Property<int>(e, keyProperty.Name) == id);

                var query = _context.Set<T>().AsQueryable();

                foreach (var item in includes){
                    query = query.Include(item);
                }
                return query.FirstOrDefault(e => EF.Property<int>(e, keyProperty.Name) == id);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public int Deletar(T dados)
        {
            try{
                _context.Remove(dados);

                return _context.SaveChanges();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public int Deletar(int id)
        {
            try{
                var keyProperty = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];

                var T = _context.Set<T>().FirstOrDefault(e => EF.Property<int>(e, keyProperty.Name) == id);

                _context.Remove(T);

                return _context.SaveChanges();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(T dados)
        {
            try{
                _context.Set<T>().Add(dados);

                return _context.SaveChanges();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> Listar(string[] includes = null)
        {
            var query = _context.Set<T>().AsQueryable();

            try{
                if(includes == null)
                    return query.ToList();

                foreach (var item in includes){
                    query = query.Include(item);
                }
                return query.ToList();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}