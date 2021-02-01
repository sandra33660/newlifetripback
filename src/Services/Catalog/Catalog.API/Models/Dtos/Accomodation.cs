using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Accomodation
    {
        public int? IdAccommodation { get; set; }
        public int IdCity { get; set; }
        public string NameAccommodation { get; set; }
        public string StyleAccommodation { get; set; }
        public string NumberPhoneAccommodation { get; set; }
        public string AlbumPhotoAccommodation { get; set; }
        public Decimal Price { get; set; }
    }
}
