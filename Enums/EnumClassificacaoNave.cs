using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumClassificacaoNave
{
    [Display(Name = "Sucata Espacial")]
    SucataEspacial,

    [Display(Name = "Joia Tecnológica")]
    JoiaTecnologica,

    [Display(Name = "Arsenal Alienígena")]
    ArsenalAlienigena,

    [Display(Name = "Ameaça Em Potencial")]
    AmeacaEmPotencial,

    [Display(Name = "Fonte De Energia Alternativa")]
    FonteDeEnergiaAlternativa,

    [Display(Name = "Mistureba Inconclusiva")]
    MisturebaInconclusiva
}