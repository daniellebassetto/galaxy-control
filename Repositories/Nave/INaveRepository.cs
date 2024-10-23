using GalaxyControl.Models;

namespace GalaxyControl.Repositories;

public interface INaveRepository
{
    Nave? GetById(int id);
    Nave? GetByCodigoRastreio(string codigoRastreio);
    IEnumerable<Nave> GetAll();
    Nave Create(Nave nave);
    Nave Update(Nave nave);
    bool Delete(Nave nave);
}