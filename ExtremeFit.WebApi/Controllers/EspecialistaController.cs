using System;
using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de dados de especialistas
    /// </summary>
    [Route("api/especialistas")]
    public class EspecialistaController : Controller
    {
        private readonly IEspecialistaRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public EspecialistaController(IEspecialistaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista dados de todos os especialistas
        /// </summary>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
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

        /// <summary>
        /// Retorna dados de um único especialista
        /// </summary>
        /// <param name="id">ID do especialista</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
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

        /// <summary>
        /// Atualiza dados de um especialista
        /// </summary>
        /// <param name="especialistaDto">informações atualizadas do especialista</param>
        /// <param name="id">ID do especialista</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] EspecialistaDto especialistaDto, int id)
        {
            var s = _repo.Atualizar(especialistaDto, id);

            if(s == 0)
                return BadRequest("Problema ao tentar atualizar especialista");

            return Ok("Especialista atualizado(a)");
        }

        /// <summary>
        /// Exclui um especialista
        /// </summary>
        /// <param name="id">ID do especialista</param>
        /// <returns></returns>
        [Authorize("Bearer", Roles="Admin,Sesi")]
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