using GalaxyControl.Enums;
using GalaxyControl.Models;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class NaveViewModel
{
    public int Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public string? CodigoRastreio { get; set; }
    public DateTime DataQueda { get; set; }
    public EnumTamanhoNave? Tamanho { get; set; }
    public EnumCorNave? Cor { get; set; }
    public EnumTipoLocalQuedaNave? TipoLocalQueda { get; set; }
    public string? LocalQueda { get; set; }
    public EnumArmamentoNave? Armamento { get; set; }
    public EnumTipoCombustivelNave? TipoCombustivel { get; set; }
    public List<Tripulante>? Tripulante { get; set; }
    public EnumGrauAvariaNave? GrauAvaria { get; set; }
    public EnumPotencialProspeccaoTecnologicaNave? PotencialProspeccaoTecnologica { get; set; }
    public EnumGrauPericulosidadeNave? GrauPericulosidade { get; set; }
}