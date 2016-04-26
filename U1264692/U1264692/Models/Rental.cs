using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U1264692.Models
{
    public class Rental
    {
        [Key]
        public int RentalID { get; set; }

        public int MovieID { get; set; }
        public int customerID { get; set; }

        public virtual Movies Movies { get; set; }
        public virtual customer customer { get; set; }
    }
}