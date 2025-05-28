using Sigma.Domain.Enums;

namespace Sigma.Application.Dtos.Projeto
{
    public class ProjetoNovoDto
    {
        public string Nome { get; set; } 
        
        public string Descricao { get; set; }

        public DateTime DataPrevisaoTermino { get; set; }

        public decimal Orcamento { get; set; }

        public ClassificacaoRiscoProjetoEnum ClassificacaoRisco { get; set; }
    }
}
