using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumEstadoTripulante
{
    [Display(Name = "Sadio")]
    Sadio,

    [Display(Name = "Ferido")]
    Ferido,

    [Display(Name = "Óbito")]
    Obito
}