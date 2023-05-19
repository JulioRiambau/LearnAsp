namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Release", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedToCatalog", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            DropColumn("dbo.Movies", "AddedToCatalog");
            DropColumn("dbo.Movies", "Release");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "MovieGenreId");
            DropTable("dbo.MovieGenres");
        }
    }
}
