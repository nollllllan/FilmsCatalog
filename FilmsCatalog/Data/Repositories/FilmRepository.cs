using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Data.Repositories.Interfaces;
using FilmsCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Film> Get(int id) => await _context.Films.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Film> GetAll() => _context.Films.Include(x => x.User);

        public async Task Create(Film film)
        {
            await _context.AddAsync(film);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Film film)
        {
            _context.Films.Update(film);
            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Film film)
        {
            _context.Films.Remove(film);

            await _context.SaveChangesAsync();
        }
    }
}