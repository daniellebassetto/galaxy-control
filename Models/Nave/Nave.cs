using GalaxyControl.Enums;

namespace GalaxyControl.Models;

public class Nave
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

    public List<EnumClassificacaoNave> ClassificarNave()
    {
        var classificacoes = new List<EnumClassificacaoNave>();

        // Critério 1: Se a nave está muito destruída ou com perda total e possui pouco ou nenhum valor tecnológico, é Sucata Espacial
        if ((GrauAvaria == EnumGrauAvariaNave.MuitoDestruida || GrauAvaria == EnumGrauAvariaNave.PerdaTotal) &&
            (PotencialProspeccaoTecnologica == EnumPotencialProspeccaoTecnologicaNave.Inexistente || PotencialProspeccaoTecnologica == EnumPotencialProspeccaoTecnologicaNave.Baixo))
            classificacoes.Add(EnumClassificacaoNave.SucataEspacial);

        // Critério 2: Se o potencial de prospecção tecnológica é alto, é uma Joia Tecnológica
        if (PotencialProspeccaoTecnologica == EnumPotencialProspeccaoTecnologicaNave.Alto)
            classificacoes.Add(EnumClassificacaoNave.JoiaTecnologica);

        // Critério 3: Se a nave possui armamento pesado, é um Arsenal Alienígena
        if (Armamento == EnumArmamentoNave.Pesado)
            classificacoes.Add(EnumClassificacaoNave.ArsenalAlienigena);

        // Critério 4: Se o grau de periculosidade é alto, é uma Ameaça em Potencial
        if (GrauPericulosidade == EnumGrauPericulosidadeNave.Alto)
            classificacoes.Add(EnumClassificacaoNave.AmeacaEmPotencial);

        // Critério 5: Se o combustível é de uma tecnologia única ou incomum, pode ser uma Fonte de Energia Alternativa
        if (TipoCombustivel == EnumTipoCombustivelNave.Alternativo)
            classificacoes.Add(EnumClassificacaoNave.FonteDeEnergiaAlternativa);

        // Se nenhuma classificação for encontrada, adicionar "Mistureba"
        if (classificacoes.Count == 0)
            classificacoes.Add(EnumClassificacaoNave.MisturebaInconclusiva);

        return classificacoes;
    }
}