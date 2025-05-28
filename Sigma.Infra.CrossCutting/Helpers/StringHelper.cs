using System.Security.Cryptography;
using System.Text;

namespace Sigma.Infra.CrossCutting.Helpers
{
    public static class StringHelper
    {
        private static string chaveSecreta = "Sigm@@pi";

        public static string GerarHash(string valor)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes($"{valor}{chaveSecreta}");
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public static bool VerificarHash(string valor, string hash)
        {
            var hashGerado = GerarHash(valor);
            return hashGerado == hash;
        }
    }
}
