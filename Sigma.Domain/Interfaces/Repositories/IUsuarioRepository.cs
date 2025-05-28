using Sigma.Domain.Entities;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> Inserir(Usuario cliente);
        Task<Usuario> BuscarPorLogin(string login);
    }
}
