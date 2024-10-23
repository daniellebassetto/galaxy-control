using GalaxyControl.ViewModels;
using GalaxyControl.ViewModels.Nave;

namespace GalaxyControl.Services;

public interface INaveService
{
    List<NaveViewModel>? GetAll();
    NaveViewModel? GetById(int id);
    bool Create(CriarNaveViewModel criarNaveViewModel);
    bool Update(AtualizarNaveViewModel atualizarNaveViewModel);
    bool Delete(int id);
}