using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] UsuarioDto usuarioDto, int id)
        {
            var s = _repo.Atualizar(usuarioDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar dados de usuário");
            
            return Ok("Dados atualizados");
        }
    }
}