using Sigma.Domain.Enums;

namespace Sigma.Domain.Entities
{
    public class Projeto
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataPrevisaoTermino { get; set; }

        public DateTime? DataTermino { get; set; }

        public decimal Orcamento { get; set; }

        public ClassificacaoRiscoProjetoEnum ClassificacaoRisco { get; set; }

        public StatusProjetoEnum Status { get; set; }

        public long UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
