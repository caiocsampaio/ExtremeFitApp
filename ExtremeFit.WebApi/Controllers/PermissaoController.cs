using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller de acesso a informações de permissões
    /// </summary>
    [Route("api/permissoes")]
    public class PermissaoController : Controller
    {
        private readonly IPermissaoRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public PermissaoController(IPermissaoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todas as permissões cadastradas
        /// </summary>
        /// <returns></returns>
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