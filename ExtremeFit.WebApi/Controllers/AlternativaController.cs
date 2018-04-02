using System;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/alternativas")]
    public class AlternativaController : Controller
    {
        private readonly IAlternativaRepository _repo;

        public AlternativaController(IAlternativaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarAlternativa(int id)
        {
            try{
                var alternativa = _repo.BuscarPorId(id);
                
                if(alternativa == null)
                    return NotFound("Alternativa não encontrada");

                return Ok(alternativa);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }
    }
}