using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U1264692.Models
{
    public class Movies
    {
        public int MovieID { get; set; }

        public string FilmTitle { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}