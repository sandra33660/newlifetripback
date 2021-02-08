using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class AccomodationRepository : IAccomodationRepository
    {
        private SqlConnection db;
        const int pageSizeMin = 1;
        const int pageSizeMax = 50;
        const int pageNumMin = 0;
        const string selectQuery = @"SELECT Accomodation.IdAccommodation, Accomodation.IdCity, Accomodation.NameAccommodation, Accomodation.StyleAccommodation,  Accomodation.NumberPhoneAccommodation,      
                                            Accomodation.AlbumPhotoAccommodation, Accomodation.Price       
                                     FROM Accomodation                                  
                                     ";
        public AccomodationRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<IEnumerable<Accomodation>> GetAccomodation(int pageSize, int pageNum)
        {
            if (pageSize < pageSizeMin || pageSize > pageSizeMax)
            {
                throw new ArgumentOutOfRangeException("PageSize must be in 1-50");
            }
            if (pageNum < pageNumMin)
            {
                throw new ArgumentOutOfRangeException("PageNum must be positive");

            }

            return await db.QueryAsync<Accomodation>
                ($"{selectQuery} ORDER BY Accomodation.IdAccommodation OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY",
                new { PageNum = pageNum, PageSize = pageSize });


        }

        public async Task<Accomodation> GetAccomodationpById(int id) => await db.QueryFirstOrDefaultAsync<Accomodation>($"{selectQuery} WHERE Accomodation.IdAccommodation = @id", new { id = id });

    }
}
