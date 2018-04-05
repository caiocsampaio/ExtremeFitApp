using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de dados de eventos
    /// </summary>
    [Route("api/eventos")]
    public class EventoController : Controller
    {
        private readonly IEventoRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public EventoController(IEventoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todos os eventos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhum evento encontrado");

            return Ok(lista);
        }

        /// <summary>
        /// Retorna dados de um único evento
        /// </summary>
        /// <param name="id">ID do evento</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EventoDomain evento = _repo.BuscarPorId(id);

            if(evento == null)
                return NotFound("Evento não encontrado");

            return Ok(evento);
        }

        /// <summary>
        /// Cadastro de novo evento
        /// </summary>
        /// <param name="eventoDto">informações do evento</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarEvento([FromBody] EventoDto eventoDto)
        {
            var s = _repo.Inserir(eventoDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar evento");
            
            return Ok("Evento cadastrado");
        }
        
        /// <summary>
        /// Atualizar dados de um evento
        /// </summary>
        /// <param name="eventoDto">informações atualizadas de evento</param>
        /// <param name="id">ID do evento</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Exclui um evento
        /// </summary>
        /// <param name="id">ID do evento</param>
        /// <returns></returns>
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