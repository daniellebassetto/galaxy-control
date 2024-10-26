using GalaxyControl.Enums;

namespace GalaxyControl.Models;

public class Nave
{
    public int Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public string? CodigoRastreio { get; set; }
    public DateTime DataEncontro { get; set; }
    public EnumTamanhoNave Tamanho { get; set; }
    public EnumCorNave Cor { get; set; }
    public EnumTipoLocalQuedaNave TipoLocalQueda { get; set; }
    public string? LocalQueda { get; set; }
    public EnumArmamentoNave Armamento { get; set; }
    public EnumTipoCombustivelNave TipoCombustivel { get; set; }
    public int TripulantesFeridos { get; set; }
    public int TripulantesSaudaveis { get; set; }
    public int TripulantesSemVida { get; set; }
    public EnumGrauAvariaNave GrauAvaria { get; set; }
    public EnumPotencialProspeccaoTecnologicaNave PotencialProspeccaoTecnologica { get; set; }
    public EnumGrauPericulosidadeNave GrauPericulosidade { get; set; }
    public EnumClassificacaoNave Classificacao { get; set; }
    public EnumStatusReparoNave StatusReparo { get; set; }
}