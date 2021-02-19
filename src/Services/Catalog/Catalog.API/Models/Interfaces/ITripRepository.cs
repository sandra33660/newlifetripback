using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public interface ITripRepository : IDisposable
    {
        Task<IEnumerable<Trip>> GetTrip(int pageSize, int pageNum);
        Task<Trip> GetTripById(int idTrip);
        Task<IEnumerable<Trip>> GetTripByName(string search, int pageSize, int pageNum);

        void RemoveTrip(int id);
        Task<Trip> AddTrip(Trip trip);
        Task<Trip> UpdateTrip(Trip trip);

    }
}
