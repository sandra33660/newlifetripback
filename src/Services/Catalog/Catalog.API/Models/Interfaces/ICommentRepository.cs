using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public interface ICommentRepository : IDisposable
    {
        Task<IEnumerable<Comment>> GetComment(int pageSize, int pageNum);
        Task<Comment> GetCommentById(int idTrip);
    }
}
