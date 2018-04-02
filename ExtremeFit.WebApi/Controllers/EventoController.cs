using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/eventos")]
    public class EventoController : Controller
    {
        private readonly IEventoRepository _repo;
        public EventoController(IEventoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhum evento encontrado");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EventoDomain evento = _repo.BuscarPorId(id);

            if(evento == null)
                return NotFound("Evento não encontrado");

            return Ok(evento);
        }

        [HttpPost]
        public IActionResult CadastrarEvento([FromBody] EventoDto eventoDto)
        {
            var s = _repo.Inserir(eventoDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar evento");
            
            return Ok("Evento cadastrado");
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] EventoDto eventoDto, int id)
        {
            var s = _repo.Atualizar(eventoDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar evento");
            
            if(s == 404)
                return BadRequest("Evento não encontrado");
            
            return Ok("Evento atualizado");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 0)
                return BadRequest("Problema ao tentar excluir evento");

            if(s == 404)
                return BadRequest("Evento não encontrado");
            
            return Ok("Evento excluído");
        }
    }
}