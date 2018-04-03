using System.Collections.Generic;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IIntensidadeDorRepository
    {
        List<IntensidadeDorDomain> Listar();
    }
}