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
            EspecialistaDomain especialista = _context.Especialistas.FirstOrDefault(x => x.Id == id);

            // atualizar dados
            especialista.Nome = especialistaDto.Nome;
            especialista.Especialidade = especialistaDto.Especialidade;

            _context.Especialistas.Update(especialista);

            if(!string.IsNullOrEmpty(especialistaDto.Email) && !string.IsNullOrEmpty(especialistaDto.Senha)){

                 //achar usuario relacionado
                UsuarioDomain usuario = _context.Usuarios.FirstOrDefault(x => x.Id == especialista.UsuarioId);
                UsuarioDto usuarioDto = new UsuarioDto{
                    Email = especialistaDto.Email,
                    Senha = especialistaDto.Senha
                };

                var novoUsuario = new AuthRepository(_context).CriarUsuario(usuarioDto);
                usuario.Email = novoUsuario.Email;
                usuario.PasswordHash = novoUsuario.PasswordHash;
                usuario.PasswordSalt = novoUsuario.PasswordSalt;
                usuario.DataAlteracao = DateTime.Now;

                _context.Usuarios.Update(usuario);
            }
            
            return _context.SaveChanges();
        }

        public EspecialistaDomain BuscarPorId(int id)
        {
            try{
                EspecialistaDomain especialista = _context.Especialistas
                                                            .Include(e => e.Usuario)
                                                                .ThenInclude(u => u.Permissoes)
                                                                    .ThenInclude(p => p.Permissao)
                                                            .FirstOrDefault(x => x.Id == id);

                return especialista;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int Deletar(int id)
        {
            //encontrar funcionario pelo id
            EspecialistaDomain especialista = _context.Especialistas.FirstOrDefault(x => x.Id == id);
            UsuarioDomain usuario = _context.Usuarios.FirstOrDefault(y => y.Id == especialista.UsuarioId);

            //remover funcionario e usuario
            _context.Especialistas.Remove(especialista);
            _context.Usuarios.Remove(usuario);
            
            return _context.SaveChanges();
        }

        public List<EspecialistaDomain> Listar()
        {
            try{
                var lista = _context.Especialistas
                                    .Include(e => e.Usuario)
                                        .ThenInclude(u => u.Permissoes)
                                            .ThenInclude(p => p.Permissao)
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