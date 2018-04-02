using System.Collections.Generic;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        IEnumerable<T> Listar(string[] includes = null);

        T BuscarPorId(int id, string[] includes = null);
        
        int Atualizar(T dados);

        int Inserir(T dados);

        int Deletar(T dados);

        int Deletar(int id);

    }
}