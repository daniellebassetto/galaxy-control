using GalaxyControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class CriarNaveViewModel
{
    [Required(ErrorMessage = "Informe um código de rastreio")]
    [Length(3, 10, ErrorMessage = "O código de rastreio deve ter de 3 a 10 caracteres")]
    public string? CodigoRastreio { get; set; }

    [Required(ErrorMessage = "Informe a data de queda")]
    public DateTime DataEncontro { get; set; }

    [Required(ErrorMessage = "Informe o tamanho")]
    public EnumTamanhoNave Tamanho { get; set; }

    [Required(ErrorMessage = "Informe a cor da nave")]
    public EnumCorNave Cor { get; set; }

    [Required(ErrorMessage = "Informe o tipo do local de queda")]
    public EnumTipoLocalQuedaNave TipoLocalQueda { get; set; }

    [Required(ErrorMessage = "Informe o local de queda")]
    [MaxLength(30, ErrorMessage = "O local de queda deve ter de 1 a 30 caracteres")]
    public string? LocalQueda { get; set; }

    [Required(ErrorMessage = "Informe o tipo de armamento")]
    public EnumArmamentoNave Armamento { get; set; }

    [Required(ErrorMessage = "Informe o tipo de combustível")]
    public EnumTipoCombustivelNave TipoCombustivel { get; set; }

    [Required(ErrorMessage = "Informe o total de tripulantes feridos")]
    public int TripulantesFeridos { get; set; }

    [Required(ErrorMessage = "Informe o total de tripulantes saudaveis")]
    public int TripulantesSaudaveis { get; set; }

    [Required(ErrorMessage = "Informe o total de tripulantes sem vida")]
    public int TripulantesSemVida { get; set; }

    [Required(ErrorMessage = "Informe o grau de avaria")]
    public EnumGrauAvariaNave GrauAvaria { get; set; }

    [Required(ErrorMessage = "Informe o potencial de prospecção tecnológica")]
    public EnumPotencialProspeccaoTecnologicaNave PotencialProspeccaoTecnologica { get; set; }

    [Required(ErrorMessage = "Informe o grau de periculosidade")]
    public EnumGrauPericulosidadeNave GrauPericulosidade { get; set; }
    public EnumClassificacaoNave? Classificacao { get; set; }
}
