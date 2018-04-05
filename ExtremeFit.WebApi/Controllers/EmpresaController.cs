using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de dados de empresas
    /// </summary>
    [Route("api/empresas")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public EmpresaController(IEmpresaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as empresas cadatradas
        /// </summary>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma empresa encontrada");

            return Ok(lista);
        }

        /// <summary>
        /// Retorna dados de uma única empresa
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EmpresaDomain empresa = _repo.BuscarPorId(id);

            if(empresa == null)
                return NotFound("Empresa não encontrada");

            return Ok(empresa);
        }

        /// <summary>
        /// Cadastro de nova empresa
        /// </summary>
        /// <param name="empresaDto">informações da empresa</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
        [HttpPost]
        public IActionResult CadastrarEmpresa([FromBody] EmpresaDto empresaDto)
        {
            var s = _repo.Inserir(empresaDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar empresa");
            
            return Ok("Empresa cadastrada");
        }
        
        /// <summary>
        /// Atualiza dados de uma empresa
        /// </summary>
        /// <param name="empresaDto">informações atualizadas da empresa</param>
        /// <param name="id">ID da empresa</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] EmpresaDto empresaDto, int id)
        {
            var s = _repo.Atualizar(empresaDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar empresa");
            
            if(s == 404)
                return BadRequest("Empresa não encontrada");
            
            return Ok("Empresa atualizada");
        }
        
        /// <summary>
        /// Exclui dados de uma empresa
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 0)
                return BadRequest("Problema ao tentar excluir empresa");

            if(s == 404)
                return BadRequest("Empresa não encontrada");
            
            return Ok("Empresa excluída");
        }
    }
}