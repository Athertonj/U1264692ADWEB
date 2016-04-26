using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U1264692.Models
{
    public class customer
    {
        [Key]
        public int customerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}