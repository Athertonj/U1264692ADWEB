namespace U1264692.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customer",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.customerID);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        RentalID = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        customerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalID)
                .ForeignKey("dbo.customer", t => t.customerID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.customerID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        FilmTitle = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rental", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Rental", "customerID", "dbo.customer");
            DropIndex("dbo.Rental", new[] { "customerID" });
            DropIndex("dbo.Rental", new[] { "MovieID" });
            DropTable("dbo.Movies");
            DropTable("dbo.Rental");
            DropTable("dbo.customer");
        }
    }
}
