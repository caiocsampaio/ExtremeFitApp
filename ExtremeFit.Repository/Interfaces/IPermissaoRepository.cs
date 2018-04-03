using System.Collections.Generic;
using ExtremeFit.Domain.Entities;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IPermissaoRepository
    {
         List<PermissaoDomain> Listar();
    }
}