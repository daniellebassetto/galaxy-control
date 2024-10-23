using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumPotencialProspeccaoTecnologicaNave
{
    [Display(Name = "Inexistente")]
    Inexistente,

    [Display(Name = "Baixo")]
    Baixo,

    [Display(Name = "Moderado")]
    Moderado,

    [Display(Name = "Alto")]
    Alto,

    [Display(Name = "Revolucionário")]
    Revolucionario
}