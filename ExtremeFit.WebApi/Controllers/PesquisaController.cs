using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de pesquisas realizadas
    /// </summary>
    [Route("api/pesquisas")]
    public class PesquisaController : Controller
    {
        private readonly IPesquisaRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public PesquisaController(IPesquisaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as pesquisas cadastradas
        /// </summary>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi,Especialista,Empresa")]
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Lista();

            if(lista == null)
                return NotFound("Nenhuma pesquisa encontrada");

            return Ok(lista);
        }

        /// <summary>
        /// Retorna dados de uma única pesquisa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi,Especialista,Empresa")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            PesquisaDomain pesquisa = _repo.BuscarPorId(id);

            if(pesquisa == null)
                return NotFound("Pesquisa não encontrada");

            return Ok(pesquisa);
        }

        /// <summary>
        /// Cadastro de nova pesquisa
        /// </summary>
        /// <param name="pesquisaDto">informações de pesquisa com alternativa escolhida</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] PesquisaDto pesquisaDto)
        {
            var s = _repo.Cadastrar(pesquisaDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar pesquisa");

            return Ok("Pesquisa cadastrada");
        }
    }
}