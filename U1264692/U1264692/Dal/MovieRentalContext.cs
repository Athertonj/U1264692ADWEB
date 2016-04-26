using U1264692.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace U1264692.Dal

{
    public class MovieRentalContext : DbContext
{
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Rental> Rental { get; set; }
    public DbSet<customer> customer { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
}
}