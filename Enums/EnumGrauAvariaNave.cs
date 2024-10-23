using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumGrauAvariaNave
{
    [Display(Name = "Perda Total")]
    PerdaTotal,

    [Display(Name = "Muito Destruída")]
    MuitoDestruida,

    [Display(Name = "Parcialmente Destruída")]
    ParcialmenteDestruida,

    [Display(Name = "Praticamente Intacta")]
    PraticamenteIntacta,

    [Display(Name = "Sem Avarias")]
    SemAvarias
}