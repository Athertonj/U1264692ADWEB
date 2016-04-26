using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U1264692.Models
{
    public class Rental
    {
        public int RentalID { get; set; }

        public virtual Movies Movies { get; set; }
        public virtual customer customer { get; set; }
    }
}