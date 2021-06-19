using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Models;

namespace FilmsCatalog.Data.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        public Task<Film> Get(int id);
        public IQueryable<Film> GetAll();
        public Task Create(Film film);
        public Task Update(Film film);
        public Task Delete(Film film);
    }
}