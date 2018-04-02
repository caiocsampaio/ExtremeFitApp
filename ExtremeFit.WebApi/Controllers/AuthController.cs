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

        [HttpPost("login/rfid")]
        public IActionResult LoginRfid([FromBody] IotDto iotDto, 
                                        [FromServices]SigningConfigurations signingConfigurations,
                                        [FromServices]TokenConfigurations tokenConfigurations)
        {
            string rfid = iotDto.Rfid;

            if(string.IsNullOrEmpty(rfid)){
                ModelState.AddModelError("Rfid", "O RfId deve ser fornecido");
                return BadRequest(ModelState);
            }
            
            UsuarioDomain usuario = _repo.LoginRfid(rfid);

            if(usuario == null){
                return NotFound(rfid);
            }

            var token = new TokenLogin().GerarToken(usuario, signingConfigurations, tokenConfigurations);

            return Ok(token);
        }

        [HttpPost("login/digital")]
        public IActionResult LoginDigital([FromBody] IotDto iotDto, 
                                            [FromServices]SigningConfigurations signingConfigurations,
                                            [FromServices]TokenConfigurations tokenConfigurations)
        {
            string digital = iotDto.Digital;

            if(string.IsNullOrEmpty(digital)){
                ModelState.AddModelError("Digital", "A digital deve ser fornecida");
                return BadRequest(ModelState);
            }
            
            UsuarioDomain usuario = _repo.LoginDigital(digital);

            if(usuario == null){
                return NotFound(digital);
            }

            var token = new TokenLogin().GerarToken(usuario, signingConfigurations, tokenConfigurations);

            return Ok(token);
        }

        [HttpPut("atualizar/iot")]
        public IActionResult AtualizarIot([FromBody] UsuarioDto usuarioDto, 
                                            [FromServices]SigningConfigurations signingConfigurations,
                                            [FromServices]TokenConfigurations tokenConfigurations)
        {
            string rfid = usuarioDto.Rfid;
            string digital = usuarioDto.Digital;

            if(string.IsNullOrEmpty(rfid) && string.IsNullOrEmpty(digital)){
                ModelState.AddModelError("Rfid", "O RfId ou a Digital deve ser fornecida");
                ModelState.AddModelError("Digital", "O RfId ou a Digital deve ser fornecida");
                return BadRequest(ModelState);
            }

            // fazer login
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            UsuarioDomain usuario = _repo.LoginUsuario(usuarioDto.Email, usuarioDto.Senha);
            
            // se não existir, falha no login
            if(usuario == null)
                return Unauthorized();

            if(string.IsNullOrEmpty(digital)){
                // se existir, atualiza o rfid com o fornecido
                int s = _repo.AtualizarRfid(rfid, usuario);

                if(s == 0)
                    return BadRequest("Problema ao tentar atualizar o RfId");
            }
            else{
                // se existir, atualiza o rfid com o fornecido
                int s = _repo.AtualizarDigital(digital, usuario);

                if(s == 0)
                    return BadRequest("Problema ao tentar atualizar a Digital");
            }
                
            // gerar token
            var token = new TokenLogin().GerarToken(usuario, signingConfigurations, tokenConfigurations);

            // retornar Ok(token)
            return Ok(token);
        }
    }
}