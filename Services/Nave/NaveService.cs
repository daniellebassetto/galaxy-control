using GalaxyControl.Enums;
using GalaxyControl.Models;
using GalaxyControl.Repositories;
using GalaxyControl.ViewModels;

namespace GalaxyControl.Services;

public class NaveService(INaveRepository repository) : INaveService
{
    private readonly INaveRepository _repository = repository;

    public bool Create(CriarNaveViewModel criarNaveViewModel)
    {
        Nave? nave = _repository.GetByCodigoRastreio(criarNaveViewModel.CodigoRastreio!);

        if (nave is not null)
            throw new Exception("Essa nave já foi registrada");

        var novaNave = new Nave()
        {
            DataCadastro = DateTime.Now,
            CodigoRastreio = criarNaveViewModel.CodigoRastreio,
            DataEncontro = criarNaveViewModel.DataEncontro,
            Tamanho = criarNaveViewModel.Tamanho,
            Cor = criarNaveViewModel.Cor,
            TipoLocalQueda = criarNaveViewModel.TipoLocalQueda,
            LocalQueda = criarNaveViewModel.LocalQueda,
            Armamento = criarNaveViewModel.Armamento,
            TipoCombustivel = criarNaveViewModel.TipoCombustivel,
            TripulantesFeridos = criarNaveViewModel.TripulantesFeridos,
            TripulantesSaudaveis = criarNaveViewModel.TripulantesSaudaveis,
            TripulantesSemVida = criarNaveViewModel.TripulantesSemVida,
            GrauAvaria = criarNaveViewModel.GrauAvaria,
            PotencialProspeccaoTecnologica = criarNaveViewModel.PotencialProspeccaoTecnologica,
            GrauPericulosidade = criarNaveViewModel.GrauPericulosidade,
            Classificacao = criarNaveViewModel.Classificacao!.Value
        };

        _repository.Create(novaNave);
        return true;
    }

    public bool Delete(int id)
    {
        Nave? nave = _repository.GetById(id) ?? throw new Exception("Nave não encontrada");
        _repository.Delete(nave);
        return true;
    }

    public List<NaveViewModel>? GetAll()
    {
        return _repository.GetAll()?.Select(x => new NaveViewModel()
        {
            Id = x.Id,
            DataCadastro = x.DataCadastro,
            DataAlteracao = x.DataAlteracao,
            CodigoRastreio = x.CodigoRastreio,
            DataEncontro = x.DataEncontro,
            Tamanho = x.Tamanho,
            Cor = x.Cor,
            TipoLocalQueda = x.TipoLocalQueda,
            LocalQueda = x.LocalQueda,
            Armamento = x.Armamento,
            TipoCombustivel = x.TipoCombustivel,
            TripulantesFeridos = x.TripulantesFeridos,
            TripulantesSaudaveis = x.TripulantesSaudaveis,
            TripulantesSemVida = x.TripulantesSemVida,
            GrauAvaria = x.GrauAvaria,
            PotencialProspeccaoTecnologica = x.PotencialProspeccaoTecnologica,
            GrauPericulosidade = x.GrauPericulosidade,
            Classificacao = x.Classificacao
        }).ToList();
    }

    public NaveViewModel? GetById(int id)
    {
        var nave = _repository.GetById(id);
        return nave is not null ? new NaveViewModel()
        {
            Id = nave.Id,
            DataCadastro = nave.DataCadastro,
            DataAlteracao = nave.DataAlteracao,
            CodigoRastreio = nave.CodigoRastreio,
            DataEncontro = nave.DataEncontro,
            Tamanho = nave.Tamanho,
            Cor = nave.Cor,
            TipoLocalQueda = nave.TipoLocalQueda,
            LocalQueda = nave.LocalQueda,
            Armamento = nave.Armamento,
            TipoCombustivel = nave.TipoCombustivel,
            TripulantesFeridos = nave.TripulantesFeridos,
            TripulantesSaudaveis = nave.TripulantesSaudaveis,
            TripulantesSemVida = nave.TripulantesSemVida,
            GrauAvaria = nave.GrauAvaria,
            PotencialProspeccaoTecnologica = nave.PotencialProspeccaoTecnologica,
            GrauPericulosidade = nave.GrauPericulosidade,
            Classificacao = nave.Classificacao
        } : null;
    }

    public bool Update(AtualizarNaveViewModel atualizarNaveViewModel)
    {
        Nave? nave = _repository.GetById(atualizarNaveViewModel.Id!) ?? throw new Exception("Nave não encontrada");

        nave.DataAlteracao = DateTime.Now;
        nave.DataEncontro = atualizarNaveViewModel.DataEncontro;
        nave.Tamanho = atualizarNaveViewModel.Tamanho;
        nave.Cor = atualizarNaveViewModel.Cor;
        nave.TipoLocalQueda = atualizarNaveViewModel.TipoLocalQueda;
        nave.LocalQueda = atualizarNaveViewModel.LocalQueda;
        nave.Armamento = atualizarNaveViewModel.Armamento;
        nave.TipoCombustivel = atualizarNaveViewModel.TipoCombustivel;
        nave.TripulantesFeridos = atualizarNaveViewModel.TripulantesFeridos;
        nave.TripulantesSaudaveis = atualizarNaveViewModel.TripulantesSaudaveis;
        nave.TripulantesSemVida = atualizarNaveViewModel.TripulantesSemVida;
        nave.GrauAvaria = atualizarNaveViewModel.GrauAvaria;
        nave.PotencialProspeccaoTecnologica = atualizarNaveViewModel.PotencialProspeccaoTecnologica;
        nave.GrauPericulosidade = atualizarNaveViewModel.GrauPericulosidade;
        nave.Classificacao = atualizarNaveViewModel.Classificacao;

        _repository.Update(nave);
        return true;
    }

    public List<EnumClassificacaoNave> ClassificarNave(EnumGrauAvariaNave grauAvaria, EnumPotencialProspeccaoTecnologicaNave potencialTecnologico, EnumArmamentoNave armamento, 
        EnumGrauPericulosidadeNave periculosidade, EnumTipoCombustivelNave combustivel)
    {
        var classificacoes = new List<EnumClassificacaoNave>();

        // Critério 1: Se a nave está muito destruída ou com perda total e possui pouco ou nenhum valor tecnológico, é Sucata Espacial
        if ((grauAvaria == EnumGrauAvariaNave.MuitoDestruida || grauAvaria == EnumGrauAvariaNave.PerdaTotal) &&
            (potencialTecnologico == EnumPotencialProspeccaoTecnologicaNave.Inexistente || potencialTecnologico == EnumPotencialProspeccaoTecnologicaNave.Baixo))
            classificacoes.Add(EnumClassificacaoNave.SucataEspacial);

        // Critério 2: Se o potencial de prospecção tecnológica é alto, é uma Joia Tecnológica
        if (potencialTecnologico == EnumPotencialProspeccaoTecnologicaNave.Alto)
            classificacoes.Add(EnumClassificacaoNave.JoiaTecnologica);

        // Critério 3: Se a nave possui armamento pesado, é um Arsenal Alienígena
        if (armamento == EnumArmamentoNave.Pesado)
            classificacoes.Add(EnumClassificacaoNave.ArsenalAlienigena);

        // Critério 4: Se o grau de periculosidade é alto, é uma Ameaça em Potencial
        if (periculosidade == EnumGrauPericulosidadeNave.Alto)
            classificacoes.Add(EnumClassificacaoNave.AmeacaEmPotencial);

        // Critério 5: Se o combustível é de uma tecnologia única ou incomum, pode ser uma Fonte de Energia Alternativa
        if (combustivel == EnumTipoCombustivelNave.Alternativo)
            classificacoes.Add(EnumClassificacaoNave.FonteDeEnergiaAlternativa);

        // Se nenhuma classificação for encontrada, adicionar "Mistureba"
        if (classificacoes.Count == 0)
            classificacoes.Add(EnumClassificacaoNave.MisturebaInconclusiva);

        return classificacoes;
    }
}