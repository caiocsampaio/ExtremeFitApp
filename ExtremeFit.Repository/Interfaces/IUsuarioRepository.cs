using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
         int Atualizar(UsuarioDto usuarioDto, int id);
    }
}