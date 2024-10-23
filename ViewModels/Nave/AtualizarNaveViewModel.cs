using GalaxyControl.Enums;
using GalaxyControl.Models;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class AtualizarNaveViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a data de queda")]
    public DateTime DataEncontro { get; set; }

    [Required(ErrorMessage = "Informe o tamanho")]
    public EnumTamanhoNave Tamanho { get; set; }

    [Required(ErrorMessage = "Informe a cor da nave")]
    public EnumCorNave Cor { get; set; }

    [Required(ErrorMessage = "Informe o tipo do local de queda")]
    public EnumTipoLocalQuedaNave TipoLocalQueda { get; set; }

    [Required(ErrorMessage = "Informe o local de queda")]
    public string? LocalQueda { get; set; }

    [Required(ErrorMessage = "Informe o tipo de armamento")]
    public EnumArmamentoNave Armamento { get; set; }

    [Required(ErrorMessage = "Informe o tipo de combustível")]
    public EnumTipoCombustivelNave TipoCombustivel { get; set; }

    [Required(ErrorMessage = "Informe a tripulação")]
    public List<Tripulante>? Tripulante { get; set; }

    [Required(ErrorMessage = "Informe o grau de avaria")]
    public EnumGrauAvariaNave GrauAvaria { get; set; }

    [Required(ErrorMessage = "Informe o potencial de prospecção tecnológica")]
    public EnumPotencialProspeccaoTecnologicaNave PotencialProspeccaoTecnologica { get; set; }

    [Required(ErrorMessage = "Informe o grau de periculosidade")]
    public EnumGrauPericulosidadeNave GrauPericulosidade { get; set; }
}