using GalaxyControl.Data;
using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyControl.Repositories;

public class NaveRepository(GalaxyControlContext context) : INaveRepository
{
    private readonly GalaxyControlContext _context = context;

    public Nave? GetById(int id)
    {
        return _context.Naves.AsNoTracking().Include(n => n.Tripulante).FirstOrDefault(n => n.Id == id);
    }

    public IEnumerable<Nave> GetAll()
    {
        return _context.Naves.AsNoTracking().Include(n => n.Tripulante).ToList();
    }

    public Nave Create(Nave nave)
    {
        _context.Naves.Add(nave);
        _context.SaveChanges();
        return nave;
    }

    public Nave Update(Nave nave)
    {
        _context.Naves.Update(nave);
        _context.SaveChanges();
        return nave;
    }

    public bool Delete(int id)
    {
        var nave = GetById(id);
        if (nave != null)
        {
            _context.Naves.Remove(nave);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool AddTripulante(int naveId, Tripulante tripulante)
    {
        var nave = GetById(naveId);
        if (nave != null)
        {
            tripulante.NaveId = naveId;
            nave.Tripulante ??= [];
            nave.Tripulante.Add(tripulante);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool RemoveTripulante(int naveId, int tripulanteId)
    {
        var nave = GetById(naveId);
        if (nave != null)
        {
            var tripulante = _context.Tripulantes.Find(tripulanteId);
            if (tripulante != null)
            {
                nave.Tripulante?.Remove(tripulante);
                _context.SaveChanges();
                return true;
            }
        }
        return false;
    }
}