using System;
using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/especialistas")]
    public class EspecialistaController : Controller
    {
        private readonly IEspecialistaRepository _repo;
        public EspecialistaController(IEspecialistaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar(){
            try{
                var lista = _repo.Listar();

                if(lista.Count == 0)
                    return NotFound("Nenhum(a) especialista encontrado(a)");

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
                EspecialistaDomain especialista = _repo.BuscarPorId(id);

                if(especialista == null)
                    return NotFound("Especialista não encontrado(a)");

                return Ok(especialista);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] EspecialistaDto especialistaDto, int id)
        {
            var s = _repo.Atualizar(especialistaDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar especialista");

            return Ok("Especialista atualizado(a)");
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var s = _repo.Deletar(id);

            if(s == 0)
                return BadRequest("Problema ao tentar excluir especialista");

            return Ok("Especialista excluído(a)");
        }
    }
}