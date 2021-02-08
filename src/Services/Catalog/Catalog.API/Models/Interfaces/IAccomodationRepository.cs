using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public interface IAccomodationRepository : IDisposable
    {
        Task<IEnumerable<Accomodation>> GetAccomodation(int pageSize, int pageNum);
        Task<Accomodation> GetAccomodationpById(int idAccomodation);
    }
}
