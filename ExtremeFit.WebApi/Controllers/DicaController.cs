using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de dicas cadastradas
    /// </summary>
    [Route("api/dicas")]
    public class DicaController : Controller
    {
        private readonly IDicaRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public DicaController(IDicaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as dicas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma dica encontrada");

            return Ok(lista);
        }
        
        /// <summary>
        /// Retorna dados de uma única dica cadastrada
        /// </summary>
        /// <param name="id">ID da dica</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            DicaDomain dica = _repo.BuscarPorId(id);

            if(dica == null)
                return NotFound("Dica não encontrada");

            return Ok(dica);
        }

        /// <summary>
        /// Cadasto de nova dica
        /// </summary>
        /// <param name="dicaDto">informações da dica</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarDica([FromBody] DicaDto dicaDto)
        {
            var s = _repo.Inserir(dicaDto);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar dica");
            
            return Ok("Dica cadastrada");
        }
        
        /// <summary>
        /// Atualiza dados de dica cadastrada
        /// </summary>
        /// <param name="dicaDto">dados atualizados da dica</param>
        /// <param name="id">ID da dica</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] DicaDto dicaDto, int id)
        {
            var s = _repo.Atualizar(dicaDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar dica");
            
            return Ok("Dica atualizada");
        }
        
        /// <summary>
        /// Exclui uma dica
        /// </summary>
        /// <param name="id">ID da dica</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 0)
                return BadRequest("Problema ao tentar excluir dica");
            
            return Ok("Dica excluída");
        }
        
        /// <summary>
        /// Valida ou invalida uma dica
        /// </summary>
        /// <param name="validarDica">informação true/false</param>
        /// <param name="id">ID da dica</param>
        /// <returns></returns>
        [HttpPut("{id}/validar")]
        public IActionResult Validar([FromBody] ValidarDicaDto validarDica, int id)
        {
            var s = _repo.Validar(validarDica, id);

            if(s == 0)
                return BadRequest("Problema ao tentar validar dica");
            
            return Ok("Dica (in)validada");
        }
    }
}