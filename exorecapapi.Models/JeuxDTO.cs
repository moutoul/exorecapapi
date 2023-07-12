using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exorecapapi.Models
{
    public class JeuxDTO
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int AnneeSortie { get; set; }
        public int Note { get; set; }

        public string Descriptif { get; set; }

        public int GenreId { get; set; }



    }
}
