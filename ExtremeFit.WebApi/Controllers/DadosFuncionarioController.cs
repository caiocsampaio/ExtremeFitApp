using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de dados de funcionários (CPF, Setor, Função)
    /// </summary>
    [Route("api/dados-funcionarios")]
    public class DadosFuncionarioController : Controller
    {
        private readonly IDadosFuncionariosRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public DadosFuncionarioController(IDadosFuncionariosRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todos os dados de funcionários já cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista.Count == 0)
                return NotFound("Nenhum dado encontrado");

            return Ok(lista);
        }

        /// <summary>
        /// Retorna dados de um único funcionário
        /// </summary>
        /// <param name="id">ID do funcionário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            DadosFuncionarioDomain dados = _repo.BuscarPorId(id);

            if(dados == null)
                return NotFound("Dados não encontrados");

            return Ok(dados);
        }

        /// <summary>
        /// Cadastro de novos dados (CPF, Setor e Função) de um único funcionário
        /// </summary>
        /// <param name="dadosFuncionarioDto">dados do funcionário</param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza dados de funcionário
        /// </summary>
        /// <param name="dadosFuncionarioDto">dados atualizados do funcionário</param>
        /// <param name="id">ID do funcionário</param>
        /// <returns></returns>
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

        /// <summary>
        /// Exclui dados de um funcionário
        /// </summary>
        /// <param name="id">ID do funcionário</param>
        /// <returns></returns>
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