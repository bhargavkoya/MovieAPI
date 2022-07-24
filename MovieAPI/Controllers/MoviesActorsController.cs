using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesActorsController : ControllerBase
    {
        private readonly DataContext _context;

        public MoviesActorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MoviesActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoviesActors>>> GetMoviesActors()
        {
            return await _context.MoviesActors.ToListAsync();
        }

        // GET: api/MoviesActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesActors>> GetMoviesActors(int id)
        {
            var moviesActors = await _context.MoviesActors.FindAsync(id);

            if (moviesActors == null)
            {
                return NotFound();
            }

            return moviesActors;
        }

        // PUT: api/MoviesActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesActors(int id, MoviesActors moviesActors)
        {
            if (id != moviesActors.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(moviesActors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesActorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MoviesActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MoviesActors>> PostMoviesActors(MoviesActors moviesActors)
        {
            _context.MoviesActors.Add(moviesActors);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MoviesActorsExists(moviesActors.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMoviesActors", new { id = moviesActors.MovieId }, moviesActors);
        }

        // DELETE: api/MoviesActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoviesActors(int id)
        {
            var moviesActors = await _context.MoviesActors.FindAsync(id);
            if (moviesActors == null)
            {
                return NotFound();
            }

            _context.MoviesActors.Remove(moviesActors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesActorsExists(int id)
        {
            return _context.MoviesActors.Any(e => e.MovieId == id);
        }
    }
}
