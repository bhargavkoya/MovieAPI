using Microsoft.EntityFrameworkCore;
using MovieAPI.Interfaces;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
             _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;

        }

        public void EditMovieById(int Id, Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            foreach (var i in movie.Actors) {
                MoviesActors moviesActors = new MoviesActors();
                moviesActors.ActorId = i.ActorId;
                moviesActors.MovieId = i.MovieId;
               _context.Entry(moviesActors).State = EntityState.Modified;
                _context.SaveChanges();
            }

        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.Include(p => p.Producer).Include(a => a.Actors).ThenInclude(a => a.Actor).ThenInclude(a => a.Movies).FirstOrDefaultAsync(i=>i.Id==id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.Include(p=>p.Producer).Include(a=>a.Actors).ThenInclude(a=>a.Actor).ThenInclude(a=>a.Movies).ToListAsync();
        }

        public  bool MovieExists(int id)
        {
            return  _context.Movies.Any(e => e.Id == id);
        }

        public async void RemoveMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {

                _context.Movies.Remove(movie);

                await _context.SaveChangesAsync();
            }


        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
