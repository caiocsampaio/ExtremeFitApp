using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/unidades-sesi")]
    public class UnidadeSesiController : Controller
    {
        private readonly IUnidadeSesiRepository _repo;
        public UnidadeSesiController(IUnidadeSesiRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Lista();

            if(lista == null)
                return NotFound("Nenhuma unidade encontrada");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            UnidadeSesiDomain unidade = _repo.BuscarPorId(id);

            if(unidade == null)
                return NotFound("Unidade não encontrada");
            
            return Ok(unidade);
        }

        [HttpGet("{id}/eventos")]
        public IActionResult BuscarEventos(int id)
        {
            var listaEventos = _repo.ListarEventosPorId(id);

            if(listaEventos == null)
                return NotFound("Nenhum evento encontrado na unidade");
            
            return Ok(listaEventos);
        }

        [HttpPost]
        public IActionResult Cadastrar(UnidadeSesiDto unidadeSesiDto)
        {
            var s = _repo.Cadastrar(unidadeSesiDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar unidade");

            return Ok("Unidade cadastrada");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(UnidadeSesiDto unidadeSesiDto, int id)
        {
            var s = _repo.Atualizar(unidadeSesiDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar unidade");

            return Ok("Unidade atualizada");
        }
    }
}