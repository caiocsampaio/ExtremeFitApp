using System;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/perguntas")]
    public class PerguntaController : Controller
    {
        private readonly IPerguntaRepository _repo;

        public PerguntaController(IPerguntaRepository repo)
        {
            _repo = repo;
        }

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