using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Enums;

public enum EnumStatusReparoNave
{
    [Display(Name = "Aguardando")]
    Aguardando,
    [Display(Name = "Em Andamento")]
    EmAndamento,
    [Display(Name = "Finalizado")]
    Finalizado
}