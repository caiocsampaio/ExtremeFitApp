using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;

namespace ExtremeFit.Repository.Repositories
{
    public class UsuarioRepository : AuthRepository, IUsuarioRepository
    {
        private readonly ApiContext _context;
        public UsuarioRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public int Atualizar(UsuarioDto usuarioDto, int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if(usuario == null)
                return 0;
            
            UsuarioDomain novoUsuario = CriarUsuario(usuarioDto);
            
            usuario.Email = novoUsuario.Email;
            usuario.PasswordHash = novoUsuario.PasswordHash;
            usuario.PasswordSalt = novoUsuario.PasswordSalt;
            usuario.Digital = novoUsuario.Digital;
            usuario.Rfid = novoUsuario.Rfid;

            _context.Usuarios.Update(usuario);

            return _context.SaveChanges();
        }
    }
}