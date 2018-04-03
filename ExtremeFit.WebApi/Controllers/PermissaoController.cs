using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/permissoes")]
    public class PermissaoController : Controller
    {
        private readonly IPermissaoRepository _repo;
        public PermissaoController(IPermissaoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma permissão encontrada");
                
            return Ok(lista);
        }
    }
}