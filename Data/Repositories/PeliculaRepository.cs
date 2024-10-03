using Movies.Models;

namespace Movies.Data.Repositories
{
    public class PeliculaRepository : IPeliculasepository
    {
        PeliculasDbContext _context;
        public PeliculaRepository(PeliculasDbContext context)
        {
            _context = context;
        }
        public bool Create(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            return _context.SaveChanges() > 0;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(x => x.Estreno == true).ToList();
        }

        public bool Update(int id)
        {
            var peliculaUpdate = _context.Peliculas.Find(id);
            if (peliculaUpdate != null)
            {
                peliculaUpdate.Estreno = false;
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
