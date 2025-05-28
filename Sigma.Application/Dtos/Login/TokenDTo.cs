namespace Sigma.Application.Dtos.Login
{
    public class TokenDTo
    {
        public string JwtToken { get; set; }

        public int ExpireIn { get; set; }

        public string TokenType { get; set; }
    }
}
