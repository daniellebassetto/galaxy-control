using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumTamanhoNave
{
    [Display(Name = "Pequena")]
    Pequena,

    [Display(Name = "Média")]
    Media,

    [Display(Name = "Grande")]
    Grande,

    [Display(Name = "Colossal")]
    Colossal
}