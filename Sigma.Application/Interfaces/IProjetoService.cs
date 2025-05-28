using Sigma.Application.Dtos.Projeto;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<RetornoProjetoNovoDto> Inserir(ProjetoNovoDto model, string loginUsuario);

        Task<List<RetornoProjetoDto>> Buscar(string loginUsuario);

        Task<RetornoProjetoDto> BuscarPorNomeStatus(BuscaProjetoDto model, string loginUsuario);

        Task<bool> Deletar(long id, string loginUsuario);

        Task<bool> Atualizar(ProjetoDto model, string loginUsuario);
    }
}
