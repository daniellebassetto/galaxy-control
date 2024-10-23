using GalaxyControl.Data;
using GalaxyControl.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxyControl.Repositories;

public class NaveRepository(GalaxyControlContext context) : INaveRepository
{
    private readonly GalaxyControlContext _context = context;

    public Nave? GetById(int id)
    {
        return _context.Naves.AsNoTracking().FirstOrDefault(n => n.Id == id);
    }

    public Nave? GetByCodigoRastreio(string codigoRastreio)
    {
        return _context.Naves.AsNoTracking().FirstOrDefault(n => n.CodigoRastreio == codigoRastreio);
    }

    public IEnumerable<Nave> GetAll()
    {
        return [.. _context.Naves.AsNoTracking()];
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

    public bool Delete(Nave nave)
    {
        _context.Naves.Remove(nave);
        _context.SaveChanges();
        return true;
    }
}