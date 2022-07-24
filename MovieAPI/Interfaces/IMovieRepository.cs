using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Interfaces
{
    public interface IMovieRepository
    {

        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        void RemoveMovieById(int id);
        void EditMovieById(int Id,Movie movie);
        void SaveChangesAsync();

        bool MovieExists(int id);
    }
}
