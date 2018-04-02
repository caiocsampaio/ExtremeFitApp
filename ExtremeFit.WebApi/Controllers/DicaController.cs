using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/dicas")]
    public class DicaController : Controller
    {
        private readonly IDicaRepository _repo;
        public DicaController(IDicaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma dica encontrada");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            DicaDomain dica = _repo.BuscarPorId(id);

            if(dica == null)
                return NotFound("Dica não encontrada");

            return Ok(dica);
        }

        [HttpPost]
        public IActionResult CadastrarDica([FromBody] DicaDto dicaDto)
        {
            var s = _repo.Inserir(dicaDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar dica");
            
            return Ok("Dica cadastrada");
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] DicaDto dicaDto, int id)
        {
            var s = _repo.Atualizar(dicaDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar dica");
            
            return Ok("Dica atualizada");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 0)
                return BadRequest("Problema ao tentar excluir dica");
            
            return Ok("Dica excluída");
        }
        
        [HttpPut("{id}/validar")]
        public IActionResult Validar([FromBody] ValidarDicaDto validarDica, int id)
        {
            var s = _repo.Validar(validarDica, id);

            if(s == 0)
                return BadRequest("Problema ao tentar validar dica");
            
            return Ok("Dica (in)validada");
        }
    }
}