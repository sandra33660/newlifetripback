using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Activity
    {
        public int IdActivity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int NumberOfPlacesTotal { get; set; }
        public int Price { get; set; }
        public string ActivitiesPhotoAlbum { get; set; }
    }
}
