using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public interface ICityRepository : IDisposable
    {
        Task<IEnumerable<City>> GetCity(int pageSize, int pageNum);
        Task<City> GetCityById(int idcity);
    }
}
