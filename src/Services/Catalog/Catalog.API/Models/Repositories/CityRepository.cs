using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class CityRepository : ICityRepository
    {
        private SqlConnection db;
        const int pageSizeMin = 1;
        const int pageSizeMax = 50;
        const int pageNumMin = 0;
        const string selectQuery = @"SELECT City.IdCity, City.NameCity, City.ZIPCode, City.Departments,  City.Regions,      
                                            City.NameTrip, City.AlbumPhotoTrip
                                     FROM City                                  
                                     ";
        public CityRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<IEnumerable<City>> GetCity(int pageSize, int pageNum)
        {
            if (pageSize < pageSizeMin || pageSize > pageSizeMax)
            {
                throw new ArgumentOutOfRangeException("PageSize must be in 1-50");
            }
            if (pageNum < pageNumMin)
            {
                throw new ArgumentOutOfRangeException("PageNum must be positive");

            }

            return await db.QueryAsync<City>
                ($"{selectQuery} ORDER BY City.IdCity OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY",
                new { PageNum = pageNum, PageSize = pageSize });


        }

        public async Task<City> GetCityById(int id) => await db.QueryFirstOrDefaultAsync<City>($"{selectQuery} WHERE City.IdCity = @id", new { id = id });
        public async Task<City> GetCityByNameCountry(string searchCity) => await db.QueryFirstOrDefaultAsync<City>($"{selectQuery} WHERE City.NameCity LIKE @SearchCity", new { SearchCity = searchCity + "%" });


    }
}
