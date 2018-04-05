using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IExcelRepository
    {
         List<DadosFuncionarioDomain> ProcessarPlanilha(IFormFile arquivo);

         int CadastrarDadosExcel(List<DadosFuncionarioDomain> lista);
    }
}