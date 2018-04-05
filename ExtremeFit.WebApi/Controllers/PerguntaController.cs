using System;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de perguntas
    /// </summary>
    [Route("api/perguntas")]
    public class PerguntaController : Controller
    {
        private readonly IPerguntaRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public PerguntaController(IPerguntaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as perguntas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar(){
            try{
                var lista = _repo.Listar();

                if(lista.Count == 0)
                    return NotFound("Não foi encontrada nenhuma pergunta");
                
                return Ok(lista);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        /// Retorna dados de uma única pergunta
        /// </summary>
        /// <param name="id">ID da pergunta</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try{
                var pergunta = _repo.BuscarPorId(id);
                
                if(pergunta == null)
                    return NotFound("Pergunta não encontrada");

                return Ok(pergunta);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Cadastro de nova pergunta com alternativas associadas
        /// </summary>
        /// <param name="perguntaDto">informações de pergunta com alternativas</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar([FromBody] PerguntaDto perguntaDto){

            try{
                var s = _repo.Inserir(perguntaDto);

                if(s == 0)
                    return BadRequest("Erro no cadastro de pergunta");
                
                return Ok("Pergunta cadastrada");
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Atualiza uma pergunta e as alternativas
        /// </summary>
        /// <param name="perguntaDto">informações atualizadas da pergunta</param>
        /// <param name="id">ID da pergunta</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] PerguntaDto perguntaDto, int id){

            try{
                var s = _repo.Atualizar(perguntaDto, id);

                if(s == 0)
                    return BadRequest("Problema ao tentar atualizar pergunta");

                return Ok("Pergunta e alternativas atualizadas");
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Exclui uma pergunta e alternativas associadas
        /// </summary>
        /// <param name="id">ID da alternativa</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id){
            try{
                var s = _repo.Deletar(id);

                if(s == 0)
                    return BadRequest("Problema ao tentar excluir pergunta");

                return Ok("Pergunta excluída");
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }
    }
}