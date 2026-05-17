namespace StellarMinds.Infraestructura.EF
{
    //public class RepositorioEquipo : IRepositorioEquipo
    //{
    //    StellarMindContext _context = new StellarMindContext();
    //    public void Add(Equipo Obj)
    //    {
    //        if (Obj == null) throw new Exception("El equipo no puede ser nulo.");
    //        _context.Equipos.Add(Obj);
    //        _context.SaveChanges();
    //    }

    //    public void Delete(int Id)
    //    {
    //        Equipo unEquipo = GetById(Id);
    //        _context.Equipos.Remove(unEquipo);
    //        _context.SaveChanges();
    //    }

    //    public IEnumerable<Equipo> GetAll()
    //    {
    //        return _context.Equipos.ToList();
    //    }

    //    public Equipo GetById(int id)
    //    {
    //        Equipo unEquipo = _context.Equipos.Find(id);
    //        if (unEquipo == null) throw new Exception("El equipo no existe.");
    //        return unEquipo;
    //    }

    //    public void Update(int id, Equipo obj)
    //    {
    //        Equipo unEquipo = GetById(id);
    //        unEquipo.Update(obj);
    //        _context.Equipos.Update(unEquipo);
    //        _context.SaveChanges();
    //    }
    //}
}
