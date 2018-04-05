using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelDataReader;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ExtremeFit.Repository.Repositories
{
    public class ExcelRepository : IExcelRepository
    {
        private readonly ApiContext _context;
        public ExcelRepository(ApiContext context)
        {
            _context = context;
        }

        public List<DadosFuncionarioDomain> ProcessarPlanilha(IFormFile arquivo)
        {
            var lista = new List<DadosFuncionarioDomain>();
            var data = new MemoryStream();

            arquivo.CopyTo(data);

            // pegar CNPJ do nome do arquivo
            string CNPJ = arquivo.FileName.Split('.')[0];
            EmpresaDomain empresa = _context.Empresas.FirstOrDefault(x => x.CNPJ == CNPJ);

            // verificar se o CNPJ está cadastrado
            if(empresa == null)
                return null;

            data.Seek(0, SeekOrigin.Begin);
            var buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);

            IExcelDataReader reader = null;

            if (arquivo.FileName.EndsWith(".xls"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(data);
            }
            else if (arquivo.FileName.EndsWith(".xlsx"))
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(data);
            }

            var result = reader.AsDataSet();
            reader.Close();

            // pegar dados de cada linha a partir do número das colunas
            for (int i = 1; i < result.Tables[0].Rows.Count; i++)
            {
                string cpf = result.Tables[0].Rows[i][0].ToString();
                string setor = result.Tables[0].Rows[i][1].ToString();
                string funcao = result.Tables[0].Rows[i][2].ToString();
                
                // criar lista com todos os funcionarios para serem adicionados
                lista.Add(new DadosFuncionarioDomain{
                    EmpresaId = empresa.Id,
                    CPF = cpf,
                    Setor = setor,
                    Funcao = funcao
                });
            }

            return lista;
        }

        public int CadastrarDadosExcel(List<DadosFuncionarioDomain> lista)
        {
            for (int s = 0; s < lista.Count; s++)
            {
                _context.DadosFuncionarios.Add(lista[s]);
            }

            return _context.SaveChanges();
        }
    }
}