using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class TripRepository : ITripRepository
    {
        private SqlConnection db;
        const int pageSizeMin = 1;
        const int pageSizeMax = 50;
        const int pageNumMin = 0;
        const string selectQuery = @"SELECT Trip.IdTrip, Trip.Details, Trip.Title, Trip.StartDate,  Trip.FinalDate,      
                                            Trip.Price, Trip.NumberOfParticipants,Photo.Photos
                                     FROM Trip 
                                     INNER JOIN Photo ON Trip.IdTrip = Photo.IdTrip
                                     
                                     ";
        const string addQuery = @"USE [new_life_trip]
GO

INSERT INTO [dbo].[Trip]
           ([IdComment]
           ,[IdCustomer]
           ,[IdActivityTrip]
           ,[Details]
           ,[Title]
           ,[StartDate]
           ,[FinalDate]
           ,[Price]
           ,[NumberOfParticipants])
     VALUES
           (@IdComment
           ,@IdCustomer
           ,@IdActivityTrip
           ,@Details
           ,@Title
           ,@StartDate
           ,@FinalDate
           ,@Price
           ,@NumberOfParticipants)
GO";
        const string updateQuery = @"USE [new_life_trip]
GO

UPDATE [dbo].[Trip]
   SET [@champs] = @value
 WHERE <@IdTrip=@idTrip>
GO";
        private List<Trip> _trip = new List<Trip>();
        public TripRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            db.Dispose();
        }





        public async Task<IEnumerable<Trip>> GetTrip(int pageSize, int pageNum)
        {
            if (pageSize < pageSizeMin || pageSize > pageSizeMax)
            {
                throw new ArgumentOutOfRangeException("PageSize must be in 1-50");
            }
            if (pageNum < pageNumMin)
            {
                throw new ArgumentOutOfRangeException("PageNum must be positive");

            }

            return await db.QueryAsync<Trip>
                ($"{selectQuery} ORDER BY Trip.IdTrip OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY",
                new { PageNum = pageNum, PageSize = pageSize });

        }

        public async Task<Trip> GetTripById(int id) => await db.QueryFirstOrDefaultAsync<Trip>($"{selectQuery} WHERE Trip.IdTrip = @id", new { id = id });

        public async Task<IEnumerable<Trip>> GetTripByName(string searchTrip, int pageSize, int pageNum)
        {
            if (pageSize < pageSizeMin || pageSize > pageSizeMax)
            {
                throw new ArgumentOutOfRangeException("PageSize must be in 1-50");
            }
            if (pageNum < pageNumMin)
            {
                throw new ArgumentOutOfRangeException("PageNum must be positive");

            }

            return await db.QueryAsync<Trip>
                ($"{selectQuery} WHERE Trip.Title LIKE @SearchTrip",
                new { SearchTrip = searchTrip + "%", PageNum = pageNum, PageSize = pageSize });

        }
        public async Task<Trip> AddTrip(Trip trip)
        {
            if (!trip.IdTrip.HasValue)
            {
                throw new ArgumentNullException("Le voyage n'a pas d'identifiant");
            }

            var catalogTrip = new Trip() { IdTrip = trip.IdTrip };

            int id = await db.ExecuteScalarAsync<int>($"{addQuery}", catalogTrip);
            catalogTrip.IdTrip = id;
            return catalogTrip;
        }
        public async Task<Trip> UpdateTrip(Trip trip)
        {
            if (!trip.IdTrip.HasValue)
            {
                throw new ArgumentNullException("Le voyage n'a pas d'identifiant");
            }

            var catalogTrip = new Trip() { IdTrip = trip.IdTrip };

            int id = await db.ExecuteScalarAsync<int>($"{updateQuery}", catalogTrip);
            catalogTrip.IdTrip = id;
            return catalogTrip;
        }
        public void RemoveTrip(int id)
        {
            int index = _trip.FindIndex(u => u.IdTrip == id);

            if (index != id)
            {
                throw new ArgumentException("trip no longer exists");
            }
            _trip.RemoveAt(index);
        }

    }
}

