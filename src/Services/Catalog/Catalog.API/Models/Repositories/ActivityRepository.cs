using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace Catalog.API.Models
{
    public class ActivityRepository : IActivityRepository
    {
        private SqlConnection db;
        const int pageSizeMin = 1;
        const int pageSizeMax = 50;
        const int pageNumMin = 0;
        const string selectQuery = @"SELECT Activity.IdActivity, Activity.StartDate, Activity.FinalDate, Activity.NumberOfPlacesTotal,  Activity.Price,      
                                            Activity.ActivitiesPhotoAlbum
                                     FROM Activity                                  
                                     ";
        public ActivityRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<IEnumerable<Activity>> GetActivity(int pageSize, int pageNum)
        {
            if (pageSize < pageSizeMin || pageSize > pageSizeMax)
            {
                throw new ArgumentOutOfRangeException("PageSize must be in 1-50");
            }
            if (pageNum < pageNumMin)
            {
                throw new ArgumentOutOfRangeException("PageNum must be positive");

            }

            return await db.QueryAsync<Activity>
                ($"{selectQuery} ORDER BY Activity.IdActivity OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY",
                new { PageNum = pageNum, PageSize = pageSize });


        }

        public async Task<Activity> GetActivityById(int id) => await db.QueryFirstOrDefaultAsync<Activity>($"{selectQuery} WHERE Activity.IdActivity = @id", new { id = id });


    }
}
