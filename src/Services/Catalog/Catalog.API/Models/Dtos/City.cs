using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class City
    {
        public int IdCity { get; set; }
        public string NameCity { get; set; }
        public int ZIPCode { get; set; }
        public string Departments { get; set; }
        public string Regions { get; set; }
        public string NameTrip { get; set; }
        public string AlbumPhotoTrip { get; set; }
    }
}
