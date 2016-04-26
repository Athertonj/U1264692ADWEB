namespace U1264692.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using U1264692.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<U1264692.Dal.MovieRentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(U1264692.Dal.MovieRentalContext context)
        {
            var customers = new List<customer>
            {
                new  customer{ FirstName = "Jack",   LastName = "Atherton",
                    Age = 21, }

            };
            customers.ForEach(c => context.customer.AddOrUpdate(p => p.LastName, c));
            context.SaveChanges();
            var movies = new List<Movies>
            {

                new Movies { FilmTitle = "Shrek", Age = 3, }
            };
            movies.ForEach(c => context.Movies.AddOrUpdate(p => p.FilmTitle, c));
            context.SaveChanges();
            var rentals = new List<Rental>
            {

                 new Rental {
                    customerID = customers.Single(c => c.LastName == "Atherton").customerID,
                    MovieID = movies.Single(a => a.FilmTitle == "Shrek").MovieID

                 }
            };
            foreach (Rental r in rentals)
            {
                var rentalInDataBase = context.Rental.Where(
                    c =>
                         c.customer.customerID == r.customerID &&
                         c.Movies.MovieID == r.MovieID).SingleOrDefault();
                if (rentalInDataBase == null)
                {
                    context.Rental.Add(r);
                }
            }
            context.SaveChanges();
        }
    }
}