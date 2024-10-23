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
            Tripulante = criarNaveViewModel.Tripulante,
            GrauAvaria = criarNaveViewModel.GrauAvaria,
            PotencialProspeccaoTecnologica = criarNaveViewModel.PotencialProspeccaoTecnologica,
            GrauPericulosidade = criarNaveViewModel.GrauPericulosidade
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
            Tripulante = x.Tripulante,
            GrauAvaria = x.GrauAvaria,
            PotencialProspeccaoTecnologica = x.PotencialProspeccaoTecnologica,
            GrauPericulosidade = x.GrauPericulosidade
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
            Tripulante = nave.Tripulante,
            GrauAvaria = nave.GrauAvaria,
            PotencialProspeccaoTecnologica = nave.PotencialProspeccaoTecnologica,
            GrauPericulosidade = nave.GrauPericulosidade
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
        nave.Tripulante = atualizarNaveViewModel.Tripulante;
        nave.GrauAvaria = atualizarNaveViewModel.GrauAvaria;
        nave.PotencialProspeccaoTecnologica = atualizarNaveViewModel.PotencialProspeccaoTecnologica;
        nave.GrauPericulosidade = atualizarNaveViewModel.GrauPericulosidade;

        _repository.Update(nave);
        return true;
    }
}