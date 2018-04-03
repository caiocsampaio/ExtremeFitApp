using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/locais-dores")]
    public class LocalDorController : Controller
    {
        private readonly ILocalDorRepository _repo;
        public LocalDorController(ILocalDorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhum local de dor encontrado");

            return Ok(lista);
        }
    }
}