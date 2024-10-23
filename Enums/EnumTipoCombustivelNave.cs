using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumTipoCombustivelNave
{
    [Display(Name = "Nenhum")]
    Nenhum,

    [Display(Name = "Convencional")]
    Convencional,

    [Display(Name = "Alternativo")]
    Alternativo,

    [Display(Name = "Experimental")]
    Experimental
}