using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> Inserir(Projeto entity);
        Task<List<Projeto>> Buscar(string loginUsuario);

        Task<Projeto?> BuscarPorNomeStatus(string nome, StatusProjetoEnum status, string loginUsuario);

        Task<bool> Atualizar(Projeto entity);

        Task<bool> Deletar(Projeto entity);

        Task<Projeto?> BuscarPorId(long id, string loginUsuario);
    }
}
