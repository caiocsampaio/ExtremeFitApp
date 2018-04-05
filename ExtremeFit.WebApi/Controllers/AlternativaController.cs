using System;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller para acessar dados de Alternativas
    /// </summary>
    [Route("api/alternativas")]
    [Authorize]
    public class AlternativaController : Controller
    {
        private readonly IAlternativaRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Alternativas</param>
        public AlternativaController(IAlternativaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as alternativas de todas as perguntas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma alternativa encontrada");
            
            return Ok(lista);
        }

        /// <summary>
        /// Retorna uma alternativa pesquisada pelo ID fornecido
        /// </summary>
        /// <param name="id">ID da alternativa</param>
        [HttpGet("{id}")]
        public IActionResult BuscarAlternativa(int id)
        {
            try{
                var alternativa = _repo.BuscarPorId(id);
                
                if(alternativa == null)
                    return NotFound("Alternativa não encontrada");

                return Ok(alternativa);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }
    }
}