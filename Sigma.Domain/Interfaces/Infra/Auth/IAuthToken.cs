using Sigma.Domain.Entities;

namespace Sigma.Domain.Interfaces.Infra.Auth
{
    public interface IAuthToken
    {
        public string GetToken(Usuario usuario, string chavePrivada);
    }
}
