using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de relatórios produzidos por funcionários
    /// </summary>
    [Route("api/relatorios")]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public RelatorioController(IRelatorioRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todos os relatórios cadastrados
        /// </summary>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi,Especialista,Empresa")]
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhum relatório encontrado");

            return Ok(lista);
        }

        /// <summary>
        /// Retorna dados de um único relatório
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi,Especialista,Empresa")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            RelatorioDorDomain relatorio = _repo.BuscarPorId(id);

            if(relatorio == null)
                return NotFound("Relatório não encontrado");
            
            return Ok(relatorio);
        }

        /// <summary>
        /// Cadastro de novo relatório
        /// </summary>
        /// <param name="relatorioDto">informações de relatório</param>
        /// <returns></returns>
        [Authorize]
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

        /// <summary>
        /// Atualiza informações de relatório
        /// </summary>
        /// <param name="relatorioDto">informações atualizadas de relatório</param>
        /// <param name="id">ID do relatório</param>
        /// <returns></returns>
        [Authorize]
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

        /// <summary>
        /// Exclui dados de relatório
        /// </summary>
        /// <param name="id">ID do relatório</param>
        /// <returns></returns>
        [Authorize]
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