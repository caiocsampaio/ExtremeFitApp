using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using ExtremeFit.WebApi.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("cadastro/funcionario")]
        public IActionResult CadastrarFuncionario([FromBody] FuncionarioDto funcionarioDto)
        {
            //Verificar se o CPF já está cadastrado
            if(_repo.CpfCadastrado(funcionarioDto.CPF))
                return BadRequest("CPF já cadastrado");

            //Verificar se o Email já está cadastrado
            if(_repo.UsuarioExiste(funcionarioDto.Email))
                return BadRequest("Email já cadastrado");

            //Criar FuncionarioDto e cadastrar
            var funcionario = _repo.CadastrarFuncionario(funcionarioDto);

            return Ok("Funcionário cadastrado");
        }
        
        [HttpPost("cadastro/especialista")]
        public IActionResult CadastrarEspecialista([FromBody] EspecialistaDto especialistaDto)
        {
                        //Verificar se o Email já está cadastrado
            if(_repo.UsuarioExiste(especialistaDto.Email))
                return BadRequest("Email já cadastrado");

            //Criar FuncionarioDto e cadastrar
            var especialista = _repo.CadastrarEspecialista(especialistaDto);

            return Ok("Especialista cadastrado");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDto usuarioDto, 
                                    [FromServices]SigningConfigurations signingConfigurations,
                                    [FromServices]TokenConfigurations tokenConfigurations)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            UsuarioDomain usuario = _repo.LoginUsuario(usuarioDto.Email, usuarioDto.Senha);
            
            if(usuario == null)
                return Unauthorized();
            
            var token = new TokenLogin().GerarToken(usuario, signingConfigurations, tokenConfigurations);

            return Ok(token);
        }
    }
}