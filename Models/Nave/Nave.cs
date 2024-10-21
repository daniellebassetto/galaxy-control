using GalaxyControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class Nave
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe um código de rastreio")]
    public string? CodigoRastreio { get; set; }

    [Required(ErrorMessage = "Informe a data de queda")]
    public DateTime DataQueda { get; set; }

    [Required(ErrorMessage = "Informe o tamanho")]
    public EnumTamanhoNave? Tamanho { get; set; }

    [Required(ErrorMessage = "Informe a cor da nave")]
    public EnumCorNave? Cor { get; set; }

    [Required(ErrorMessage = "Informe o tipo do local de queda")]
    public EnumTipoLocalQuedaNave? TipoLocalQueda { get; set; }

    [Required(ErrorMessage = "Informe o local de queda")]
    public string? LocalQueda { get; set; }

    [Required(ErrorMessage = "Informe o tipo de armamento")]
    public EnumArmamentoNave? Armamento { get; set; }

    [Required(ErrorMessage = "Informe o tipo de combustível")]
    public EnumTipoCombustivelNave? TipoCombustivel { get; set; }

    [Required(ErrorMessage = "Informe a tripulação")]
    public List<Tripulante>? Tripulante { get; set; }

    [Required(ErrorMessage = "Informe o grau de avaria")]
    public EnumGrauAvariaNave? GrauAvaria { get; set; }

    [Required(ErrorMessage = "Informe o potencial de prospecção tecnológica")]
    public EnumPotencialProspeccaoTecnologicaNave? PotencialProspeccaoTecnologica { get; set; }

    [Required(ErrorMessage = "Informe o grau de periculosidade")]
    public EnumGrauPericulosidadeNave? GrauPericulosidade { get; set; }

    public EnumClassificacaoNave ClassificarNave()
    {
        // Critério 1: Se a nave está muito destruída ou com perda total, é Sucata Espacial
        if (GrauAvaria == EnumGrauAvariaNave.MuitoDestruida || GrauAvaria == EnumGrauAvariaNave.PerdaTotal)
            return EnumClassificacaoNave.SucataEspacial;

        // Critério 2: Se o potencial de prospecção tecnológica é alto, é uma Joia Tecnológica
        if (PotencialProspeccaoTecnologica == EnumPotencialProspeccaoTecnologicaNave.Alto)
            return EnumClassificacaoNave.JoiaTecnologica;

        // Critério 3: Se a nave possui armamento pesado, é um Arsenal Alienígena
        if (Armamento == EnumArmamentoNave.Pesado || Armamento == EnumArmamentoNave.Moderado)
            return EnumClassificacaoNave.ArsenalAlienigena;

        // Critério 4: Se o grau de periculosidade é alto, é uma Ameaça em Potencial
        if (GrauPericulosidade == EnumGrauPericulosidadeNave.Alto)
            return EnumClassificacaoNave.AmeaçaEmPotencial;

        // Critério 5: Se o combustível é de uma tecnologia única ou incomum, pode ser uma Fonte de Energia Alternativa
        if (TipoCombustivel == EnumTipoCombustivelNave.Alternativo || TipoCombustivel == EnumTipoCombustivelNave.Convencional)
            return EnumClassificacaoNave.FonteDeEnergiaAlternativa;

        // Caso nenhuma outra classificação seja identificada
        return EnumClassificacaoNave.Mistureba;
    }
}