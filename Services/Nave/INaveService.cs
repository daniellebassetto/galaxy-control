using GalaxyControl.Enums;
using GalaxyControl.ViewModels;

namespace GalaxyControl.Services;

public interface INaveService
{
    List<NaveViewModel>? GetAll();
    NaveViewModel? GetById(int id);
    bool Create(CriarNaveViewModel criarNaveViewModel);
    bool Update(AtualizarNaveViewModel atualizarNaveViewModel);
    bool Delete(int id);
    List<EnumClassificacaoNave> ClassificarNave(EnumGrauAvariaNave grauAvaria, EnumPotencialProspeccaoTecnologicaNave potencialTecnologico, EnumArmamentoNave armamento,
        EnumGrauPericulosidadeNave periculosidade, EnumTipoCombustivelNave combustivel);
}