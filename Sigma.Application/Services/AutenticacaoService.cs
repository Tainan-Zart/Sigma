using Microsoft.Extensions.Configuration;
using Sigma.Application.Dtos.Login;
using Sigma.Application.Interfaces;
using Sigma.Infra.CrossCutting.Auth;

namespace Sigma.Application.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthToken _authToken;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(IUsuarioService usuarioService, IAuthToken authToken, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _authToken = authToken;
            _configuration = configuration;
        }

        public async Task<bool> VerificarUsuario(LoginDto login)
        {
            return await _usuarioService.VerificarLoginSenha(login.Login, login.Senha);
        }

        public async Task<TokenDTo> GerarToken(LoginDto login)
        {
            var usuario = await _usuarioService.BuscarPorLogin(login.Login);
            if (usuario == null)
                return null;

            var chavePrivada = _configuration.GetValue<string>("Jwt:Private-Key");

            var token = _authToken.GetToken(usuario.Login,  chavePrivada);

            var retornoToken = new TokenDTo
            {
                JwtToken = token,
                ExpireIn = (int)TimeSpan.FromHours(1).TotalSeconds,
                TokenType = "BearerToken"
            }; 
            
            return retornoToken;

        }

    }
}
