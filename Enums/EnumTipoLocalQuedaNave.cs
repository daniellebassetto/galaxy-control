using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumTipoLocalQuedaNave
{
    [Display(Name = "Continente")]
    Continente,

    [Display(Name = "Oceano")]
    Oceano
}