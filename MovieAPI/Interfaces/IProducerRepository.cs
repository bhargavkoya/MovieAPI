using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Interfaces
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> GetProducersAsync();
        Task<Producer> GetProducerById(int id);
        void AddProducer(Producer producer);
        void RemoveProducerById(int id);
        void EditProducerById(int Id, Producer producer);
    }
}
