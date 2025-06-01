namespace Sigma.Infra.CrossCutting.Auth
{
    public interface IAuthToken
    {
        public string GetToken(string loginUsuario, string chavePrivada);
    }
}
