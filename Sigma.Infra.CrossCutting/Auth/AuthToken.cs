using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Sigma.Infra.CrossCutting.Auth
{
    public class AuthToken : IAuthToken
    {
        public string GetToken(string loginUsuario, string chavePrivada)
        {
            var handler = new JwtSecurityTokenHandler();

            var chave = Encoding.UTF8.GetBytes(chavePrivada);

            var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, loginUsuario),
            };

            var descricaoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credenciais,
                Expires = DateTime.UtcNow.AddHours(1),
            };

            var token = handler.CreateToken(descricaoToken);

            return handler.WriteToken(token);
        }
    }
}
