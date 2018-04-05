using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de locais das dores para cadastro de relatório
    /// </summary>
    [Route("api/locais-dores")]
    public class LocalDorController : Controller
    {
        private readonly ILocalDorRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public LocalDorController(ILocalDorRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todos os locais cadastrados
        /// </summary>
        /// <returns></returns>
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