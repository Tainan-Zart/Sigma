using Sigma.Domain.Enums;

namespace Sigma.Application.Dtos.Projeto
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Orcamento { get; set; }

        public StatusProjetoEnum? Status { get; set; }

        public ClassificacaoRiscoProjetoEnum ClassificacaoRisco { get; set; }

        public DateTime DataPrevisaoTermino { get; set; }

        public DateTime? DataTermino { get; set; }
    }
}
