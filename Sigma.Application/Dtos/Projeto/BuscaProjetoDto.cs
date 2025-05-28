using Sigma.Domain.Enums;

namespace Sigma.Application.Dtos.Projeto
{
    public class BuscaProjetoDto
    {
        public string Nome { get; set; }

        public StatusProjetoEnum Status { get; set; }
    }
}
