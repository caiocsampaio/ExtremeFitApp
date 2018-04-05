using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/relatorios")]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioRepository _repo;
        public RelatorioController(IRelatorioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhum relatório encontrado");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            RelatorioDorDomain relatorio = _repo.BuscarPorId(id);

            if(relatorio == null)
                return NotFound("Relatório não encontrado");
            
            return Ok(relatorio);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] RelatorioDto relatorioDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var s = _repo.Cadastrar(relatorioDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar relatório");
            
            return Ok("Relatório cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] RelatorioDto relatorioDto, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var s = _repo.Atualizar(relatorioDto, id);

            if(s == 404)
                return BadRequest("Problema ao tentar atualizar relatório");

            if(s == 0)
                return NotFound("Relatório não encontrado");

            return Ok("Relatório atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 404)
                return BadRequest("Problema ao tentar excluir relatório");

            if(s == 0)
                return NotFound("Relatório não encontrado");

            return Ok("Relatório excluído");
        }
    }
}