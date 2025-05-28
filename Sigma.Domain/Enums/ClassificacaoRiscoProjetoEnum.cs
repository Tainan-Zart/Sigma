using System.ComponentModel.DataAnnotations;

namespace Sigma.Domain.Enums
{
    public enum ClassificacaoRiscoProjetoEnum
    {
        [Display(Name = "Baixo")]
        Baixo = 1,

        [Display(Name = "Médio")]
        Medio = 2,

        [Display(Name = "Alto")]
        Alto = 3,
    }
}
