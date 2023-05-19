namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Action')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Family')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
