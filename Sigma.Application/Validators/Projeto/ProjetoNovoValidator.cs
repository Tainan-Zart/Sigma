using FluentValidation;
using Sigma.Application.Dtos.Projeto;

namespace Sigma.Application.Validators.Projeto
{
    public class ProjetoNovoValidator : AbstractValidator<ProjetoNovoDto>
    {
        public ProjetoNovoValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().NotNull().WithMessage("O campo [Nome] é obrigatorio");

            RuleFor(c => c.Descricao).NotEmpty().NotNull().WithMessage("O campo [Descrição] é obrigatorio");

            RuleFor(c => c.DataPrevisaoTermino).NotEmpty().NotNull().WithMessage("O campo [Data de Início] é obrigatorio").GreaterThan(DateTime.MinValue).WithMessage("O campo [Data de Início] deve ser uma data válida");

            RuleFor(c => c.Orcamento).NotEmpty().NotNull().WithMessage("O campo [Orçamento] é obrigatorio").GreaterThan(0).WithMessage("O campo [Orçamento] deve ser maior que zero");

            RuleFor(c => c.ClassificacaoRisco).IsInEnum().WithMessage("O campo [Classificação de Risco] deve ser um valor válido do enum ClassificacaoRiscoProjetoEnum");

            RuleFor(c => c.DataPrevisaoTermino).GreaterThan(DateTime.Now).WithMessage("A [Data de Previsão de Término] deve ser uma data futura");

        }
    }
}
