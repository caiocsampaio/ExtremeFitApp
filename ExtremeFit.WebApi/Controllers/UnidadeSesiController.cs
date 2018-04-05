using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de unidades Sesi
    /// </summary>
    [Route("api/unidades-sesi")]
    public class UnidadeSesiController : Controller
    {
        private readonly IUnidadeSesiRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public UnidadeSesiController(IUnidadeSesiRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as unidades Sesi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Lista();

            if(lista == null)
                return NotFound("Nenhuma unidade encontrada");

            return Ok(lista);
        }

        /// <summary>
        /// Retorna dados de uma única unidade Sesi
        /// </summary>
        /// <param name="id">ID da unidade</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            UnidadeSesiDomain unidade = _repo.BuscarPorId(id);

            if(unidade == null)
                return NotFound("Unidade não encontrada");
            
            return Ok(unidade);
        }

        /// <summary>
        /// Retorna lista de todos os eventos de uma unidade Sesi
        /// </summary>
        /// <param name="id">ID da unidade</param>
        /// <returns></returns>
        [HttpGet("{id}/eventos")]
        public IActionResult BuscarEventos(int id)
        {
            var listaEventos = _repo.ListarEventosPorId(id);

            if(listaEventos == null)
                return NotFound("Nenhum evento encontrado na unidade");
            
            return Ok(listaEventos);
        }

        /// <summary>
        /// Cadastro de nova unidade Sesi
        /// </summary>
        /// <param name="unidadeSesiDto">informações da unidade</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(UnidadeSesiDto unidadeSesiDto)
        {
            var s = _repo.Cadastrar(unidadeSesiDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar unidade");

            return Ok("Unidade cadastrada");
        }

        /// <summary>
        /// Atualização de dados de uma unidade Sesi
        /// </summary>
        /// <param name="unidadeSesiDto">informações atualizadas</param>
        /// <param name="id">ID da unidade</param>
        /// <returns></returns>
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