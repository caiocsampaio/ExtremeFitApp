using System.Collections.Generic;
using System.IO;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/excel")]
    public class ExcelController : Controller
    {
        private readonly IExcelRepository _repo;
        public ExcelController(IExcelRepository repo)
        {
            _repo = repo;
        }

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