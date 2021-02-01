using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class CommentRepository : ICommentRepository
    {
        private SqlConnection db;
        const int pageSizeMin = 1;
        const int pageSizeMax = 50;
        const int pageNumMin = 0;
        const string selectQuery = @"SELECT Comment.IdComment, Comment.IdCustomer, Comment.TitleComment, Comment.ContentComment,  Comment.Star,      
                                            Comment.CategoryComment
                                     FROM Comment                                  
                                     ";
        public CommentRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<IEnumerable<Comment>> GetComment(int pageSize, int pageNum)
        {
            if (pageSize < pageSizeMin || pageSize > pageSizeMax)
            {
                throw new ArgumentOutOfRangeException("PageSize must be in 1-50");
            }
            if (pageNum < pageNumMin)
            {
                throw new ArgumentOutOfRangeException("PageNum must be positive");

            }

            return await db.QueryAsync<Comment>
                ($"{selectQuery} ORDER BY Comment.IdComment OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY",
                new { PageNum = pageNum, PageSize = pageSize });


        }

        public async Task<Comment> GetCommentById(int id) => await db.QueryFirstOrDefaultAsync<Comment>($"{selectQuery} WHERE Comment.IdComment = @id", new { id = id });


    }
}
