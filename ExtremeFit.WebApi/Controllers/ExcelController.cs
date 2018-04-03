using System.IO;
using ExcelDataReader;
using ExtremeFit.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeFit.WebApi.Controllers
{
    [Route("api/excel")]
    public class ExcelController : Controller
    {
        [HttpPost]
        public IActionResult ProcessandoPlanilha(IFormFile arquivo)
        {
            var data = new MemoryStream();
            
            arquivo.CopyTo(data);

            data.Seek(0, SeekOrigin.Begin);

            var buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);

            IExcelDataReader reader = null;

            if(arquivo.FileName.EndsWith(".xls"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(data);
            }  
            else if(arquivo.FileName.EndsWith(".xlsx"))
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(data);
            }

            // reader.IsFirstRowAsColumnNames = true;

            var result = reader.AsDataSet();
            reader.Close();

            var dados = new DadosFuncionarioDomain();

            for(int i = 1; i < result.Tables[0].Rows.Count; i++){

                dados.CPF = result.Tables[0].Rows[i][0].ToString();
                dados.Setor = result.Tables[0].Rows[i][1].ToString();
                dados.Funcao = result.Tables[0].Rows[i][2].ToString();
                string CNPJ = result.Tables[0].Rows[i][3].ToString();
            }

            return Ok();            
        }
    }
}