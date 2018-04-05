using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace ExtremeFit.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiContext _context;
        public AuthRepository(ApiContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Cadastro de novo funcionário
        /// </summary>
        /// <param name="funcionarioDto">informações de funcionário e login</param>
        /// <returns>FuncionarioDomain</returns>
        public FuncionarioDomain CadastrarFuncionario(FuncionarioDto funcionarioDto)
        {
            try{
                //criar UsuarioDto e criar UsuarioDomain com senha hash
                var usuarioDto = new UsuarioDto{
                    Email = funcionarioDto.Email,
                    Senha = funcionarioDto.Senha,
                    Rfid = funcionarioDto.Rfid,
                    Digital = funcionarioDto.Digital
                };

                UsuarioDomain usuario = CriarUsuario(usuarioDto);
                //inserir no banco
                _context.Usuarios.Add(usuario);

                //criar e inserir FuncionarioDomain no banco
                FuncionarioDomain funcionario = new FuncionarioDomain{
                    Nome = funcionarioDto.Nome,
                    CPF = funcionarioDto.CPF,
                    Sexo = funcionarioDto.Sexo,
                    Altura = funcionarioDto.Altura,
                    Peso = funcionarioDto.Peso,
                    DataNascimento = funcionarioDto.DataNascimento,
                    DataAlteracao = DateTime.Now,
                    Usuario = usuario
                };
                _context.Funcionarios.Add(funcionario);

                //salvar alterações
                _context.SaveChanges();
                    
                //retornar funcionário com include de usuário
                return funcionario;
           }
           catch(Exception e){
               throw new Exception(e.Message);
           }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="especialistaDto"></param>
        /// <returns></returns>
        public EspecialistaDomain CadastrarEspecialista(EspecialistaDto especialistaDto)
        {
            try{
                //criar UsuarioDto e criar UsuarioDomain com senha hash
                var usuarioDto = new UsuarioDto{
                    Email = especialistaDto.Email,
                    Senha = especialistaDto.Senha
                };

                UsuarioDomain usuario = CriarUsuario(usuarioDto);

                //inserir no banco
                _context.Usuarios.Add(usuario);

                //criar e inserir EspecialistaDomain no banco
                EspecialistaDomain especialista = new EspecialistaDomain{
                    Nome = especialistaDto.Nome,
                    Especialidade = especialistaDto.Especialidade,
                    Usuario = usuario
                };

                PermissaoDomain permissao = _context.Permissoes.FirstOrDefault(x => x.Permissao == "Especialista");

                UsuarioPermissaoDomain usuarioPermissao = new UsuarioPermissaoDomain{
                    UsuarioId = usuario.Id,
                    PermissaoId = permissao.Id
                };

                _context.UsuariosPermissoes.Add(usuarioPermissao);

                _context.Especialistas.Add(especialista);

                 //salvar alterações
                _context.SaveChanges();
                    
                //retornar especialista com include de usuário
                return especialista;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public UsuarioDomain CriarUsuario(UsuarioDto usuarioDto)
        {
            try{
                byte[] passwordHash, passwordSalt;

                //Chamar função para criar hash com a senha em string do DTO
                CriarPasswordHash(usuarioDto.Senha, out passwordHash, out passwordSalt);
                
                //Passa os valores para o usuario
                var usuario = new UsuarioDomain{
                    Email = usuarioDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Rfid = usuarioDto.Rfid,
                    Digital = usuarioDto.Digital,
                    DataAlteracao = DateTime.Now
                };
                
                return usuario;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        private void CriarPasswordHash(string senha, out byte[] passwordHash, out byte[] passwordSalt)
        {
            try{
                using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key; //armazena o salt para comparação em login
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha)); //computa o hash
                }
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public UsuarioDomain LoginDigital(string digital)
        {
            if(digital == null)
                return null;
            
            UsuarioDomain usuario = _context.Usuarios
                                        .Include(u => u.Permissoes)
                                            .ThenInclude(p => p.Permissao)
                                        .FirstOrDefault(x => x.Digital == digital);

            return usuario;
        }

        public UsuarioDomain LoginRfid(string rfid)
        {
            if(rfid == null)
                return null;
            
            UsuarioDomain usuario = _context.Usuarios
                                        .Include(u => u.Permissoes)
                                            .ThenInclude(p => p.Permissao)
                                        .FirstOrDefault(x => x.Rfid == rfid);

            return usuario;
        }

        public UsuarioDomain LoginUsuario(string nomeUsuario, string password)
        {
            UsuarioDomain usuario = AcharUsuario(nomeUsuario.ToLower());
            
            if(usuario == null)
                return null;
            
            //verifica a validade da senha
            if(!VerificarPassword(password, usuario.PasswordHash, usuario.PasswordSalt))
                return null;

            return usuario;
        }

        private UsuarioDomain AcharUsuario(string nomeUsuario)
        {
            var usuario = _context.Usuarios.Include(u => u.Permissoes)
                                                .ThenInclude(p => p.Permissao)
                                            .FirstOrDefault(x => x.Email == nomeUsuario);

            if(usuario == null)
                return null;

            return usuario;
        }

        private bool VerificarPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //gera o hash usando o key armazenado

                //Verificação do array do hash
                for (int i = 0; i < hash.Length; i++)
                {
                    if(hash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public bool UsuarioExiste(string email)
        {
            try{
                if(_context.Usuarios.Any(x => x.Email == email))
                    return true;
                
                return false;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public bool CpfCadastrado(string cpf)
        {
            try{
                if(_context.DadosFuncionarios.Any(x => x.CPF == cpf))
                    return true;
                
                return false;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int AtualizarRfid(string rfid, UsuarioDomain usuario)
        {
            usuario.Rfid = rfid;

            _context.Usuarios.Update(usuario);

            return _context.SaveChanges();
        }

        public int AtualizarDigital(string digital, UsuarioDomain usuario)
        {
            usuario.Digital = digital;

            _context.Usuarios.Update(usuario);

            return _context.SaveChanges();
        }
    }
}