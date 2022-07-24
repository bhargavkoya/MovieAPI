using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActorsAsync();
        Task<Actor> GetActorById(int id);
        void AddActor(Actor actor);
        void RemoveActorById(int id);
        void EditActorById(int Id, Actor actor);
    }
}
