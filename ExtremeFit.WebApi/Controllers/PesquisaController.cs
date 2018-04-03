using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/pesquisas")]
    public class PesquisaController : Controller
    {
        private readonly IPesquisaRepository _repo;
        public PesquisaController(IPesquisaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Lista();

            if(lista == null)
                return NotFound("Nenhuma pesquisa encontrada");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            PesquisaDomain pesquisa = _repo.BuscarPorId(id);

            if(pesquisa == null)
                return NotFound("Pesquisa não encontrada");

            return Ok(pesquisa);
        }

        [HttpPost]
        public IActionResult Cadastrar(PesquisaDto pesquisaDto)
        {
            var s = _repo.Cadastrar(pesquisaDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar pesquisa");

            return Ok("Pesquisa cadastrada");
        }
    }
}