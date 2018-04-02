using System;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/funcionarios")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _repo;

        public FuncionarioController(IFuncionarioRepository repo)
        {
            _repo = repo;
        }

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

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try{
                var funcionario = _repo.BuscarPorId(id);
                
                if(funcionario == null)
                    return NotFound("Funcioanrio(a) não encontrado(a)");

                return Ok(funcionario);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

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
    }
}