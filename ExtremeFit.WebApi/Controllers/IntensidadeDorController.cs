using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de intensidade das dores para cadastro de relatórios
    /// </summary>
    [Route("api/intensidades-dores")]
    public class IntensidadeDorController : Controller
    {
        private readonly IIntensidadeDorRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public IntensidadeDorController(IIntensidadeDorRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as intensidades cadastradas
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();

            if(lista == null)
                return NotFound("Nenhuma intensidade de dor encontrada");

            return Ok(lista);
        }
    }
}