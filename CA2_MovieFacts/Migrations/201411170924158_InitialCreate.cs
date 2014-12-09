namespace CA2_MovieFacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(),
                        MovieYear = c.Int(nullable: false),
                        MovieFacts = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.ScreenNames",
                c => new
                    {
                        ActorId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        ActorScreenName = c.String(),
                    })
                .PrimaryKey(t => new { t.ActorId, t.MovieId })
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        ActorName = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ScreenNames", new[] { "MovieId" });
            DropIndex("dbo.ScreenNames", new[] { "ActorId" });
            DropForeignKey("dbo.ScreenNames", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ScreenNames", "ActorId", "dbo.Actors");
            DropTable("dbo.Actors");
            DropTable("dbo.ScreenNames");
            DropTable("dbo.Movies");
        }
    }
}
