using Movies.Models;

namespace Movies.Data.Repositories
{
    public interface IPeliculasepository
    {
        bool Update(int id);
        bool Create(Pelicula pelicula);
        List<Pelicula> GetAll();
    }
}