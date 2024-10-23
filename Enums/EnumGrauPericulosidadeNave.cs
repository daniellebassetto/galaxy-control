using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumGrauPericulosidadeNave
{
    [Display(Name = "Nenhum")]
    Nenhum,

    [Display(Name = "Baixo")]
    Baixo,

    [Display(Name = "Moderado")]
    Moderado,

    [Display(Name = "Alto")]
    Alto,

    [Display(Name = "Crítico")]
    Critico
}