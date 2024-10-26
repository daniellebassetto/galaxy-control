using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumArmamentoNave
{
    [Display(Name = "Nenhum")]
    Nenhum,

    [Display(Name = "Leve")]
    Leve,

    [Display(Name = "Moderado")]
    Moderado,

    [Display(Name = "Pesado")]
    Pesado
}