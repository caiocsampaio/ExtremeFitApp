using System;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de funcionários
    /// </summary>
    [Route("api/funcionarios")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public FuncionarioController(IFuncionarioRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todos os funcionários cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar(){
            try{
                var lista = _repo.Listar();

                if(lista.Count == 0)
                    return NotFound("Não foi encontrado nenhum(a) funcionário(a)");
                
                return Ok(lista);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Retorna dados de um único funcionário
        /// </summary>
        /// <param name="id">ID do funcionário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try{
                var funcionario = _repo.BuscarPorId(id);
                
                if(funcionario == null)
                    return NotFound("Funcionário(a) não encontrado(a)");

                return Ok(funcionario);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Atualiza dados de um funcionário e usuário relacionado
        /// </summary>
        /// <param name="funcionarioDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] FuncionarioDto funcionarioDto, int id){

            try{
                var s = _repo.Atualizar(funcionarioDto, id);

                if(s == 0)
                    return BadRequest("Problema ao tentar atualizar funcionario(a)");

                return Ok("Funcionario(a) atualizado(a)");
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Exclui dados de um funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id){
            try{
                var s = _repo.Deletar(id);

                if(s == 0)
                    return BadRequest("Problema ao tentar excluir funcionario(a)");

                return Ok("Funcionario(a) excluído(a)");
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Atualiza dados de unidade favoritas do funcionário para listagem de eventos
        /// </summary>
        /// <param name="unidadesDto">informações da unidade</param>
        /// <param name="id">ID do funcionário</param>
        /// <returns></returns>
        [HttpPut("{id}/unidades-favoritas")]
        public IActionResult UnidadesFavoritas([FromBody] UnidadesDto unidadesDto, int id)
        {
            if(unidadesDto.UnidadesFavoritasId.Length > 3)
                return BadRequest("O número máximo de unidades favoritas são 3");
            
            if(unidadesDto.UnidadesFavoritasId.Length == 0)
                return BadRequest("Forneça pelo menos uma unidade");

            var s = _repo.AtualizarUnidades(unidadesDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar unidades favoritas");
            
            return Ok("Unidades atualizadas");
        }
    }
}