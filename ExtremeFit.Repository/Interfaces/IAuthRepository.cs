using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DTOs;

namespace ExtremeFit.Repository.Interfaces
{
    public interface IAuthRepository
    {
        FuncionarioDomain CadastrarFuncionario(FuncionarioDto funcionarioDto);
        EspecialistaDomain CadastrarEspecialista(EspecialistaDto especialistaDto);
        UsuarioDomain LoginUsuario(string nomeUsuario, string password);
        UsuarioDomain LoginRfid(string rfid);
        UsuarioDomain LoginDigital(string digital);
        bool UsuarioExiste(string nomeUsuario);
        bool CpfCadastrado(string cpf);
        int AtualizarRfid(string rfid, UsuarioDomain usuario);
        int AtualizarDigital(string digital, UsuarioDomain usuario);
    }
}