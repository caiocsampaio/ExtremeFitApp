using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/empresas")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository _repo;
        public EmpresaController(IEmpresaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma empresa encontrada");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EmpresaDomain empresa = _repo.BuscarPorId(id);

            if(empresa == null)
                return NotFound("Empresa não encontrada");

            return Ok(empresa);
        }

        [HttpPost]
        public IActionResult CadastrarEmpresa([FromBody] EmpresaDto empresaDto)
        {
            var s = _repo.Inserir(empresaDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar empresa");
            
            return Ok("Empresa cadastrada");
        }
        
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