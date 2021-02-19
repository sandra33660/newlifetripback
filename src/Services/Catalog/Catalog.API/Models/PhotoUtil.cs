using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class PhotoUtil
    {
        public static void VerifChemin(string image)
        {
            var extension = Path.GetExtension(image);

            if (extension != ".jpg" && extension != ".JPG" && extension != ".png" && extension != ".PNG" && extension != ".JEPG" && extension != ".jpeg")
            {
                throw new ArgumentException("Format de fichier non supporté");
            }
        }
    }
}
