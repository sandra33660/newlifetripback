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
        public string Photo { get; set; }
        public int NumberOfParticipants { get; set; }


    }
}