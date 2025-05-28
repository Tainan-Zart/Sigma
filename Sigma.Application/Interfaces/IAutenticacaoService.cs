using Sigma.Application.Dtos.Login;

namespace Sigma.Application.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<bool> VerificarUsuario(LoginDto login);

        Task<TokenDTo> GerarToken(LoginDto login);
    }
}
