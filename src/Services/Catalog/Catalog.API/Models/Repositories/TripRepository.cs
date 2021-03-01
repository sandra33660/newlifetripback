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
        private Dictionary<int, Trip> _allTrip = new Dictionary<int, Trip>();
        private SqlConnection _db;
        const int pageSizeMin = 1;
        const int pageSizeMax = 50;
        const int pageNumMin = 0;
        const string selectQuery = @"SELECT Trip.IdTrip, Trip.Details, Trip.Title, Trip.StartDate,  Trip.FinalDate,      
                                            Trip.Price, Trip.NumberOfParticipants,Photo.Photos
                                     FROM Trip 
                                     INNER JOIN Photo ON Trip.IdTrip = Photo.IdTrip
                                     
                                     ";

        const string updateQuery = @"USE [new_life_trip]
                                    GO

                                    UPDATE [dbo].[Trip]
                                       SET [@champs] = @value
                                     WHERE <@IdTrip=@idTrip>
                                    GO";
        private List<Trip> _trip = new List<Trip>();
        public TripRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            _db.Dispose();
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

            return await _db.QueryAsync<Trip>
                ($"{selectQuery} ORDER BY Trip.IdTrip OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY",
                new { PageNum = pageNum, PageSize = pageSize });

        }

        public async Task<Trip> GetTripById(int id) => await _db.QueryFirstOrDefaultAsync<Trip>($"{selectQuery} WHERE Trip.IdTrip = @id", new { id = id });

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

            return await _db.QueryAsync<Trip>
                ($"{selectQuery} WHERE Trip.Title LIKE @SearchTrip",
                new { SearchTrip = searchTrip + "%", PageNum = pageNum, PageSize = pageSize });

        }
        public async Task<int?> PostNewTripAsync(Trip newTrip)
        {
            if (newTrip == null)
            {
                throw new ArgumentNullException(nameof(newTrip));
            }
            // TODO: vérifier qu'un travel identique n'existe pas déjà ? (might be hard)


            var results = await _db

                .QueryAsync<int>(
                @" USE Newlifetrip33
                  
                   INSERT INTO Trip
                           (Trip.IdComment, 
                            Trip.IdActivityTrip,
                            Trip.Details, 
                            Trip.Title, 
                            Trip.StartDate,  
                            Trip.FinalDate,      
                            Trip.Price, 
                            Trip.NumberOfParticipants)
                    VALUES(@IdComment, 
                            @IdActivityTrip,
                            @Details, 
                            @Title, 
                            @StartDate,  
                            @FinalDate,      
                            @Price, 
                            @NumberOfParticipants );
                   SELECT SCOPE_IDENTITY();",

                    new
                    {

                        newTrip.IdComment,
                        newTrip.IdActivityTrip,
                        newTrip.Details,
                        newTrip.Title,
                        newTrip.StartDate,
                        newTrip.FinalDate,
                        newTrip.Price,
                        newTrip.NumberOfParticipants,
                        //newTrip.Photos,

                    })
                .ConfigureAwait(false);

            var id = results?.FirstOrDefault();

            if (id.HasValue)
            {
                newTrip.IdTrip = id;

            }

            return id;

        }

        public async Task<Trip> UpdateTripAsync(Trip trip)
        {

            if (!trip.IdTrip.HasValue)
            {
                throw new ArgumentNullException("Le voyage n'a pas d'identifiant");
            }

            var catalogTrip = new Trip() { IdTrip = trip.IdTrip };

            int id = await _db.ExecuteScalarAsync<int>(@"
                    USE Newlifetrip33
                    UPDATE Trip
                        (Trip.IdTrip, Trip.IdComment, Trip.IdActivityTrip,Trip.Details, Trip.Title, Trip.StartDate,  Trip.FinalDate,      
                                            Trip.Price, Trip.NumberOfParticipants)
                    VALUES
                        ( @IdComment, @IdActivityTrip, @Details, @Title, @StartDate, @FinalDate, @Price, @NumberOfParticipants);
                    
                    SELECT SCOPE_IDENTITY();",
                    new
                    {
                        catalogTrip.IdTrip,
                        catalogTrip.IdComment,
                        catalogTrip.IdActivityTrip,
                        catalogTrip.Details,
                        catalogTrip.Title,
                        catalogTrip.StartDate,
                        catalogTrip.FinalDate,
                        catalogTrip.Price,
                        catalogTrip.NumberOfParticipants,
                        //newTrip.Photos,

                    }).ConfigureAwait(false);
            catalogTrip.IdTrip = id;

            return catalogTrip;
        }
        public void RemoveTrip(int id)
        {
            _db.Execute("DELETE FROM Trip  WHERE Trip.IdTrip=@id ", new { id = id });
            _allTrip.Remove(id);
        }

    }
}

