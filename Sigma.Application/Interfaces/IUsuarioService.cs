using Sigma.Application.Dtos.Usuario;
using Sigma.Domain.Entities;

namespace Sigma.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Cadastrar(UsuarioDto clienteDto);

        Task<Usuario> BuscarPorLogin(string login);

        Task<bool> VerificarLogin(string login);

        Task<bool> VerificarLoginSenha(string login, string senha);
    }
}
