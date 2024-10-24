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
    AmeacaPotencial,

    [Display(Name = "Fonte De Energia Alternativa")]
    FonteEnergiaAlternativa,

    [Display(Name = "Mistureba Inconclusiva")]
    MisturebaInconclusiva
}