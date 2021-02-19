using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Trip
    {
        public int? IdTrip { get; set; }
        public int? IdComment { get; set; }
        public int? IdActivityTrip { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Photos { get; set; }
        public int NumberOfParticipants { get; set; }
        public int Price { get; set; }
        public Trip()
        {

        }
        public Trip(int? idComment, int? idActivityTrip, string details, string title, DateTime startDate, DateTime finalDate, int numberOfParticipants, int price)
        {
            if (title.Length < 2 || title.Length > 50)
            {
                throw new ArgumentException("Le titre doit faire au moins 2 caractères");
            }


            if (numberOfParticipants < 0)
            {
                throw new ArgumentException("Le nombre d'invité est incorrect");
            }
            if (price < 0)
            {
                throw new ArgumentException("Le nombre d'invité est incorrect");
            }

            IdComment = idComment;
            IdActivityTrip = idActivityTrip;
            Details = details;
            Title = title;
            StartDate = startDate;
            FinalDate = finalDate;
            NumberOfParticipants = numberOfParticipants;
            Price = price;
        }
        public void NewTrip()
        {
            IdTrip = null;
        }

    }
}