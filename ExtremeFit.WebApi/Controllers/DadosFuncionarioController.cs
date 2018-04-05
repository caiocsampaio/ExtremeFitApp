using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/dados-funcionarios")]
    public class DadosFuncionarioController : Controller
    {
        private readonly IDadosFuncionariosRepository _repo;
        public DadosFuncionarioController(IDadosFuncionariosRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista.Count == 0)
                return NotFound("Nenhum dado encontrado");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            DadosFuncionarioDomain dados = _repo.BuscarPorId(id);

            if(dados == null)
                return NotFound("Dados não encontrados");

            return Ok(dados);
        }

        [HttpPost]
        public IActionResult CadastrarDados([FromBody] DadosFuncionarioDto dadosFuncionarioDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var s = _repo.Inserir(dadosFuncionarioDto);

            if(s == 0)
                return BadRequest("Erro no cadastro dos dados");
            
            return Ok("Dados cadastrados");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarDados([FromBody] DadosFuncionarioDto dadosFuncionarioDto, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var s = _repo.Atualizar(dadosFuncionarioDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar dados");
            
            if(s == 404)
                return BadRequest("Dados não encontrados");

            return Ok("Dados atualizados");
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirDados(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 0)
                return BadRequest("Problema ao tentar excluir dados");

            return Ok("Dados excluídos");
        }
    }
}