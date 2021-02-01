using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public interface IActivityRepository : IDisposable
    {
        Task<IEnumerable<Activity>> GetActivity(int pageSize, int pageNum);
        Task<Activity> GetActivityById(int idTrip);
    }
}
