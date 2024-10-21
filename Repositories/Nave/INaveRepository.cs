using GalaxyControl.Models;

namespace GalaxyControl.Repositories;

public interface INaveRepository
{
    Nave? GetById(int id);
    IEnumerable<Nave> GetAll();
    Nave Create(Nave nave);
    Nave Update(Nave nave);
    bool Delete(int id);
    bool AddTripulante(int id, Tripulante tripulante);
    bool RemoveTripulante(int id, int tripulanteId);
}