using System.Collections.Generic;
using System.IO;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    /// <summary>
    /// Controller para cadastro de dados de usuário por planilhas de excel
    /// </summary>
    [Route("api/excel")]
    public class ExcelController : Controller
    {
        private readonly IExcelRepository _repo;

        /// <summary>
        /// Construtor de classe com acesso ao repositório
        /// </summary>
        /// <param name="repo">Repositório de Autorização</param>
        public ExcelController(IExcelRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Cadastro de dados de funcionários com planilha excel
        /// </summary>
        /// <param name="arquivo">arquivo excel com dados dos funcionários</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarExcel(IFormFile arquivo)
        {
            List<DadosFuncionarioDomain> lista = _repo.ProcessarPlanilha(arquivo);

            if(lista == null)
                return BadRequest("Problema ao tentar cadastrar planilha. "+
                                    "Verifique se o nome do arquivo e os dados estão no padrão correto");
            
            var s = _repo.CadastrarDadosExcel(lista);

            if(s == 0)
                return BadRequest("Problema ao tentar cadastrar os dados no banco.");

            return Ok(string.Format("{0} funcionários(as) cadastrados(as)", s));
        }
    }
}