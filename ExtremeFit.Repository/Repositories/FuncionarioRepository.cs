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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApiContext _context;

        public FuncionarioRepository(ApiContext context)
        {
            _context = context;
        }
        
        public int Atualizar(FuncionarioDto funcionarioDto, int id)
        {
            try{
                //achar o funcionario
                FuncionarioDomain funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                //atualizar os dados com os fornecidos
                funcionario.Nome = funcionarioDto.Nome;
                funcionario.CPF = funcionarioDto.CPF;
                funcionario.Altura = funcionarioDto.Altura;
                funcionario.Peso = funcionarioDto.Peso;
                funcionario.DataNascimento = funcionarioDto.DataNascimento;
                funcionario.Sexo = funcionarioDto.Sexo;

                _context.Funcionarios.Update(funcionario);

                //achar usuario relacionado
                UsuarioDomain usuario = _context.Usuarios.FirstOrDefault(x => x.Id == funcionario.UsuarioId);
                UsuarioDto usuarioDto = new UsuarioDto{
                    Email = funcionarioDto.Email,
                    Senha = funcionarioDto.Senha
                };

                var novoUsuario = new AuthRepository(_context).CriarUsuario(usuarioDto);
                usuario.Email = novoUsuario.Email;
                usuario.PasswordHash = novoUsuario.PasswordHash;
                usuario.PasswordSalt = novoUsuario.PasswordSalt;
                usuario.DataAlteracao = DateTime.Now;

                _context.Usuarios.Update(usuario);

                return _context.SaveChanges();
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
            throw new System.NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            try{
                FuncionarioDomain funcionario = _context.Funcionarios
                                                        .Include(f => f.Usuario)
                                                            .ThenInclude(u => u.Permissoes)
                                                        .Include(f => f.UnidadesFavoritas)
                                                        .FirstOrDefault(x => x.Id == id);

                return funcionario;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int Deletar(int id)
        {
            try{
                //encontrar funcionario pelo id
                FuncionarioDomain funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                UsuarioDomain usuario = _context.Usuarios.FirstOrDefault(y => y.Id == funcionario.UsuarioId);

                //remover funcionario e usuario
                _context.Funcionarios.Remove(funcionario);
                _context.Usuarios.Remove(usuario);
                
                return _context.SaveChanges();
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
            throw new System.NotImplementedException();
        }

        public List<FuncionarioDomain> Listar()
        {
            try{
                var lista = _context.Funcionarios
                                    .Include(f => f.Usuario)
                                        .ThenInclude(u => u.Permissoes)
                                    .Include(f => f.UnidadesFavoritas)
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